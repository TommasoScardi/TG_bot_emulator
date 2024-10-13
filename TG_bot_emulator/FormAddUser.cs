using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TG_sender_emulator
{
    public partial class FormAddUser : Form
    {
        BindingList<Models.UserModel> _users;
        public FormAddUser(ref BindingList<Models.UserModel> users)
        {
            _users = users;
            InitializeComponent();
        }

        private void btn_AddSubmit_Click(object sender, EventArgs e)
        {
            Models.UserModel newUser = new Models.UserModel() { Id = long.Parse(txt_UID.Text), Name = txt_UserName.Text };
            _users.Add(newUser);
        }

        private void btn_End_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
