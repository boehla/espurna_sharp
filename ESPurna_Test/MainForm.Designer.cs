namespace ESPurna_Test {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.tbApiKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bToggle = new System.Windows.Forms.Button();
            this.bOn = new System.Windows.Forms.Button();
            this.bOff = new System.Windows.Forms.Button();
            this.lStatus = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(82, 12);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(187, 20);
            this.tbHost.TabIndex = 0;
            this.tbHost.Text = "10.0.1.21";
            // 
            // tbApiKey
            // 
            this.tbApiKey.Location = new System.Drawing.Point(82, 38);
            this.tbApiKey.Name = "tbApiKey";
            this.tbApiKey.Size = new System.Drawing.Size(187, 20);
            this.tbApiKey.TabIndex = 0;
            this.tbApiKey.Text = "C49985579AA2F345";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Host";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "API Key";
            // 
            // bToggle
            // 
            this.bToggle.Location = new System.Drawing.Point(12, 64);
            this.bToggle.Name = "bToggle";
            this.bToggle.Size = new System.Drawing.Size(75, 23);
            this.bToggle.TabIndex = 2;
            this.bToggle.Text = "Toggle";
            this.bToggle.UseVisualStyleBackColor = true;
            this.bToggle.Click += new System.EventHandler(this.onClick);
            // 
            // bOn
            // 
            this.bOn.Location = new System.Drawing.Point(93, 64);
            this.bOn.Name = "bOn";
            this.bOn.Size = new System.Drawing.Size(75, 23);
            this.bOn.TabIndex = 2;
            this.bOn.Text = "On";
            this.bOn.UseVisualStyleBackColor = true;
            this.bOn.Click += new System.EventHandler(this.onClick);
            // 
            // bOff
            // 
            this.bOff.Location = new System.Drawing.Point(174, 64);
            this.bOff.Name = "bOff";
            this.bOff.Size = new System.Drawing.Size(75, 23);
            this.bOff.TabIndex = 2;
            this.bOff.Text = "Off";
            this.bOff.UseVisualStyleBackColor = true;
            this.bOff.Click += new System.EventHandler(this.onClick);
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(13, 94);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(37, 13);
            this.lStatus.TabIndex = 3;
            this.lStatus.Text = "Status";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 321);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.bOff);
            this.Controls.Add(this.bOn);
            this.Controls.Add(this.bToggle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbApiKey);
            this.Controls.Add(this.tbHost);
            this.Name = "MainForm";
            this.Text = "ESPurna Testprogram";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.TextBox tbApiKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bToggle;
        private System.Windows.Forms.Button bOn;
        private System.Windows.Forms.Button bOff;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Timer timer;
    }
}

