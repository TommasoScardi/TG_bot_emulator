namespace TG_bot_emulator
{
    partial class FormBotEmulator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            txt_MessageId = new TextBox();
            label1 = new Label();
            cbo_Users = new ComboBox();
            ch_SaveMessage = new CheckBox();
            btn_CleanResponseBody = new Button();
            btn_CleanMessageText = new Button();
            btn_CronRequest = new Button();
            btn_SendMessage = new Button();
            label3 = new Label();
            label2 = new Label();
            txt_MessageText = new TextBox();
            rbtn_MessageTypeQuery = new RadioButton();
            rbtn_MessageTypeCMD = new RadioButton();
            rbtn_MessageTypeURL = new RadioButton();
            rbtn_MessageTypeText = new RadioButton();
            gbox_Response = new GroupBox();
            rtxt_ResponseBody = new RichTextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            groupBox3 = new GroupBox();
            lbox_MessageText = new ListBox();
            groupBox4 = new GroupBox();
            lbox_MessageUrl = new ListBox();
            groupBox5 = new GroupBox();
            lbox_MessageCmd = new ListBox();
            groupBox6 = new GroupBox();
            lbox_MessageQuery = new ListBox();
            menuStrip1 = new MenuStrip();
            configToolStripMenuItem = new ToolStripMenuItem();
            showConfigBoxToolStripMenuItem = new ToolStripMenuItem();
            authToolStripMenuItem = new ToolStripMenuItem();
            usersToolStripMenuItem = new ToolStripMenuItem();
            addUserToolStripMenuItem = new ToolStripMenuItem();
            serverDebugToolStripMenuItem = new ToolStripMenuItem();
            xDebugToolStripMenuItem = new ToolStripMenuItem();
            toggleXDebugToolStripMenuItem = new ToolStripMenuItem();
            toolStripContainer1 = new ToolStripContainer();
            statusStrip1 = new StatusStrip();
            lbl_selectedConfig = new ToolStripStatusLabel();
            lbl_responseStatus = new ToolStripStatusLabel();
            lbl_responseTime = new ToolStripStatusLabel();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            gbox_Response.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            menuStrip1.SuspendLayout();
            toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 2);
            tableLayoutPanel1.Controls.Add(gbox_Response, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 135F));
            tableLayoutPanel1.Size = new Size(800, 439);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txt_MessageId);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cbo_Users);
            groupBox1.Controls.Add(ch_SaveMessage);
            groupBox1.Controls.Add(btn_CleanResponseBody);
            groupBox1.Controls.Add(btn_CleanMessageText);
            groupBox1.Controls.Add(btn_CronRequest);
            groupBox1.Controls.Add(btn_SendMessage);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txt_MessageText);
            groupBox1.Controls.Add(rbtn_MessageTypeQuery);
            groupBox1.Controls.Add(rbtn_MessageTypeCMD);
            groupBox1.Controls.Add(rbtn_MessageTypeURL);
            groupBox1.Controls.Add(rbtn_MessageTypeText);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 307);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(794, 129);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "request";
            // 
            // txt_MessageId
            // 
            txt_MessageId.Location = new Point(87, 60);
            txt_MessageId.Name = "txt_MessageId";
            txt_MessageId.Size = new Size(100, 23);
            txt_MessageId.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 62);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 7;
            label1.Text = "MESSAGE ID";
            // 
            // cbo_Users
            // 
            cbo_Users.FormattingEnabled = true;
            cbo_Users.Location = new Point(627, 59);
            cbo_Users.Name = "cbo_Users";
            cbo_Users.Size = new Size(158, 23);
            cbo_Users.TabIndex = 6;
            // 
            // ch_SaveMessage
            // 
            ch_SaveMessage.AutoSize = true;
            ch_SaveMessage.Checked = true;
            ch_SaveMessage.CheckState = CheckState.Checked;
            ch_SaveMessage.Location = new Point(454, 22);
            ch_SaveMessage.Name = "ch_SaveMessage";
            ch_SaveMessage.Size = new Size(98, 19);
            ch_SaveMessage.TabIndex = 5;
            ch_SaveMessage.Text = "save message";
            ch_SaveMessage.UseVisualStyleBackColor = true;
            // 
            // btn_CleanResponseBody
            // 
            btn_CleanResponseBody.Location = new Point(194, 96);
            btn_CleanResponseBody.Name = "btn_CleanResponseBody";
            btn_CleanResponseBody.Size = new Size(97, 22);
            btn_CleanResponseBody.TabIndex = 3;
            btn_CleanResponseBody.Text = "CLEAN BODY";
            btn_CleanResponseBody.UseVisualStyleBackColor = true;
            btn_CleanResponseBody.Click += btn_CleanResponseBody_Click;
            // 
            // btn_CleanMessageText
            // 
            btn_CleanMessageText.Location = new Point(94, 96);
            btn_CleanMessageText.Name = "btn_CleanMessageText";
            btn_CleanMessageText.Size = new Size(94, 22);
            btn_CleanMessageText.TabIndex = 3;
            btn_CleanMessageText.Text = "CLEAN TEXT";
            btn_CleanMessageText.UseVisualStyleBackColor = true;
            btn_CleanMessageText.Click += btn_CleanMessageText_Click;
            // 
            // btn_CronRequest
            // 
            btn_CronRequest.Location = new Point(659, 96);
            btn_CronRequest.Name = "btn_CronRequest";
            btn_CronRequest.Size = new Size(75, 22);
            btn_CronRequest.TabIndex = 3;
            btn_CronRequest.Text = "CRON";
            btn_CronRequest.UseVisualStyleBackColor = true;
            btn_CronRequest.Click += btn_CronRequest_Click;
            // 
            // btn_SendMessage
            // 
            btn_SendMessage.Location = new Point(477, 96);
            btn_SendMessage.Name = "btn_SendMessage";
            btn_SendMessage.Size = new Size(75, 23);
            btn_SendMessage.TabIndex = 3;
            btn_SendMessage.Text = "SEND";
            btn_SendMessage.UseVisualStyleBackColor = true;
            btn_SendMessage.Click += btn_Send_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(201, 62);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 2;
            label3.Text = "MESSAGE TEXT";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(573, 63);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 2;
            label2.Text = "USER ID";
            // 
            // txt_MessageText
            // 
            txt_MessageText.Location = new Point(293, 59);
            txt_MessageText.Name = "txt_MessageText";
            txt_MessageText.Size = new Size(259, 23);
            txt_MessageText.TabIndex = 1;
            txt_MessageText.TextChanged += txt_Message_TextChanged;
            txt_MessageText.KeyUp += txt_MessageText_KeyUp;
            // 
            // rbtn_MessageTypeQuery
            // 
            rbtn_MessageTypeQuery.AutoSize = true;
            rbtn_MessageTypeQuery.Location = new Point(189, 22);
            rbtn_MessageTypeQuery.Name = "rbtn_MessageTypeQuery";
            rbtn_MessageTypeQuery.Size = new Size(101, 19);
            rbtn_MessageTypeQuery.TabIndex = 0;
            rbtn_MessageTypeQuery.TabStop = true;
            rbtn_MessageTypeQuery.Text = "callback query";
            rbtn_MessageTypeQuery.UseVisualStyleBackColor = true;
            rbtn_MessageTypeQuery.CheckedChanged += rbtn_ModeQuery_CheckedChanged;
            // 
            // rbtn_MessageTypeCMD
            // 
            rbtn_MessageTypeCMD.AutoSize = true;
            rbtn_MessageTypeCMD.Location = new Point(134, 22);
            rbtn_MessageTypeCMD.Name = "rbtn_MessageTypeCMD";
            rbtn_MessageTypeCMD.Size = new Size(49, 19);
            rbtn_MessageTypeCMD.TabIndex = 0;
            rbtn_MessageTypeCMD.TabStop = true;
            rbtn_MessageTypeCMD.Text = "cmd";
            rbtn_MessageTypeCMD.UseVisualStyleBackColor = true;
            rbtn_MessageTypeCMD.CheckedChanged += rbtn_ModeCmd_CheckedChanged;
            // 
            // rbtn_MessageTypeURL
            // 
            rbtn_MessageTypeURL.AutoSize = true;
            rbtn_MessageTypeURL.Location = new Point(89, 22);
            rbtn_MessageTypeURL.Name = "rbtn_MessageTypeURL";
            rbtn_MessageTypeURL.Size = new Size(39, 19);
            rbtn_MessageTypeURL.TabIndex = 0;
            rbtn_MessageTypeURL.TabStop = true;
            rbtn_MessageTypeURL.Text = "url";
            rbtn_MessageTypeURL.UseVisualStyleBackColor = true;
            rbtn_MessageTypeURL.CheckedChanged += rbtn_ModeUrl_CheckedChanged;
            // 
            // rbtn_MessageTypeText
            // 
            rbtn_MessageTypeText.AutoSize = true;
            rbtn_MessageTypeText.Checked = true;
            rbtn_MessageTypeText.Location = new Point(9, 22);
            rbtn_MessageTypeText.Name = "rbtn_MessageTypeText";
            rbtn_MessageTypeText.Size = new Size(74, 19);
            rbtn_MessageTypeText.TabIndex = 0;
            rbtn_MessageTypeText.TabStop = true;
            rbtn_MessageTypeText.Text = "plain text";
            rbtn_MessageTypeText.UseVisualStyleBackColor = true;
            rbtn_MessageTypeText.CheckedChanged += rbtn_ModeText_CheckedChanged;
            // 
            // gbox_Response
            // 
            gbox_Response.Controls.Add(rtxt_ResponseBody);
            gbox_Response.Dock = DockStyle.Fill;
            gbox_Response.Location = new Point(3, 155);
            gbox_Response.Name = "gbox_Response";
            gbox_Response.Size = new Size(794, 146);
            gbox_Response.TabIndex = 1;
            gbox_Response.TabStop = false;
            gbox_Response.Text = "Response Body";
            // 
            // rtxt_ResponseBody
            // 
            rtxt_ResponseBody.Dock = DockStyle.Fill;
            rtxt_ResponseBody.Location = new Point(3, 19);
            rtxt_ResponseBody.Name = "rtxt_ResponseBody";
            rtxt_ResponseBody.Size = new Size(788, 124);
            rtxt_ResponseBody.TabIndex = 0;
            rtxt_ResponseBody.Text = "";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(groupBox3, 0, 0);
            tableLayoutPanel2.Controls.Add(groupBox4, 1, 0);
            tableLayoutPanel2.Controls.Add(groupBox5, 2, 0);
            tableLayoutPanel2.Controls.Add(groupBox6, 3, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(794, 146);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lbox_MessageText);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(192, 140);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "plain text";
            // 
            // lbox_MessageText
            // 
            lbox_MessageText.Dock = DockStyle.Fill;
            lbox_MessageText.FormattingEnabled = true;
            lbox_MessageText.ItemHeight = 15;
            lbox_MessageText.Location = new Point(3, 19);
            lbox_MessageText.Name = "lbox_MessageText";
            lbox_MessageText.Size = new Size(186, 118);
            lbox_MessageText.TabIndex = 0;
            lbox_MessageText.MouseDoubleClick += lbox_MessageText_MouseDoubleClick;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lbox_MessageUrl);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(201, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(192, 140);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "url";
            // 
            // lbox_MessageUrl
            // 
            lbox_MessageUrl.Dock = DockStyle.Fill;
            lbox_MessageUrl.FormattingEnabled = true;
            lbox_MessageUrl.ItemHeight = 15;
            lbox_MessageUrl.Location = new Point(3, 19);
            lbox_MessageUrl.Name = "lbox_MessageUrl";
            lbox_MessageUrl.Size = new Size(186, 118);
            lbox_MessageUrl.TabIndex = 0;
            lbox_MessageUrl.MouseDoubleClick += lbox_MessageUrl_MouseDoubleClick;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(lbox_MessageCmd);
            groupBox5.Dock = DockStyle.Fill;
            groupBox5.Location = new Point(399, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(192, 140);
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            groupBox5.Text = "cmd";
            // 
            // lbox_MessageCmd
            // 
            lbox_MessageCmd.Dock = DockStyle.Fill;
            lbox_MessageCmd.FormattingEnabled = true;
            lbox_MessageCmd.ItemHeight = 15;
            lbox_MessageCmd.Location = new Point(3, 19);
            lbox_MessageCmd.Name = "lbox_MessageCmd";
            lbox_MessageCmd.Size = new Size(186, 118);
            lbox_MessageCmd.TabIndex = 0;
            lbox_MessageCmd.MouseDoubleClick += lbox_MessageCmd_MouseDoubleClick;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(lbox_MessageQuery);
            groupBox6.Dock = DockStyle.Fill;
            groupBox6.Location = new Point(597, 3);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(194, 140);
            groupBox6.TabIndex = 3;
            groupBox6.TabStop = false;
            groupBox6.Text = "callback query";
            // 
            // lbox_MessageQuery
            // 
            lbox_MessageQuery.Dock = DockStyle.Fill;
            lbox_MessageQuery.FormattingEnabled = true;
            lbox_MessageQuery.ItemHeight = 15;
            lbox_MessageQuery.Location = new Point(3, 19);
            lbox_MessageQuery.Name = "lbox_MessageQuery";
            lbox_MessageQuery.Size = new Size(188, 118);
            lbox_MessageQuery.TabIndex = 0;
            lbox_MessageQuery.MouseDoubleClick += lbox_MessageQuery_MouseDoubleClick;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Items.AddRange(new ToolStripItem[] { configToolStripMenuItem, usersToolStripMenuItem, serverDebugToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // configToolStripMenuItem
            // 
            configToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { showConfigBoxToolStripMenuItem, authToolStripMenuItem });
            configToolStripMenuItem.Name = "configToolStripMenuItem";
            configToolStripMenuItem.Size = new Size(53, 20);
            configToolStripMenuItem.Text = "config";
            // 
            // showConfigBoxToolStripMenuItem
            // 
            showConfigBoxToolStripMenuItem.Name = "showConfigBoxToolStripMenuItem";
            showConfigBoxToolStripMenuItem.Size = new Size(162, 22);
            showConfigBoxToolStripMenuItem.Text = "show config box";
            showConfigBoxToolStripMenuItem.Click += showConfigBoxToolStripMenuItem_Click;
            // 
            // authToolStripMenuItem
            // 
            authToolStripMenuItem.Name = "authToolStripMenuItem";
            authToolStripMenuItem.Size = new Size(162, 22);
            authToolStripMenuItem.Text = "auth";
            authToolStripMenuItem.Click += authToolStripMenuItem_Click;
            // 
            // usersToolStripMenuItem
            // 
            usersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addUserToolStripMenuItem });
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new Size(46, 20);
            usersToolStripMenuItem.Text = "users";
            // 
            // addUserToolStripMenuItem
            // 
            addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            addUserToolStripMenuItem.Size = new Size(119, 22);
            addUserToolStripMenuItem.Text = "add user";
            addUserToolStripMenuItem.Click += addUserToolStripMenuItem_Click;
            // 
            // serverDebugToolStripMenuItem
            // 
            serverDebugToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { xDebugToolStripMenuItem });
            serverDebugToolStripMenuItem.Name = "serverDebugToolStripMenuItem";
            serverDebugToolStripMenuItem.Size = new Size(87, 20);
            serverDebugToolStripMenuItem.Text = "server debug";
            // 
            // xDebugToolStripMenuItem
            // 
            xDebugToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toggleXDebugToolStripMenuItem });
            xDebugToolStripMenuItem.Name = "xDebugToolStripMenuItem";
            xDebugToolStripMenuItem.Size = new Size(116, 22);
            xDebugToolStripMenuItem.Text = "XDebug";
            // 
            // toggleXDebugToolStripMenuItem
            // 
            toggleXDebugToolStripMenuItem.Checked = true;
            toggleXDebugToolStripMenuItem.CheckState = CheckState.Checked;
            toggleXDebugToolStripMenuItem.Name = "toggleXDebugToolStripMenuItem";
            toggleXDebugToolStripMenuItem.Size = new Size(108, 22);
            toggleXDebugToolStripMenuItem.Text = "toggle";
            toggleXDebugToolStripMenuItem.Click += toggleXDebugToolStripMenuItem_Click;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            toolStripContainer1.BottomToolStripPanel.Controls.Add(statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(tableLayoutPanel1);
            toolStripContainer1.ContentPanel.Size = new Size(800, 439);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.LeftToolStripPanelVisible = false;
            toolStripContainer1.Location = new Point(0, 0);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.RightToolStripPanelVisible = false;
            toolStripContainer1.Size = new Size(800, 485);
            toolStripContainer1.TabIndex = 2;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            toolStripContainer1.TopToolStripPanel.Controls.Add(menuStrip1);
            // 
            // statusStrip1
            // 
            statusStrip1.Dock = DockStyle.None;
            statusStrip1.Items.AddRange(new ToolStripItem[] { lbl_selectedConfig, lbl_responseStatus, lbl_responseTime });
            statusStrip1.Location = new Point(0, 0);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 0;
            // 
            // lbl_selectedConfig
            // 
            lbl_selectedConfig.Name = "lbl_selectedConfig";
            lbl_selectedConfig.Size = new Size(87, 17);
            lbl_selectedConfig.Text = "selected config";
            // 
            // lbl_responseStatus
            // 
            lbl_responseStatus.Name = "lbl_responseStatus";
            lbl_responseStatus.Size = new Size(633, 17);
            lbl_responseStatus.Spring = true;
            lbl_responseStatus.Text = "response status: NO REQUEST (xxx)";
            lbl_responseStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_responseTime
            // 
            lbl_responseTime.Name = "lbl_responseTime";
            lbl_responseTime.Size = new Size(34, 17);
            lbl_responseTime.Text = "time:";
            // 
            // FormBotEmulator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 485);
            Controls.Add(toolStripContainer1);
            MainMenuStrip = menuStrip1;
            Name = "FormBotEmulator";
            Text = "TG send message emulator";
            FormClosing += TG_APP_FormClosing;
            Load += TG_APP_Load;
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbox_Response.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            toolStripContainer1.BottomToolStripPanel.PerformLayout();
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private RadioButton rbtn_MessageTypeQuery;
        private RadioButton rbtn_MessageTypeCMD;
        private RadioButton rbtn_MessageTypeURL;
        private RadioButton rbtn_MessageTypeText;
        private Button btn_SendMessage;
        private TextBox txt_MessageText;
        private GroupBox gbox_Response;
        public RichTextBox rtxt_ResponseBody;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox3;
        private ListBox lbox_MessageText;
        private GroupBox groupBox4;
        private ListBox lbox_MessageUrl;
        private GroupBox groupBox5;
        private ListBox lbox_MessageCmd;
        private GroupBox groupBox6;
        private ListBox lbox_MessageQuery;
        private CheckBox ch_SaveMessage;
        private Button btn_CleanResponseBody;
        private Button btn_CleanMessageText;
        private Button btn_CronRequest;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem configToolStripMenuItem;
        private ToolStripMenuItem showConfigBoxToolStripMenuItem;
        private ComboBox cbo_Users;
        private ToolStripMenuItem usersToolStripMenuItem;
        private ToolStripMenuItem addUserToolStripMenuItem;
        private ToolStripMenuItem authToolStripMenuItem;
        private TextBox txt_MessageId;
        private Label label1;
        private ToolStripMenuItem serverDebugToolStripMenuItem;
        private ToolStripMenuItem xDebugToolStripMenuItem;
        public ToolStripMenuItem toggleXDebugToolStripMenuItem;
        private ToolStripContainer toolStripContainer1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lbl_selectedConfig;
        private ToolStripStatusLabel lbl_responseStatus;
        private ToolStripStatusLabel lbl_responseTime;
    }
}