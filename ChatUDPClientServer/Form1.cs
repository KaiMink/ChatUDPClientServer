using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace UDPServer
{
    public partial class ServerForm : Form
    {
        UdpClient udpServer;

        public ServerForm()
        {
            InitializeComponent();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            udpServer = new UdpClient(1234);
            udpServer.BeginReceive(ReceiveCallback, null);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 1234);
            byte[] bytes = udpServer.EndReceive(ar, ref ip);
            string message = Encoding.ASCII.GetString(bytes);
            Invoke(new Action(() =>
            {
                lstClients.Items.Add(ip.ToString());
                txtChat.AppendText(ip.ToString() + ": " + message + Environment.NewLine);
            }));
            udpServer.BeginReceive(ReceiveCallback, null);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(txtMessage.Text);
            udpServer.Send(bytes, bytes.Length, new IPEndPoint(IPAddress.Broadcast, 1234));
        }
    }
}
