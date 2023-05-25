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

namespace FT
{
    public partial class Form2 : Form
    {
        public Form2()
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
            command.CommandText = "select * from Quanlynhanvien";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
      
         dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            loaddata();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {

            // Tạo đối tượng SqlConnection để kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Mở kết nối đến cơ sở dữ liệu
                connection.Open();



                string MaNV = textBox3.Text;
                string HoTen = textBox2.Text;
                string NgaySinh = textBox1.Text;
                string GioiTinh = comboBox1.Text;
                string DiaChi = textBox4.Text;
                string DienThoai = textBox5.Text;
                string MaChucvu = textBox6.Text;
                string Luong = textBox7.Text;

                // Tạo đối tượng SqlCommand để thực hiện câu lệnh INSERT
                using (SqlCommand command = new SqlCommand("INSERT INTO QuanLyNhanVien (MaNV, HoTen, NgaySinh, GioiTinh, DiaChi, DienThoai, MaChucvu, Luong) VALUES (@MaNV, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @DienThoai, @MaChucvu, @Luong)", connection))
                {
                    // Thêm tham số vào câu lệnh để tránh tấn công SQL Injection
                    command.Parameters.AddWithValue("@MaNV", MaNV);
                    command.Parameters.AddWithValue("@HoTen", HoTen);
                    command.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                    command.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                    command.Parameters.AddWithValue("@DiaChi", DiaChi);
                    command.Parameters.AddWithValue("@DienThoai", DienThoai);
                    command.Parameters.AddWithValue("@MaChucvu", MaChucvu);
                    command.Parameters.AddWithValue("@Luong", Luong);

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

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            string MaNV = textBox3.Text;
            string HoTen = textBox2.Text;
            string NgaySinh = textBox1.Text;
            string GioiTinh = comboBox1.Text;
            string DiaChi = textBox4.Text;
            string DienThoai = textBox5.Text;
            string MaChucvu = textBox6.Text;
            string Luong = textBox7.Text;

            // chuỗi lệnh SQL
            string sql = "UPDATE quanlynhanvien SET Hoten = @Hoten, Ngaysinh = @Ngaysinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi, MaChucvu = @MaChucvu, Luong = @Luong WHERE MaNV = @MaNV";

            SqlCommand command = new SqlCommand(sql, connection);
 
            command.Parameters.AddWithValue("@MaNV", MaNV);
            command.Parameters.AddWithValue("@HoTen", HoTen);
            command.Parameters.AddWithValue("@NgaySinh", NgaySinh);
            command.Parameters.AddWithValue("@GioiTinh", GioiTinh);
            command.Parameters.AddWithValue("@DiaChi", DiaChi);
            command.Parameters.AddWithValue("@DienThoai", DienThoai);
            command.Parameters.AddWithValue("@MaChucvu", MaChucvu);
            command.Parameters.AddWithValue("@Luong", Luong);

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            DateTime date = (DateTime)dataGridView1.Rows[r].Cells[2].Value;
            textBox1.Text = date.ToString("dd/MM/yyyy"); // định dạng ngày/tháng/năm
            textBox2.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[r].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[r].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[r].Cells[7].Value.ToString();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            try
            {
                command = cnn.CreateCommand();
                command.CommandText = "delete from quanlynhanvien  where MaNV='" + textBox3.Text + "'";
                command.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Xóa Thành Công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
     }
