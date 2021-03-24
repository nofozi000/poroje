using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class FormMainMenu : Form
    {
        public FormMainMenu()
        {
            InitializeComponent();
            //form backcolor
            this.BackColor = Color.FromArgb(67, 205, 226);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Display time per second
            DateTime dateTime = DateTime.Now;
            label2.Text = dateTime.ToString("hh:mm");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //go to login form
            FormLogin fl = new FormLogin();
            this.Hide();
            fl.ShowDialog();
            this.Close();
        }
    }
}
