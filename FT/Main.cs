using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FT
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenchildForm(new Form9());

        }



        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {


        }
        private Form currentFormChild;

        private void OpenchildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;

            if (Mainclass.USER.StartsWith("abc"))
            {
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                guna2Panel3.Controls.Add(childForm);
                guna2Panel3.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
            else if (childForm is Form3 || childForm is Form8 || childForm is Form7 || childForm is Form6 || childForm is Form9)
            {
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                guna2Panel3.Controls.Add(childForm);
                guna2Panel3.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
            else
            {
                MessageBox.Show("Bạn là nhân viên !");
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenchildForm(new Form2());

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            //if (ChucVu.USERS == "1")
            //{
            //    // Người dùng thuộc nhóm CV1
            //    OpenchildForm(new Form1());
            //    OpenchildForm(new Form2());
            //    OpenchildForm(new Form3());
            //    OpenchildForm(new Form4());
            //    OpenchildForm(new Form5());
            //    OpenchildForm(new Form6());
            //    OpenchildForm(new Form7());
            //    OpenchildForm(new Form8());
            //    OpenchildForm(new Form9());
            //    OpenchildForm(new Form10());


            //}
            //else if (ChucVu.USERS == "2")
            //{
            //    // Người dùng thuộc nhóm CV2
            //    OpenchildForm(new Form2());g
            //    OpenchildForm(new Form4());
            //    OpenchildForm(new Form5());
            //    OpenchildForm(new Form9());
            OpenchildForm(new Form9());
            label1.Text = Mainclass.USER;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenchildForm(new Form3());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận trước khi thoát ứng dụng
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thoát khỏi ứng dụng không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            OpenchildForm(new Form4());

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            OpenchildForm(new Form5());

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            OpenchildForm(new Form7());

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            OpenchildForm(new Form8());
        }

      

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            OpenchildForm(new Form10());

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
