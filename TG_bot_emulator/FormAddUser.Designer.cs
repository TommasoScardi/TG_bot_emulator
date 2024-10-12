namespace TG_sender_emulator
{
    partial class FormAddUser
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
            txt_UID = new TextBox();
            btn_AddSubmit = new Button();
            label2 = new Label();
            txt_UserName = new TextBox();
            btn_End = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 0;
            label1.Text = "User ID";
            // 
            // txt_UID
            // 
            txt_UID.Location = new Point(102, 17);
            txt_UID.Name = "txt_UID";
            txt_UID.Size = new Size(139, 23);
            txt_UID.TabIndex = 1;
            // 
            // btn_AddSubmit
            // 
            btn_AddSubmit.Location = new Point(12, 90);
            btn_AddSubmit.Name = "btn_AddSubmit";
            btn_AddSubmit.Size = new Size(151, 23);
            btn_AddSubmit.TabIndex = 2;
            btn_AddSubmit.Text = "AGGIUNGI";
            btn_AddSubmit.UseVisualStyleBackColor = true;
            btn_AddSubmit.Click += btn_AddSubmit_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 0;
            label2.Text = "Nome";
            // 
            // txt_UserName
            // 
            txt_UserName.Location = new Point(102, 49);
            txt_UserName.Name = "txt_UserName";
            txt_UserName.Size = new Size(139, 23);
            txt_UserName.TabIndex = 1;
            // 
            // btn_End
            // 
            btn_End.Location = new Point(169, 90);
            btn_End.Name = "btn_End";
            btn_End.Size = new Size(72, 23);
            btn_End.TabIndex = 3;
            btn_End.Text = "FINE";
            btn_End.UseVisualStyleBackColor = true;
            btn_End.Click += btn_End_Click;
            // 
            // AddUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(261, 123);
            Controls.Add(btn_End);
            Controls.Add(btn_AddSubmit);
            Controls.Add(txt_UserName);
            Controls.Add(txt_UID);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddUser";
            Text = "AddUser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txt_UID;
        private Button btn_AddSubmit;
        private Label label2;
        private TextBox txt_UserName;
        private Button btn_End;
    }
}