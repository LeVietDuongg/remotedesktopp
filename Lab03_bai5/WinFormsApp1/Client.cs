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
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = txbIP.Text;
                int port = Convert.ToInt32(txbPort.Text);
                string message = txbMessage.Text;

                UdpClient udpClient = new UdpClient();

                byte[] data = Encoding.UTF8.GetBytes(message);

                udpClient.Send(data, data.Length, ip, port);
                txbMessage.Clear();
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
          
        }
    }
}
