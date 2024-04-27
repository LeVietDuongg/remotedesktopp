using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai01
{
    public partial class Server : Form
    {
        private bool isListening = false;
        private UdpClient udpServer;
        private IPEndPoint remoteEP;

        public Server()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            Thread thdUDPServer = new Thread(new ThreadStart(serverThread));
            thdUDPServer.Start();
           
        }
        public void serverThread()
        {
            UdpClient udpClient = new UdpClient();
            try
            {
                int port = Convert.ToInt32(txbPort.Text);
                udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, port));

                lblListening.Text = "Listening on port: " + port;

                while (true)
                {
                    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, port);

                    Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);

                    string returnData = Encoding.UTF8.GetString(receiveBytes);
                    string mess = RemoteIpEndPoint.Address.ToString() + ": " + returnData.ToString() + "\n";

                    InforMessage(mess);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid IP address or port number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Error sending message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                udpClient.Close();
            }
        }

        public void InforMessage(string mess)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => lsvMessage.Items.Add(mess)));
            }
            else
            {
                lsvMessage.Items.Add(mess);
            }
        }
    }
}
