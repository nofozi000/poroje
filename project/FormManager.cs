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
    public partial class FormManager : Form
    {
        public FormManager()
        {
            InitializeComponent();
            //form backcolor
            this.BackColor = Color.FromArgb(67, 205, 226);
        }

        //Method Connect
        private void connect()
        {
            //column name
            dc_Airplane dc = new dc_Airplane();
            var UserNameItems = dc.User.Select(x => new { x.FullName });
            dataGridView1.DataSource = UserNameItems.ToList();

            //column pic
            var items = dc.tbl_employee.Select(x => new { x.e_pic }).ToList();
            int i = 0;
            foreach (var it in items)
            {
                dataGridView1.Rows[i].Cells[0].Value =
                 Image.FromFile(@"..\pic\" + it.e_pic.ToString());
                i++;
            }
        }
        
        private void FormManager_Load(object sender, EventArgs e)
        {
            connect();
        }

        //search
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //column name
            dc_Airplane dc = new dc_Airplane();
            var itemName = from u in dc.User
                           where u.FullName.Contains(textBox1.Text)
                           select new { u.FullName };
            dataGridView1.DataSource = itemName.ToList();

            //pic
            var itemPic = from u in dc.User
                          join m in dc.tbl_employee
                          on u.Id equals m.idu
                          where u.FullName.Contains(textBox1.Text)
                          select new { m.e_pic };
            int i = 0;
            foreach (var it in itemPic)
            {
                dataGridView1.Rows[i].Cells[0].Value =
               Image.FromFile(@"..\pic\" + it.e_pic.ToString());
                i++;
            }

            //if textbox was null
            if (textBox1.Text=="")
            {
                connect();
            }
        }

        int id = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (id==0)
            {
                MessageBox.Show("لطفا دوباره انتخاب کنید","IdIsNull",
                    MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
            else 
                id=int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dc_Airplane dc = new dc_Airplane();
            var items = (from u in dc.User
                         where u.Id == id
                         select u).FirstOrDefault();
            dc.User.Remove(items);
            dc.SaveChanges();
            connect();
        }
    }
}
