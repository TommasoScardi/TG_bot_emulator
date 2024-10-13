namespace TG_bot_emulator
{
    partial class FormWebhookSecretAuth
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
            btn_WebhookTokenSubmit = new Button();
            label1 = new Label();
            txt_WebhookToken = new TextBox();
            btn_RequestToken = new Button();
            lbl_ReqSts = new Label();
            label4 = new Label();
            lbl_ResStatusCode = new Label();
            SuspendLayout();
            // 
            // btn_WebhookTokenSubmit
            // 
            btn_WebhookTokenSubmit.Location = new Point(339, 19);
            btn_WebhookTokenSubmit.Name = "btn_WebhookTokenSubmit";
            btn_WebhookTokenSubmit.Size = new Size(75, 23);
            btn_WebhookTokenSubmit.TabIndex = 0;
            btn_WebhookTokenSubmit.Text = "SALVA";
            btn_WebhookTokenSubmit.UseVisualStyleBackColor = true;
            btn_WebhookTokenSubmit.Click += btnAuthTokenSubmit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 1;
            label1.Text = "AUTH TOKEN";
            // 
            // txt_WebhookToken
            // 
            txt_WebhookToken.Location = new Point(95, 19);
            txt_WebhookToken.Name = "txt_WebhookToken";
            txt_WebhookToken.Size = new Size(238, 23);
            txt_WebhookToken.TabIndex = 2;
            // 
            // btn_RequestToken
            // 
            btn_RequestToken.Location = new Point(12, 48);
            btn_RequestToken.Name = "btn_RequestToken";
            btn_RequestToken.Size = new Size(402, 23);
            btn_RequestToken.TabIndex = 3;
            btn_RequestToken.Text = "AUTH";
            btn_RequestToken.UseVisualStyleBackColor = true;
            btn_RequestToken.Click += btnRequestToken_Click;
            // 
            // lbl_ReqSts
            // 
            lbl_ReqSts.AutoSize = true;
            lbl_ReqSts.Location = new Point(98, 81);
            lbl_ReqSts.Name = "lbl_ReqSts";
            lbl_ReqSts.Size = new Size(44, 15);
            lbl_ReqSts.TabIndex = 5;
            lbl_ReqSts.Text = "ENDED";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 81);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 6;
            label4.Text = "request status";
            // 
            // lbl_ResStatusCode
            // 
            lbl_ResStatusCode.AutoSize = true;
            lbl_ResStatusCode.Location = new Point(154, 81);
            lbl_ResStatusCode.Name = "lbl_ResStatusCode";
            lbl_ResStatusCode.Size = new Size(33, 15);
            lbl_ResStatusCode.TabIndex = 10;
            lbl_ResStatusCode.Text = "(200)";
            // 
            // FormWebhookSecretAuth
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(433, 105);
            Controls.Add(lbl_ResStatusCode);
            Controls.Add(lbl_ReqSts);
            Controls.Add(label4);
            Controls.Add(btn_RequestToken);
            Controls.Add(txt_WebhookToken);
            Controls.Add(label1);
            Controls.Add(btn_WebhookTokenSubmit);
            Name = "FormWebhookSecretAuth";
            Text = "WebhookSecretAuth";
            Load += FormWebhookSecretAuth_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_WebhookTokenSubmit;
        private Label label1;
        private TextBox txt_WebhookToken;
        private Button btn_RequestToken;
        private Label lbl_ReqSts;
        private Label label4;
        private Label lbl_ResStatusCode;
    }
}