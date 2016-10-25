using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Stambar
{
    public partial class LogInForm : Form {

        private Admin[] names;

        public LogInForm(Admin[] admins) {
            InitializeComponent();

            this.names = admins;
            foreach(Admin a in admins){
                userBox.Items.Add(a.name);
            }
        }

        private void LogInForm_Load(object sender, EventArgs e) {

        }

        public Admin getSelectedAdmin()
        {
            return names[userBox.SelectedIndex];
        }

        public String getPIN()
        {
            return pinBox.Text;
        }
    }
}