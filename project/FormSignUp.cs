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
    public partial class FormSignUp : Form
    {
        public FormSignUp()
        {
            InitializeComponent();
            //form backcolor
            this.BackColor = Color.FromArgb(67, 205, 226);

        }

        private void FormSignUp_Load(object sender, EventArgs e)
        {
            //show user types in combobox
            dc_Airplane dc = new dc_Airplane();
            var items = from t in dc.UserType
                        select t.Name ;
            comboBox1.DataSource = items.ToList();
        }

        //Method not be null
        private void notBeNull(TextBox textBox,Label label)
        {
            if (textBox.Text=="")
            {
                label.Visible = true;
            }
            else
            {
                label.Visible = false;
            }
        }

        //Method age under 18
        private bool userAge(DateTime UserDateTime)
        {
            DateTime NowDateTime = DateTime.Today;
            TimeSpan time = NowDateTime - UserDateTime;
            if (time.Days > 6570)
            {
                return true;
            }
            else
                return false;
        }

        //Method labels
        private void redLabels(Label label , bool TF)
        {
            label.Visible = TF;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == "") ||
                (textBox3.Text == "") || (textBox4.Text == ""))
            {
                //not be null for textboxes
                notBeNull(textBox1, label7);
                notBeNull(textBox2, label8);
                notBeNull(textBox3, label9);
                notBeNull(textBox4, label10);

                redLabels(label12, false);
                redLabels(label13, false);
                redLabels(label14, false);
            }
            else if (textBox4.Text.Length <= 5)
            {
                redLabels(label12, true);
                redLabels(label13, false);
                redLabels(label14, false);

            }
            else if (textBox3.Text!=textBox2.Text)
            {
                redLabels(label12, false);
                redLabels(label13, true);
                redLabels(label14, false);
            }
            else if (userAge(dateTimePicker1.Value)==false)
            {
                redLabels(label12, false);
                redLabels(label13, false);
                redLabels(label14, true);
            }
            else
            {
                redLabels(label12, false);
                redLabels(label13, false);
                redLabels(label14, false);
                if (ClassValidPassword.validPassWord(textBox2.Text))
                {
                    dc_Airplane dc = new dc_Airplane();
                    User tbU = new User();
                    tbU.FullName = textBox1.Text;
                    tbU.Birthdate = dateTimePicker1.Value;
                    tbU.PassWord = textBox2.Text;
                    tbU.Username = textBox4.Text;
                    var items = (from t in dc.UserType
                                 where t.Name == comboBox1.Text
                                 select t).FirstOrDefault();
                    tbU.TypeId = tbU.Id;
                    dc.User.Add(tbU);
                    dc.SaveChanges();

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    dateTimePicker1.ResetText();
                }
            }
        }
    }
}
