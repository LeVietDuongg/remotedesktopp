using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Bai05
{
    public partial class Client : Form
    {
        private const string ServerIP = "127.0.0.1";
        private const int ServerPort = 8080;

        public Client()
        {
            InitializeComponent();
        }

        private void btnGuiDuLieu_Click(object sender, EventArgs e)
        {
            SendDataToServer();
        }

        private async void SendDataToServer()
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    await client.ConnectAsync(ServerIP, ServerPort);
                    NetworkStream? stream = client.GetStream();

                    if (stream != null)
                    {
                        StreamWriter? writer = new StreamWriter(stream);
                        StreamReader? reader = new StreamReader(stream);

                        // Đọc dữ liệu ảnh từ file
                        byte[] imageBytes = File.ReadAllBytes(txtHinhAnhName.Text);

                        // Chuyển đổi dữ liệu ảnh thành chuỗi Base64
                        string imageBase64 = Convert.ToBase64String(imageBytes);

                        // Tạo chuỗi dữ liệu để gửi lên server
                        string data = "MonAnFromClient," + txtTenMonAn.Text + "," + txtTenNguoiDung.Text + "," + imageBase64;
                        if (writer != null)
                        {
                            await writer.WriteLineAsync(data);
                            await writer.FlushAsync();

                            // Wait for response from server
                            if (reader != null)
                            {
                                string? response = await reader.ReadLineAsync();
                                if (response != null)
                                {
                                    MessageBox.Show(response); // Hiển thị phản hồi từ server

                                    // Xóa thông tin đã nhập
                                    txtTenMonAn.Text = string.Empty;
                                    txtTenNguoiDung.Text = string.Empty;
                                    txtHinhAnhName.Text = string.Empty;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Hình ảnh|*.jpg;*.png";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtHinhAnhName.Text = openFile.FileName;
                btnAnh.Hide();
            }
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void txtTenNguoiDung_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenMonAn_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
