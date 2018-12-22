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
        ESPurnaDevice esp = null;
        public MainForm() {
            InitializeComponent();
        }
        private void setESPuraDevice() {
            if (esp == null || !esp.APIkey.Equals(tbApiKey.Text) || !esp.Host.Equals(tbHost.Text)) {
                esp = new Blitzwolf_bw_shp2(tbHost.Text, tbApiKey.Text);
            }
        }

        private void onClick(object sender, EventArgs e) {
            setESPuraDevice();
            if(esp is Blitzwolf_bw_shp2) {
                Blitzwolf_bw_shp2 blitz = (Blitzwolf_bw_shp2)esp;
                if (sender == bOff) {
                    blitz.SetRelay(false);
                } else if (sender == bOn) {
                    blitz.SetRelay(true);
                } else if (sender == bToggle) {
                    blitz.Toogle();
                }
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
                    lStatus.Text = esp.getStatus();
                }
            } catch (Exception ex) {
                lStatus.Text = ex.Message + "\n" + ex.StackTrace;
            } finally {
                inTimer = false;
            }
        }
    }
}