using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Lab03Bai5
{
    public partial class Server : Form
    {
        static string connectionString = "Data Source=food_database.db;Version=3;";
        Socket serverSocket;
        private CancellationTokenSource cancellationTokenSource;
        public Server()
        {
            InitializeComponent();
        }

        // Hàm xử lý kết nối từ một client cụ thể
        private void HandleClient(Socket clientSocket)
        {
            byte[] buffer = new byte[1024];
            int bytesRead = clientSocket.Receive(buffer);
            string text = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            string[] tach = text.Split(';');

            string serverResponse = "";
            if (tach[0] == "ContributeFood")
            {
                if (tach.Length == 3)
                {
                    string foodName = tach[1].Trim();
                    string contributorName = tach[2].Trim();
                    AddFood(foodName, contributorName);
                }
            }
            else if (tach[0] == "Randomcongdong")
            {
                serverResponse = RandomFoodFromCommunity();
                byte[] sendBytes = Encoding.UTF8.GetBytes(serverResponse);
                clientSocket.Send(sendBytes);

            }
            else if (tach[0] == "Randomdonggop")
            {
                if (tach.Length == 2)
                {
                    string contributorName = tach[1].Trim();
                    serverResponse = RandomFoodFromContributor(contributorName);
                    byte[] sendBytes = Encoding.UTF8.GetBytes(serverResponse);
                    clientSocket.Send(sendBytes);
                }
                else
                {
                    serverResponse = "Invalid contributor request format";
                    byte[] sendBytes = Encoding.UTF8.GetBytes(serverResponse);
                    clientSocket.Send(sendBytes);
                }
            }
            else
            {
                serverResponse = "Invalid request";
                byte[] sendBytes = Encoding.UTF8.GetBytes(serverResponse);
                clientSocket.Send(sendBytes);
            }
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
        static void CreateDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string createTableQuery = @"CREATE TABLE IF NOT EXISTS Foods (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Name TEXT NOT NULL,
                                            Contributor TEXT NOT NULL)";
                SQLiteCommand command = new SQLiteCommand(createTableQuery, conn);
                command.ExecuteNonQuery();
            }
        }

        static void AddFood(string foodName, string contributorName)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string insertQuery = "INSERT INTO Foods (Name, Contributor) VALUES (@Name, @Contributor)";
                SQLiteCommand command = new SQLiteCommand(insertQuery, conn);
                command.Parameters.AddWithValue("@Name", foodName);
                command.Parameters.AddWithValue("@Contributor", contributorName);
                command.ExecuteNonQuery();
            }
        }

        static string RandomFoodFromCommunity()
        {
            string randomFood = "No food available";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string selectQuery = "SELECT Name FROM Foods ORDER BY RANDOM() LIMIT 1";
                SQLiteCommand command = new SQLiteCommand(selectQuery, conn);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    randomFood = result.ToString();
                }
            }
            return randomFood;
        }

        static string RandomFoodFromContributor(string contributorName)
        {
            string randomFood = "No food available from this contributor";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string selectQuery = "SELECT Name FROM Foods WHERE Contributor = @Contributor ORDER BY RANDOM() LIMIT 1";
                SQLiteCommand command = new SQLiteCommand(selectQuery, conn);
                command.Parameters.AddWithValue("@Contributor", contributorName);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    randomFood = result.ToString();
                }
            }
            return randomFood;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();

            // Bắt đầu lắng nghe kết nối từ client trong một luồng mới
            Task.Run(() => Listen(cancellationTokenSource.Token));
        }
        private void Listen(CancellationToken cancellationToken)
        {
            // Tạo socket mới để lắng nghe kết nối
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080));
            serverSocket.Listen(10); // Tham số thứ hai là số lượng kết nối đợi tối đa

            // Vòng lặp vô hạn để liên tục chấp nhận kết nối từ các client
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    // Chấp nhận kết nối từ một client
                    Socket clientSocket = serverSocket.Accept();

                    // Xử lý kết nối từ client này trong một luồng mới
                    Task.Run(() =>
                    {
                        HandleClient(clientSocket);
                    }, cancellationToken);
                }
                catch (SocketException ex)
                {
                    // Xử lý lỗi kết nối
                    MessageBox.Show("Error accepting connection: " + ex.Message);
                }
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Huỷ bỏ CancellationToken khi form đóng
            cancellationTokenSource?.Cancel();
            if (serverSocket != null)
            {
                serverSocket.Shutdown(SocketShutdown.Both);
                serverSocket.Close();
            }

            // Xóa cơ sở dữ liệu SQLite
            ClearDatabase();
        }
        private void ClearDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Foods";
                SQLiteCommand command = new SQLiteCommand(deleteQuery, conn);
                command.ExecuteNonQuery();
            }
        }
    }
}
