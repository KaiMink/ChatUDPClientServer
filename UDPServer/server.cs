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

namespace UDPServer
{
    public partial class server : Form
    {
        public server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }
        
        //gửi cho tất cả client
        private void buttonSend_Click(object sender, EventArgs e)
        {
            foreach (Socket item in clientList)
            {
                Send(item);
            }
            AddMess(Mess.Text);
            Mess.Clear();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }


        IPEndPoint IP; //địa chỉ cuối, 127.0.0.1 là con số mặc định, port thay dc
        Socket Server;
        List<Socket> clientList = new List<Socket>();

        //kết nối
        void Connect()
        {
            clientList = new List<Socket>();
            //IP server 
            IP = new IPEndPoint(IPAddress.Any, 2003);
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            Server.Bind(IP);
            Thread Listen = new Thread(() =>
           {
               try
               {
                   while (true)
                   {
                       Server.Listen(100);
                       Socket client = Server.Accept();
                       clientList.Add(client);

                       Thread receive = new Thread(Receive);
                       receive.IsBackground = true;
                       receive.Start(client);
                   }
               }
               catch
               {
                   IP = new IPEndPoint(IPAddress.Any, 1600);
                   Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
               }
           }
            );
            Listen.IsBackground = true;
            Listen.Start();
        }
        //đóng tạm thời
        void Close()
        {
            Server.Close();
        }

        //gửi
        void Send(Socket client)
        {
            if ((client != null) && (Mess.Text != string.Empty))
                client.Send(Serialize(Mess.Text)); //phân mảnh thành byte rồi gửi đi
        }

        //nhận
        void Receive(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                //nhận tin liên tục nên dùng while true
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)Deserialize(data);
                    foreach (Socket item in clientList)
                    {
                        if (item != null && item != client)
                        {
                            item.Send(Serialize(message));
                        }
                    }
                    AddMess(message);
                }
            }
            catch
            {
                clientList.Remove(client);
                client.Close();
            }
        }
        //add mess vào listview
        void AddMess(string s)
        {
            listMess.Items.Add(new ListViewItem() { Text = s });
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
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter format = new BinaryFormatter();
            return format.Deserialize(stream);
        }

        
    }
}
