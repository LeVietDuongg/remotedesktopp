using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03Bai5
{
    public partial class Client : Form
    {
        Socket clientSocket;
        public Client()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Gửi yêu cầu để lấy món ăn ngẫu nhiên từ cộng đồng
                string message = "Randomcongdong;";
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                await clientSocket.SendAsync(new ArraySegment<byte>(buffer), SocketFlags.None);

                // Nhận và hiển thị món ăn từ Server
                string randomFoodFromCommunity = await ReceiveResponseAsync();
                textBox3.Text = randomFoodFromCommunity;
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();

                // Mở kết nối mới
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(IPAddress.Parse("127.0.0.1"), 8080);
            }
            catch
            {
                MessageBox.Show("Không gửi tin đi được", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Gửi yêu cầu để lấy món ăn do người đóng góp đóng góp
                string message = "Randomdonggop;" + textBox2.Text;
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                await clientSocket.SendAsync(new ArraySegment<byte>(buffer), SocketFlags.None);

                // Nhận và hiển thị món ăn từ Server
                string randomFoodFromContributor = await ReceiveResponseAsync();
                textBox3.Text = randomFoodFromContributor;
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();

                // Mở kết nối mới
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(IPAddress.Parse("127.0.0.1"), 8080);
            }
            catch
            {
                MessageBox.Show("Không gửi tin đi được", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<string> ReceiveResponseAsync()
        {
            byte[] buffer = new byte[1024];
            int bytesRead = await clientSocket.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
            string text = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            return text;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "ContributeFood;" + textBox1.Text + ";" + textBox2.Text;
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                await clientSocket.SendAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
                textBox1.Clear();
                textBox2.Clear();
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();

                // Mở kết nối mới
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(IPAddress.Parse("127.0.0.1"), 8080);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(IPAddress.Parse("127.0.0.1"), 8080);
        }
    }
}
