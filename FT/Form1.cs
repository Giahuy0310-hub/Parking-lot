namespace FT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận trước khi thoát ứng dụng
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thoát khỏi ứng dụng không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Đóng form hiện tại và thoát khỏi ứng dụng
                this.Close();
                Application.Exit();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" && guna2TextBox2.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tài khoản mật khẩu!");
                return;
            }
            if (Mainclass.IsValidUser(guna2TextBox1.Text, guna2TextBox2.Text) == false)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!");
            }

            else
            {
                this.Hide();
                Main frm = new Main();
                frm.Show();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                guna2TextBox2.PasswordChar = '\0'; // Hiển thị mật khẩu
            }
            else
            {
                guna2TextBox2.PasswordChar = '●'; // Ẩn mật khẩu
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}