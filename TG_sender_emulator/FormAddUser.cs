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
        BindingList<Models.User> _users;
        public FormAddUser(BindingList<Models.User> users)
        {
            _users = users;
            InitializeComponent();
        }

        private void btn_AddSubmit_Click(object sender, EventArgs e)
        {
            Models.User newUser = new Models.User() { Id = long.Parse(txt_UID.Text), Name = txt_UserName.Text };
            _users.Add(newUser);
        }

        private void btn_End_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
