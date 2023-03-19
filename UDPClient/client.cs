using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace UDPClient
{
    public partial class client : Form
    {
        public client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }
        //nhấn nút gửi đi
        private void buttonSend_Click(object sender, EventArgs e)
        {
           Send();
            AddMess(Mess.Text);
        }

        IPEndPoint IP; //địa chỉ cuối, 127.0.0.1 là con số mặc định, port thay dc
        Socket Client; 
        //kết nối
        void Connect()
        {
            //IP server 
             IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2003);
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                //kết nối tới server
                Client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến Server", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }
        //đóng tạm thời
        void Close()
        {
            Client.Close();
        }

        //gửi
        void Send()
        {
            if(Mess.Text!=string.Empty)
                Client.Send(Serialize(Mess.Text)); //phân mảnh thành byte rồi gửi đi
        }

        //nhận
        void Receive()
        {
            try
            {
                //nhận tin liên tục nên dùng while true
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    Client.Receive(data);

                    string message = (string)Deserialize(data);
                    AddMess(message);
                }
            }
            catch
            {
                Close();
            }
        } 
        //add mess vào listview
        void AddMess(string s)
        {
            listMess.Items.Add(new ListViewItem() { Text = s });
            Mess.Clear();
        }

        //chuyển mess thành dãy byte gửi đi và chuyển dãy byte thành mess khi nhận được
        //chuyển thành byte 
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(stream, obj);
            return stream.ToArray();
        }

        //chuyển byte thành mess
        object Deserialize (byte[] data)    
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter format = new BinaryFormatter();
            return format.Deserialize(stream);
        }

        //đóng kết nối khi đóng form
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void listMess_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Mess_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
