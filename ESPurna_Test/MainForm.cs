using espurna_api;
using espurna_api.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESPurna_Test {
    public partial class MainForm : Form {
        Blitzwolf_bw_shp2 esp = null;
        public MainForm() {
            InitializeComponent();
        }

        private void onClick(object sender, EventArgs e) {
            setESPuraDevice();
            if (sender == bOff) {
                esp.SetRelay(false);
            } else if (sender == bOn) {
                esp.SetRelay(true);
            } else if (sender == bToggle) {
                esp.Toogle();
            }
        }

        private void setESPuraDevice() {
            if (esp == null || !esp.APIkey.Equals(tbApiKey.Text) || !esp.Host.Equals(tbHost.Text)) {
                esp = new Blitzwolf_bw_shp2(tbHost.Text, tbApiKey.Text);
            }
        }

        bool inTimer = false;
        private void timer_Tick(object sender, EventArgs e) {
            if (inTimer) return;
            try {
                inTimer = true;

                setESPuraDevice();

                StringBuilder sb = new StringBuilder();
                if (esp == null) {
                    sb.AppendLine("ESP not configured...");
                } else {
                    if (esp.LastRefresh.TotalSeconds > 5) {
                        esp.Refresh();
                    }
                    sb.AppendLine(string.Format("Last refresh: {0:0.0}s", esp.LastRefresh.TotalSeconds));

                    sb.AppendLine(string.Format("Relay: {0}", esp.Relay ? "On" : "Off"));
                    sb.AppendLine(string.Format("Power: {0:n0} W", esp.Power));
                    sb.AppendLine(string.Format("Reactive: {0:n0} W", esp.Reactive));
                    sb.AppendLine(string.Format("Apparent: {0:n0} W", esp.Apparent));
                    sb.AppendLine(string.Format("Current: {0:0.000} A", esp.Current));
                    sb.AppendLine(string.Format("Energy: {0:n3} kWh", esp.Energy));
                    sb.AppendLine(string.Format("Factor: {0:0%}", esp.Factor));

                    sb.AppendLine(string.Format(""));

                    foreach (KeyValuePair<string, espurna_api.ESPurnaDevice.ApiValue> item in esp.ApiValues) {
                        sb.AppendLine(item.Key + ": " + item.Value);
                    }
                    lStatus.Text = sb.ToString();
                }
            } catch (Exception ex) {
                lStatus.Text = ex.Message + "\n" + ex.StackTrace;
            } finally {
                inTimer = false;
            }
        }
    }
}