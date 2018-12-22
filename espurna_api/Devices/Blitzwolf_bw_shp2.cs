using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace espurna_api.Devices {
    public class Blitzwolf_bw_shp2 : espurna_api.ESPurnaDevice {
        private const string RELAY_KEY = "relay/0";

        public Blitzwolf_bw_shp2(string name, string host, string api) : base(name, host, api) {
        }
        public Blitzwolf_bw_shp2(string host, string api) : base(host, api) {
        }
        public bool Toogle() {
            JObject ob = base.request("/api/" + RELAY_KEY, "value=2");
            base.ApiValues[RELAY_KEY].setValue(((JValue)ob[RELAY_KEY]).Value);
            return this.Relay;
        }
        public bool SetRelay(bool value) {
            JObject ob = base.request("/api/" + RELAY_KEY, "value=" + (value ? "1" : "0"));
            base.ApiValues[RELAY_KEY].setValue(((JValue)ob[RELAY_KEY]).Value);
            return this.Relay;
        }
        public bool Relay {
            get { return (long)base.ApiValues[RELAY_KEY].Value == 0 ? false : true; }
        }
        public double Power {
            get { return Convert.ToDouble(base.ApiValues["power"].Value); }
        }
        public double Reactive {
            get { return Convert.ToDouble(base.ApiValues["reactive"].Value); }
        }
        public double Apparent {
            get { return Convert.ToDouble(base.ApiValues["apparent"].Value); }
        }
        public double Energy {
            get { return Convert.ToDouble(base.ApiValues["energy"].Value); }
        }
        /// <summary>
        /// 0 - 1 => 1 = 100%
        /// </summary>
        public double Factor {
            get { return Convert.ToDouble(base.ApiValues["factor"].Value) / 100d; }
        }
        public double Current {
            get { return Convert.ToDouble(base.ApiValues["current"].Value); }
        }

        public override string getStatus() {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("Last refresh: {0:0.0}s", this.LastRefresh.TotalSeconds));

            sb.AppendLine(string.Format("Relay: {0}", this.Relay ? "On" : "Off"));
            sb.AppendLine(string.Format("Power: {0:n0} W", this.Power));
            sb.AppendLine(string.Format("Reactive: {0:n0} W", this.Reactive));
            sb.AppendLine(string.Format("Apparent: {0:n0} W", this.Apparent));
            sb.AppendLine(string.Format("Current: {0:0.000} A", this.Current));
            sb.AppendLine(string.Format("Energy: {0:n3} kWh", this.Energy));
            sb.AppendLine(string.Format("Factor: {0:0%}", this.Factor));

            return sb.ToString();
        }
    }
}