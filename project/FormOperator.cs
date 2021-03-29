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
    public partial class FormOperator : Form
    {
        int idu = 0;
        public FormOperator(int id)
        {
            InitializeComponent();
            //form backcolor
            this.BackColor = Color.FromArgb(67, 205, 226);
            idu = id;
        }

        private void FormOperator_Load(object sender, EventArgs e)
        {
            //show user types in combobox
            dc_Airplane dc = new dc_Airplane();
            var items = from t in dc.UserType
                        select t.Name;
            comboBox1.DataSource = items.ToList();

            //fill the fields
            var userItems = (from u in dc.User
                         where u.Id == idu
                         select u).FirstOrDefault();
            textBox1.Text = userItems.FullName.ToString();
            dateTimePicker1.Value = userItems.Birthdate.Value;
            textBox4.Text = userItems.Username.ToString();
        }

        //Method not be null
        private void notBeNull(TextBox textBox, Label label)
        {
            if (textBox.Text == "")
            {
                label.Visible = true;
            }
            else
            {
                label.Visible = false;
            }
        }

        //Method age under 12y 6m
        private bool userAge(DateTime UserDateTime)
        {
            DateTime NowDateTime = DateTime.Today;
            TimeSpan time = NowDateTime - UserDateTime;
            if (time.Days > 4563)
            {
                return true;
            }
            else
                return false;
        }

        //Method labels
        private void redLabels(Label label, bool TF)
        {
            label.Visible = TF;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text=="") || (textBox2.Text=="")||
                (textBox3.Text==""))
            {
                //not be null for textboxes
                notBeNull(textBox1, label7);
                notBeNull(textBox2, label8);
                notBeNull(textBox3, label9)
                    ;
                redLabels(label13, false);
                redLabels(label14, false);
            }
            else if (textBox3.Text != textBox2.Text)
            {
                redLabels(label13, true);
                redLabels(label14, false);
            }
            else if (userAge(dateTimePicker1.Value)==false)
            {
                redLabels(label13, false);
                redLabels(label14, true);
            }
            else
            {
                redLabels(label13, false);
                redLabels(label14, false);
                if (ClassEditUserPassword.validPassword(textBox2.Text))
                {
                    dc_Airplane dc = new dc_Airplane();
                    var items = (from u in dc.User
                                 where u.Id == idu
                                 select u).FirstOrDefault();
                    items.FullName = textBox1.Text;
                    items.Birthdate = dateTimePicker1.Value;
                    items.PassWord = textBox2.Text;
                    var usertypeid = (from t in dc.UserType
                                      where t.Name == comboBox1.Text
                                      select t).FirstOrDefault();
                    items.TypeId = usertypeid.Id;
                    dc.SaveChanges();
                }
            }
        }
    }
}
