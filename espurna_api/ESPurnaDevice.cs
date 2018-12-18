using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace espurna_api {
    public class ESPurnaDevice {
        public string Host { get; set; }
        public string APIkey { get; set; }
        public string Name { get; set; }

        Dictionary<string, string> _apis = new Dictionary<string, string>();
        Dictionary<string, ApiValue> _apiValues = new Dictionary<string, ApiValue>();

        public DateTime _lastRefresh = new DateTime(0);
        public TimeSpan LastRefresh {
            get { return DateTime.UtcNow - this._lastRefresh; }
        }

        public Dictionary<string, ApiValue> ApiValues {
            get { return _apiValues; }
        }
        public ESPurnaDevice(string name, string host, string apikey) {
            this.Host = host;
            this.APIkey = apikey;
            this.Name = name;
        }
        public ESPurnaDevice(string host, string apikey) : this("", host, apikey) {
        }

        public override string ToString() {
            return string.Format("{0}", Host);
        }

        public void Refresh() {
            if (_apis.Count <= 0) RefreshApi();

            foreach (KeyValuePair<string, string> item in _apis) {
                JObject ob = request(item.Value, "");
                if (!_apiValues.ContainsKey(item.Key)) _apiValues[item.Key] = new ApiValue();
                _apiValues[item.Key].setValue(((JValue)ob[item.Key]).Value);
            }
            _lastRefresh = DateTime.UtcNow;
        }

        private void RefreshApi() {
            JObject ob = request("/api", "");
            foreach (JProperty jt in ob.Children()) {
                _apis[jt.Name] = jt.Value.ToString();
            }
        }

        public string getUrl(string request) {
            return string.Format("http://{0}{1}", Host, request);
        }

        protected JObject request(string request, string value) {
            return makeHttpRequest(getUrl(request), "apikey=" + APIkey + "&" + value);
        }

        private JObject makeHttpRequest(string url, string data) {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.BaseAddress = new Uri(url);

            StringContent queryString = new StringContent(data, Encoding.ASCII, "application/x-www-form-urlencoded");

            HttpResponseMessage response = client.PutAsync(url, queryString).Result;
            if (response.IsSuccessStatusCode) {
                return JObject.Parse(response.Content.ReadAsStringAsync().Result);
            } else {
                return null;
            }
        }

        public class ApiValue {
            public object Value = null;
            public DateTime Time = new DateTime(0);

            public ApiValue() {
            }
            public ApiValue(object value) {
                this.setValue(value);
            }
            public void setValue(object value) {
                this.Value = value;
                this.Time = DateTime.UtcNow;
            }
            public override string ToString() {
                return Value + "";
            }
        }
    }
}