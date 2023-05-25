using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FT
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=GIAHUY;Initial Catalog=FTT;Integrated Security=True";


        SqlConnection cnn;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public void loaddata()
        {
            command = cnn.CreateCommand();
            command.CommandText = "SELECT * FROM Quanlygiave";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;



            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
   

      
        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
           

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string MaGiave = textBox3.Text;
            string TenGiaVe = textBox1.Text;
            string GiaVe = textBox2.Text;
            string MaloaiXe = comboBox1.Text;
            string Giogiuxe = textBox4.Text;
  

            // chuỗi lệnh SQL
            string sql = "UPDATE quanlygiave SET  TenGiaVe = @TenGiaVe, GiaVe = @GiaVe, MaloaiXe = @MaloaiXe, Giogiuxe = @Giogiuxe WHERE MaGiave = @MaGiave";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MaGiave", MaGiave);
            command.Parameters.AddWithValue("@TenGiaVe", TenGiaVe);
            command.Parameters.AddWithValue("@GiaVe", GiaVe);
            command.Parameters.AddWithValue("@MaloaiXe", MaloaiXe);
            command.Parameters.AddWithValue("@Giogiuxe", Giogiuxe);


            // mở kết nối database
            connection.Open();

            // thực thi lệnh SQL
            command.ExecuteNonQuery();

            // đóng kết nối database

            connection.Close();

            // Load lại dữ liệu
            loaddata();
            MessageBox.Show("Thay đổi thông tin thành công!");
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Mở kết nối đến cơ sở dữ liệu
                connection.Open();


                string MaGiave = textBox3.Text;
            string TenGiaVe = textBox1.Text;
            string GiaVe = textBox2.Text;
            string MaloaiXe = comboBox1.Text;
            string Giogiuxe = textBox4.Text;

            // chuỗi lệnh SQL
            using (SqlCommand command = new SqlCommand("INSERT INTO QuanLyGiave (MaGiave, TenGiaVe, GiaVe, MaloaiXe, Giogiuxe) VALUES (@MaGiave, @TenGiaVe, @GiaVe, @MaloaiXe, @Giogiuxe)", connection))
            {



                command.Parameters.AddWithValue("@MaGiave", MaGiave);
                command.Parameters.AddWithValue("@TenGiaVe", TenGiaVe);
                command.Parameters.AddWithValue("@GiaVe", GiaVe);
                command.Parameters.AddWithValue("@MaloaiXe", MaloaiXe);
                command.Parameters.AddWithValue("@Giogiuxe", Giogiuxe);


                try
                {
                    // Thực thi câu lệnh SQL
                    command.ExecuteNonQuery();

                    // Đóng kết nối
                    connection.Close();

                    // Load lại dữ liệu
                    loaddata();

                    MessageBox.Show("Thêm nhân viên thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }

    private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                command = cnn.CreateCommand();
                command.CommandText = "delete from quanlygiave  where Magiave='" + textBox3.Text + "'";
                command.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Xóa Thành Công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[r].Cells[4].Value.ToString();
        }

        private void Form5_Load_1(object sender, EventArgs e)
        {
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            loaddata();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
