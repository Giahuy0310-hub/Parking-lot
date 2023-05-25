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
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static FT.Mainclass;

namespace FT
{
    public partial class Form7 : Form
    {
        public static Form7 Instance;
        public Form7()
        {
            InitializeComponent();
            Instance = this;

        }
        string connectionString = "Data Source=GIAHUY;Initial Catalog=FTT;Integrated Security=True";


        SqlConnection cnn;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public void loaddata()
        {
            command = cnn.CreateCommand();
            command.CommandText = "SELECT *  FROM Phieuthanhtoan";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            loaddata();

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Mở kết nối đến cơ sở dữ liệu
                connection.Open();

                string Maphieu = textBox1.Text;
                string Maxe = textBox2.Text;
                //    string TienthuStr = textBox4.Text;
                string MaNV = textBox3.Text;

                //float Tienthu;
                //if (!float.TryParse(TienthuStr, out Tienthu))
                //{
                //    MessageBox.Show("Giá trị tiền thu không hợp lệ!");
                //    return;
                //}

                // Lấy giờ hiện tại
                DateTime now = DateTime.Now;
                string Giovao = now.ToString("yyyy-MM-dd HH:mm:ss");
                textBox4.Text = Giovao;

                //string Giora = textBox5.Text;
                using (SqlCommand command = new SqlCommand("INSERT INTO Phieuthanhtoan ( Maxe, MaNV,Giovao) VALUES ( @Maxe, @MaNV,@Giovao)", connection))
                {
                    command.Parameters.AddWithValue("@Maphieu", Maphieu);
                    command.Parameters.AddWithValue("@Maxe", Maxe);
                    //  command.Parameters.AddWithValue("@Tienthu", Tienthu);
                    command.Parameters.AddWithValue("@MaNV", MaNV);
                    command.Parameters.AddWithValue("@Giovao", Giovao);

                    //command.Parameters.AddWithValue("@Giora", Giora);
                    try
                    {
                        // Thực thi câu lệnh SQL
                        command.ExecuteNonQuery();

                        // Đóng kết nối
                        connection.Close();

                        // Load lại dữ liệu
                        loaddata();

                        MessageBox.Show("Thêm phiếu thanh toán thành công!");
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
            textBox1.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[r].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[r].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[r].Cells[7].Value.ToString();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=GIAHUY;Initial Catalog=FTT;Integrated Security=True";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string MaPhieu = textBox1.Text;
                string MaXe = textBox2.Text;
                string MaNV = textBox3.Text;

                // Lấy giờ hiện tại
                DateTime now = DateTime.Now;
                string GioVao = now.ToString("yyyy-MM-dd HH:mm:ss");


                DateTime now1 = DateTime.Now;
                string Giora = now1.ToString("yyyy-MM-dd HH:mm:ss");
                textBox5.Text = Giora;

                TimeSpan duration = now - now1;
                decimal Giogiuxe = (decimal)duration.TotalHours;
                if (Giogiuxe < 0)
                {
                    Giogiuxe = 0; // set giá trị số giờ giữ là 0 nếu nó nhỏ hơn 0
                }
                else
                {
                    Giogiuxe = (decimal)Math.Ceiling(Giogiuxe); // làm tròn giá trị số giờ giữ lên và kiểm tra lại
                }
                textBox7.Text = Giogiuxe.ToString();

                float GiaVe = 0;
                string MaGiaVe = "";
                string tienthu = "";
                int sogiogiu = 0;
                string commandString = "";

                if (MaXe.StartsWith("OT"))
                {
                    if (Giogiuxe <= 9)
                    {
                        MaGiaVe = "GV01";
                    }
                    else
                    {
                        MaGiaVe = "GV02";
                    }
                }
                else if (MaXe.StartsWith("XM"))
                {
                    if (Giogiuxe <= 9)
                    {
                        MaGiaVe = "GV03";
                    }
                    else
                    {
                        MaGiaVe = "GV04";
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã xe phù hợp!");
                    return;
                }

                // Lấy giá vé từ cơ sở dữ liệu
                commandString = "SELECT Giave FROM quanlygiave WHERE MaGiaVe = @MaGiaVe";
                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@MaGiaVe", MaGiaVe);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            object value = reader.GetValue(0);
                            if (float.TryParse(value.ToString(), out float result))
                            {
                                GiaVe = result;
                            }
                            else
                            {
                                MessageBox.Show("Giá vé không hợp lệ!");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy mã giá vé phù hợp!");
                            return;
                        }
                    }
                }

                // Tính tiền thu
                tienthu = (GiaVe).ToString();

                DateTime Giovao;
                if (!DateTime.TryParse(textBox4.Text, out Giovao))
                {
                    MessageBox.Show("Giá trị giờ vào không hợp lệ!");
                    return;
                }
                // Thực hiện thanh toán
                // Thực hiện thanh toán
                commandString = "INSERT INTO ThongKePhieuThanhToan (MaXe, MaGiaVe, MaNV,Giovao,Giora,Sogiogiu,Tienthu ) VALUES (@MaXe, @MaGiaVe, @MaNV,@Giovao,@Giora,@Sogiogiu,@Tienthu)";
                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    // command.Parameters.AddWithValue("@MaPhieu", MaPhieu);
                    command.Parameters.AddWithValue("@MaXe", MaXe);
                    command.Parameters.AddWithValue("@MaGiaVe", MaGiaVe);
                    command.Parameters.AddWithValue("@MaNV", MaNV);
                    command.Parameters.AddWithValue("@Giovao", Giovao);
                    command.Parameters.AddWithValue("@Giora", Giora);
                    command.Parameters.AddWithValue("@Sogiogiu", Giogiuxe);
                    command.Parameters.AddWithValue("@Tienthu", GiaVe);

                    try
                    {
                        // Thực thi câu lệnh SQL
                        command.ExecuteNonQuery();

                        // Đóng kết nối

                        // Load lại dữ liệu
                        loaddata();



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                commandString = "UPDATE PhieuThanhToan SET MaGiaVe = @MaGiaVe, MaNV = @MaNV, Giovao = @Giovao, Giora = @Giora, Sogiogiu = @Sogiogiu, Tienthu = @Tienthu WHERE MaXe = @MaXe";
                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@MaXe", MaXe);
                    command.Parameters.AddWithValue("@MaGiaVe", MaGiaVe);
                    command.Parameters.AddWithValue("@MaNV", MaNV);
                    command.Parameters.AddWithValue("@Giovao", Giovao);
                    command.Parameters.AddWithValue("@Giora", Giora);
                    command.Parameters.AddWithValue("@Sogiogiu", Giogiuxe);
                    command.Parameters.AddWithValue("@Tienthu", GiaVe);
                    try
                    {
                        // Thực thi câu lệnh SQL
                        command.ExecuteNonQuery();

                        // Đóng kết nối
                        connection.Close();

                        // Load lại dữ liệu
                        loaddata();

                        MessageBox.Show("Thêm phiếu thanh toán thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;

            // Lấy các giá trị cần truyền sang Form6
            string maphieu = row.Cells["maphieu"].Value.ToString();
            string maxe = row.Cells["maxe"].Value.ToString();
            string manv = row.Cells["manv"].Value.ToString();
            string maGiaVe = row.Cells["MaGiave"].Value.ToString();
            string giovao = row.Cells["giovao"].Value.ToString();
            string sogiogiu1 = row.Cells["sogiogiu"].Value.ToString();
            string giave = row.Cells["tienthu"].Value.ToString();
            // Hiển thị thông tin trên Form6
            // Khởi tạo Form6 và gọi phương thức UpdateData để thiết lập dữ liệu
            Form6 form6 = new Form6();
            form6.UpdateData(maphieu, maxe, manv, maGiaVe, giovao, sogiogiu1, giave);
            form6.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string Maphieu  = textBox1.Text;
            string MaXe     = textBox2.Text;
            string MaNV     = textBox3.Text;



            // chuỗi lệnh SQL
            string sql = "UPDATE phieuthanhtoan SET  MaXe = @MaXe, MaNV = @MaNV  WHERE Maphieu = @Maphieu";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Maphieu", Maphieu);
            command.Parameters.AddWithValue("@MaXe", MaXe);
            command.Parameters.AddWithValue("@MaNV", MaNV);


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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                command = cnn.CreateCommand();
                command.CommandText = "delete from phieuthanhtoan  where Maphieu='" + textBox1.Text + "'";
                command.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Xóa Thành Công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataGridView DataGridView1 { get { return dataGridView1; } }


        private int selectedRowIndex;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
            }
        }
        public void DeleteSelectedRow()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows.RemoveAt(rowIndex);
            }
        }
    }
}


         
 