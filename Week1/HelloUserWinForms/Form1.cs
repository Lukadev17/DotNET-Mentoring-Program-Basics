using HelloUserClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloUserWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void helloUserButton_Click(object sender, EventArgs e)
        {
            string username = helloUserTextBox.Text;
            string message = HelloUserService.HelloUser(username);
            MessageBox.Show(message, "Greeting");
        }
    }
}
