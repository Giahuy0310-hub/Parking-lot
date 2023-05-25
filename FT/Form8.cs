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
using TheArtOfDevHtmlRenderer.Adapters;

namespace FT
{
    public partial class Form8 : Form
    {
        public Form8()
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
            command.CommandText = " select  maphieu,maxe ,manv , magiave,giovao,tienthu from THONGKEPHIEUTHANHTOAN";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Tạo câu truy vấn SQL
            string query = "SELECT MALOAIXE AS 'MÃ LOẠI XE', SUM(TIENTHU) AS 'TỔNG TIỀN THU' FROM THONGKEPHIEUTHANHTOAN PTT JOIN XE X ON X.MAXE = PTT.MAXE GROUP BY MALOAIXE";

            // Tạo kết nối đến cơ sở dữ liệu và thực hiện truy vấn
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Tạo DataTable để chứa dữ liệu thống kê
                DataTable dt = new DataTable();

                // Thêm cột "Mã loại xe" và "Tổng số tiền đã thanh toán" vào DataTable
                dt.Columns.Add("Mã loại xe");
                dt.Columns.Add("Tổng số tiền đã thanh toán");

                // Đọc kết quả truy vấn và thêm các dòng chứa giá trị "Mã loại xe" và "Tổng số tiền đã thanh toán" vào DataTable
                while (reader.Read())
                {
                    object maloaixeValue = reader.GetValue(0);
                    if (maloaixeValue != DBNull.Value)
                    {
                        string maloaixe = (string)maloaixeValue;
                        float totalMoney = Convert.ToSingle(reader.GetValue(1));
                        MessageBox.Show("Tổng số tiền đã thanh toán cho loại xe " + maloaixe + " là: " + totalMoney.ToString("N0") + " đồng");
                        DataRow dr = dt.NewRow();
                        dr[0] = maloaixe;
                        dr[1] = totalMoney;
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin về số tiền đã thanh toán!");
                    }

                    // Gán DataTable làm DataSource cho DataGridView
                    dataGridView1.DataSource = dt;
                }
            }

        }
            private void Form8_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            loaddata();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;

        }
    }
}
