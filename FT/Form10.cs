using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace FT
{
    public partial class Form10 : Form
    {
        string connectionString = "Data Source=GIAHUY;Initial Catalog=FTT;Integrated Security=True";


        SqlConnection cnn;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        DataTable table1 = new DataTable();

        public void loaddata()
        {
            command = cnn.CreateCommand();
            command.CommandText = "SELECT * FROM LOGIN";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        public Form10()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Mở kết nối đến cơ sở dữ liệu
                connection.Open();

                string USERNAME = guna2TextBox1.Text;
                string PASSWORD = guna2TextBox2.Text;
                string MACHUCVU = guna2TextBox3.Text;
                using (SqlCommand command = new SqlCommand("INSERT INTO LOGIN (USERNAME, PASSWORD, MACHUCVU) VALUES (@USERNAME, @PASSWORD, @MACHUCVU)", connection))
                {

                    command.Parameters.AddWithValue("@USERNAME", USERNAME);
                    command.Parameters.AddWithValue("@PASSWORD", PASSWORD);
                    command.Parameters.AddWithValue("@MACHUCVU", MACHUCVU);

                    try
                    {
                        // Thực thi câu lệnh SQL
                        command.ExecuteNonQuery();

                        // Đóng kết nối
                        connection.Close();

                        // Load lại dữ liệu
                        loaddata();

                        MessageBox.Show("Thêm thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            guna2TextBox1.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
            guna2TextBox2.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
            guna2TextBox3.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();

        }

        private void Form10_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            loaddata();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);


            string USERNAME = guna2TextBox1.Text;
            string PASSWORD = guna2TextBox2.Text;
            string MACHUCVU = guna2TextBox3.Text;

            string sql = "UPDATE LOGIN SET  PASSWORD = @PASSWORD , MACHUCVU = @MACHUCVU WHERE USERNAME = @USERNAME";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERNAME", USERNAME);
            command.Parameters.AddWithValue("@MACHUCVU", MACHUCVU);
            command.Parameters.AddWithValue("@PASSWORD", PASSWORD);
            connection.Open();

            // thực thi lệnh SQL
            command.ExecuteNonQuery();

            // đóng kết nối database

            connection.Close();

            // Load lại dữ liệu
            loaddata();
            MessageBox.Show("Thay đổi thông tin thành công!");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                command = cnn.CreateCommand();
                command.CommandText = "delete from LOGIN  where USERNAME='" + guna2TextBox1.Text + "'";
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

