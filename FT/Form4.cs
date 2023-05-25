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

namespace FT
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=GIAHUY;Initial Catalog=FTT;Integrated Security=True";


        SqlConnection cnn;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        DataTable table1 = new DataTable();

        public void loaddata()
        {
            command = cnn.CreateCommand();
            command.CommandText = "SELECT Maloaixe as 'Mã loại xe', Tenloaixe as 'Tên loại xe' FROM Loaixe";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        public void loaddata1()
        {
            command = cnn.CreateCommand();
            command.CommandText = "SELECT Machucvu as 'Mã chức vụ', Tenchucvu as 'Tên chức vụ' FROM Chucvu";
            adapter.SelectCommand = command;
            table1.Clear();
            adapter.Fill(table1);
            dataGridView2.DataSource = table1;

            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            loaddata();
            loaddata1();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Mở kết nối đến cơ sở dữ liệu
                connection.Open();

                string Machucvu = textBox3.Text;
                string Tenchucvu = textBox1.Text;
                using (SqlCommand command = new SqlCommand("INSERT INTO Chucvu (Machucvu, Tenchucvu) VALUES (@Machucvu, @Tenchucvu)", connection))
                {
                    command.Parameters.AddWithValue("@Machucvu", Machucvu);
                    command.Parameters.AddWithValue("@Tenchucvu", Tenchucvu);
                    try
                    {
                        // Thực thi câu lệnh SQL
                        command.ExecuteNonQuery();

                        // Đóng kết nối
                        connection.Close();

                        // Load lại dữ liệu
                        loaddata1();

                        MessageBox.Show("Thêm chức vụ thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Mở kết nối đến cơ sở dữ liệu
                connection.Open();

                string Maloaixe = textBox4.Text;
                string Tenloaixe = textBox2.Text;
                using (SqlCommand command = new SqlCommand("INSERT INTO Loaixe (Maloaixe, Tenloaixe) VALUES (@Maloaixe, @Tenloaixe)", connection))
                {
                    command.Parameters.AddWithValue("@Maloaixe", Maloaixe);
                    command.Parameters.AddWithValue("@Tenloaixe", Tenloaixe);
                    try
                    {
                        // Thực thi câu lệnh SQL
                        command.ExecuteNonQuery();

                        // Đóng kết nối
                        connection.Close();

                        // Load lại dữ liệu
                        loaddata();

                        MessageBox.Show("Thêm loại xe thành công!");
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

            string Machucvu = textBox3.Text;
            string Tenchucvu = textBox1.Text;
            string sql = "UPDATE chucvu SET  Tenchucvu = @Tenchucvu WHERE Machucvu = @Machucvu";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Machucvu", Machucvu);
            command.Parameters.AddWithValue("@Tenchucvu", Tenchucvu);
            connection.Open();

            // thực thi lệnh SQL
            command.ExecuteNonQuery();

            // đóng kết nối database

            connection.Close();

            // Load lại dữ liệu
            loaddata1();
            MessageBox.Show("Thay đổi thông tin thành công!");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string Maloaixe = textBox4.Text;
            string Tenloaixe = textBox2.Text;
            string sql = "UPDATE loaixe SET  Tenloaixe = @Tenloaixe WHERE Maloaixe = @Maloaixe";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Maloaixe", Maloaixe);
            command.Parameters.AddWithValue("@Tenloaixe", Tenloaixe);
            connection.Open();

            // thực thi lệnh SQL
            command.ExecuteNonQuery();

            // đóng kết nối database

            connection.Close();

            // Load lại dữ liệu
            loaddata();
            MessageBox.Show("Thay đổi thông tin thành công!");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView2.CurrentCell.RowIndex;
            textBox3.Text = dataGridView2.Rows[r].Cells[0].Value.ToString();
            textBox1.Text = dataGridView2.Rows[r].Cells[1].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            textBox4.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                command = cnn.CreateCommand();
                command.CommandText = "delete from chucvu  where Machucvu='" + textBox3.Text + "'";
                command.ExecuteNonQuery();
                loaddata1();
                MessageBox.Show("Xóa Thành Công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                command = cnn.CreateCommand();
                command.CommandText = "delete from loaixe  where Maloaixe='" + textBox4.Text + "'";
                command.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Xóa Thành Công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

