using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FT
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
        public void UpdateData(string maphieu, string maxe, string manv, string maGiaVe, string giovao, string sogiogiu1, string tienthu)
        {
            label2.Text = "Mã phiếu: " + maphieu;
            label3.Text = "MÃ XE: " + maxe;
            label4.Text = "MÃ NHÂN VIÊN: " + manv;
            label5.Text = "MÃ GIÁ VÉ: " + maGiaVe;
            label6.Text = "GIỜ VÀO: " + giovao;
            label7.Text = "SỐ GIỜ GIỮ: " + sogiogiu1;
            label8.Text = "TIỀN THU: " + tienthu;
            label9.Text = "XUẤT HÓA ĐƠN LÚC : " + DateTime.Now.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thanh toán không?", "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form7.Instance.DeleteSelectedRow();
                MessageBox.Show("Thanh toán thành công!");
                this.Close();
            }
            else
            {
                // Hủy thanh toán
            }
        }

        private void Form6_Load_1(object sender, EventArgs e)
        {

        }
    }
}
