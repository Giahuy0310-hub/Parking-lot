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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Data.OleDb;


namespace FT
{
    public partial class Form3 : Form
    {
        public Form3()
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
            command.CommandText = "SELECT MaViTri as 'Mã vị trí', TenViTri as 'Tên vị trí', Maxe as 'Mã xe' FROM Vitri";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;



            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

      

        private void DisplayProductQuantity()
        {
            // Thiết lập chuỗi kết nối CSDL


            // Tạo kết nối đến CSDL
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // Truy vấn CSDL để tính tổng số lượng sản phẩm theo loại hàng
            string query = "select lx.Tenloaixe,Count(vitri.maxe ) as totalQuantity " +
                            "from loaixe lx " +
                            "join xe on lx.Maloaixe = xe.Maloaixe " +
                            "join vitri on vitri.Maxe = xe.Maxe " +
                            "GROUP BY lx.Tenloaixe";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            // Hiển thị số lượng sản phẩm theo từng loại hàng trên các button tương ứng
            while (reader.Read())
            {
                string categoryName = reader.GetString(0);
                int totalQuantity = reader.GetInt32(1);

                if (categoryName == "Ô tô")
                {
                    button1.Text = "(" + totalQuantity.ToString() + ")";
                }
                else if (categoryName == "Xe máy")
                {
                    button2.Text = "(" + totalQuantity.ToString() + ")";
                }
                
            }

            // Đóng kết nối và giải phóng tài nguyên
            loaddata();
            reader.Close();
            command.Dispose();
            connection.Close();

        }
        private void guna2Button3_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            string connStringg = "Data Source=GIAHUY;Initial Catalog=FTT;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connStringg);

            string sql = "SELECT MaViTri as 'Mã vị trí', TenViTri as 'Tên vị trí', Maxe as 'Mã xe' FROM Vitri WHERE MaXe = @maxe";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@maxe", textBox4.Text.Trim());
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dtbTimKiem = new DataTable();
            int count = dataAdapter.Fill(dtbTimKiem);
            if (count == 0)
            {
                MessageBox.Show("Không tìm thấy xe phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView1.DataSource = dtbTimKiem;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string MaViTri = textBox3.Text;
            string TenViTri = textBox1.Text;
            string Maxe = textBox2.Text;

            string sql = "UPDATE vitri SET TenViTri = @TenViTri, Maxe = @Maxe WHERE MaViTri = @MaViTri";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MaViTri", MaViTri);
            command.Parameters.AddWithValue("@TenViTri", TenViTri);
            command.Parameters.AddWithValue("@Maxe", Maxe);


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

        private void Form3_Load_1(object sender, EventArgs e)
        {
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            loaddata();
            DisplayProductQuantity();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;

            textBox1.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}