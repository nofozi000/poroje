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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            //form backcolor
            this.BackColor = Color.FromArgb(67, 205, 226);
        
        }
        
        //open other form METHOD
        public void otherForm(Form form)
        {
            this.Hide();
            form.ShowDialog();
            this.Hide();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            //create captcha code
            pictureBox1.Image = ClassCaptcha.createImage();
        }

        //btn new code
        private void button1_Click(object sender, EventArgs e)
        {
            //create captcha code
            pictureBox1.Image = ClassCaptcha.createImage();
        }

        //btn login
        int counter = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text=="")&& (textBox2.Text == ""))
            {
                FormSignUp fsu = new FormSignUp();
                otherForm(fsu);
            }
            else
            { 
            dc_Airplane dc = new dc_Airplane();
            var user = (from u in dc.User
                        where u.Username == textBox1.Text
                        select u).FirstOrDefault();
                if (user == null)
                {
                    MessageBox.Show("نام کاربری وارد شده در سیستم موجود نمی باشد.",
                        "WrongUserName", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    counter++;
                }
                else
                {
                    if (user.PassWord == textBox2.Text)
                    {
                        if (ClassCaptcha.validate(textBox3.Text))
                        {
                            switch (user.TypeId)
                            {
                                case 1:
                                    {
                                        FormManager fm = new FormManager();
                                        otherForm(fm);
                                        break;
                                    }
                                case 2:
                                    {
                                        FormCompany fc = new FormCompany();
                                        otherForm(fc);
                                        break;
                                    }
                                case 3:
                                    {
                                        FormOperator fo = new FormOperator(user.Id);
                                        otherForm(fo);
                                        break;
                                    }
                                default:
                                    MessageBox.Show("نوع کاربری کاربر مورد نظر صحیح نمی باشد.",
                                        "WrongPassWord", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    break;
                            }


                        }
                        else
                            MessageBox.Show("کد امنیتی وارد شده صحیح نمی باشد."
                                , "WrongCaptchaCode", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                      else
                            MessageBox.Show("رمزعبور وارد شده صحیح نمی باشد."
                                , "WrongCaptchaCode", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                if (counter > 2)
                {
                    panel1.Enabled = false;
                    timer1.Enabled = true;
                    label1.Visible = true;
                    counter = 0;
                    second = 30;
                }
            }
        }

        //btn logout
        private void button3_Click(object sender, EventArgs e)
        {
            FormMainMenu fmm = new FormMainMenu();
            otherForm(fmm);
        }

        int second = 30;
        private void timer1_Tick(object sender, EventArgs e)
        {
            second--;
            label1.Text = "ثانیه تا باز شدن صفحه " + second.ToString();
            if (second==0)
            {
                panel1.Enabled = true;
                label1.Visible = false;
                timer1.Enabled = false;
            }
        }
    }
}
