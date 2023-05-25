using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ServerGUI
{
    internal class SendToRecever
    {
        Socket socket;
        bool hasSent1 = false;
        bool hasSent2 = false;
        

        public SendToRecever() 
        {
            socket = SocketCreate();
            try
            {
                socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5));
            }
            catch
            {
                MessageBox.Show("Unable to connect!");
            }
        }

        Socket SocketCreate()
        {
            return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void SendData(string data1, string data2, string data3)
        {
            if (!hasSent1 && !hasSent2)
            {
                byte[] data = Encoding.Default.GetBytes(data1);

                socket.Send(BitConverter.GetBytes(data.Length), 0, 4, 0);
                socket.Send(data);
                hasSent1 = true;
            }
            if (hasSent1 && !hasSent2)
            {
                byte[] data = Encoding.Default.GetBytes(data2);

                socket.Send(BitConverter.GetBytes(data.Length), 0, 4, 0);
                socket.Send(data);
                hasSent2 = true;
            }
            if (hasSent1 && hasSent2)
            {
                byte[] data = Encoding.Default.GetBytes(data3);

                socket.Send(BitConverter.GetBytes(data.Length), 0, 4, 0);
                socket.Send(data);
                hasSent1 = false;
                hasSent2 = false;
            }
        }
       
    }
}
