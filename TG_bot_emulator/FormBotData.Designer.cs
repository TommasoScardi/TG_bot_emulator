namespace TG_sender_emulator
{
    partial class FormBotData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txt_EndpointsURL = new TextBox();
            label2 = new Label();
            txt_WebhookEP = new TextBox();
            label3 = new Label();
            txt_WebhookSetEP = new TextBox();
            label4 = new Label();
            txt_CronEP = new TextBox();
            btn_SaveSubmit = new Button();
            label5 = new Label();
            txt_ConfigName = new TextBox();
            cbo_BotsConfig = new ComboBox();
            label6 = new Label();
            btn_NewConfig = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 87);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "URL:PORT";
            // 
            // txt_EndpointsURL
            // 
            txt_EndpointsURL.Location = new Point(96, 84);
            txt_EndpointsURL.Name = "txt_EndpointsURL";
            txt_EndpointsURL.Size = new Size(280, 23);
            txt_EndpointsURL.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 116);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 0;
            label2.Text = "webhook EP";
            // 
            // txt_WebhookEP
            // 
            txt_WebhookEP.Location = new Point(96, 113);
            txt_WebhookEP.Name = "txt_WebhookEP";
            txt_WebhookEP.Size = new Size(280, 23);
            txt_WebhookEP.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 145);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 0;
            label3.Text = "wh SET EP";
            // 
            // txt_WebhookSetEP
            // 
            txt_WebhookSetEP.Location = new Point(96, 142);
            txt_WebhookSetEP.Name = "txt_WebhookSetEP";
            txt_WebhookSetEP.Size = new Size(280, 23);
            txt_WebhookSetEP.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 174);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 0;
            label4.Text = "cron EP";
            // 
            // txt_CronEP
            // 
            txt_CronEP.Location = new Point(96, 171);
            txt_CronEP.Name = "txt_CronEP";
            txt_CronEP.Size = new Size(280, 23);
            txt_CronEP.TabIndex = 1;
            // 
            // btn_SaveSubmit
            // 
            btn_SaveSubmit.Location = new Point(12, 211);
            btn_SaveSubmit.Name = "btn_SaveSubmit";
            btn_SaveSubmit.Size = new Size(364, 29);
            btn_SaveSubmit.TabIndex = 2;
            btn_SaveSubmit.Text = "USA";
            btn_SaveSubmit.UseVisualStyleBackColor = true;
            btn_SaveSubmit.Click += btn_submit_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 58);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 0;
            label5.Text = "Config Name";
            // 
            // txt_ConfigName
            // 
            txt_ConfigName.Location = new Point(96, 55);
            txt_ConfigName.Name = "txt_ConfigName";
            txt_ConfigName.Size = new Size(280, 23);
            txt_ConfigName.TabIndex = 1;
            // 
            // cbo_BotsConfig
            // 
            cbo_BotsConfig.FormattingEnabled = true;
            cbo_BotsConfig.Location = new Point(96, 7);
            cbo_BotsConfig.Name = "cbo_BotsConfig";
            cbo_BotsConfig.Size = new Size(199, 23);
            cbo_BotsConfig.TabIndex = 3;
            cbo_BotsConfig.SelectedIndexChanged += cbo_BotsConfig_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 10);
            label6.Name = "label6";
            label6.Size = new Size(82, 15);
            label6.TabIndex = 0;
            label6.Text = "Saved Configs";
            // 
            // btn_NewConfig
            // 
            btn_NewConfig.Location = new Point(301, 7);
            btn_NewConfig.Name = "btn_NewConfig";
            btn_NewConfig.Size = new Size(75, 23);
            btn_NewConfig.TabIndex = 4;
            btn_NewConfig.Text = "NUOVO";
            btn_NewConfig.UseVisualStyleBackColor = true;
            btn_NewConfig.Click += btn_NewConfig_Click;
            // 
            // FormBotData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 254);
            Controls.Add(btn_NewConfig);
            Controls.Add(cbo_BotsConfig);
            Controls.Add(btn_SaveSubmit);
            Controls.Add(txt_CronEP);
            Controls.Add(label4);
            Controls.Add(txt_WebhookSetEP);
            Controls.Add(label3);
            Controls.Add(txt_WebhookEP);
            Controls.Add(label2);
            Controls.Add(txt_ConfigName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txt_EndpointsURL);
            Controls.Add(label1);
            Name = "FormBotData";
            Text = "BOT URLS";
            Load += BotDataForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txt_EndpointsURL;
        private Label label2;
        private TextBox txt_WebhookEP;
        private Label label3;
        private TextBox txt_WebhookSetEP;
        private Label label4;
        private TextBox txt_CronEP;
        private Button btn_SaveSubmit;
        private Label label5;
        private TextBox txt_ConfigName;
        private ComboBox cbo_BotsConfig;
        private Label label6;
        private Button btn_NewConfig;
    }
}