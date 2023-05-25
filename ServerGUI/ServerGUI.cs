using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerGUI
{
    public partial class ServerGUI : Form
    {
        Socket socket;
        Socket acc;
        bool hasReceived1 = false;
        bool hasReceived2 = false;
        string sentData1;
        string sentData2;
        string sentData3;

        public ServerGUI()
        {
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(Form1_FormCloading);
        }

        private void Form1_FormCloading(object? sender, FormClosingEventArgs e)
        {
            socket.Close();
        }

        Socket SocketCreate()
        {
            return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        /*
        private void button1_Click(object sender, EventArgs e)
        {
            socket = SocketCreate();

            socket.Bind(new IPEndPoint(IPAddress.Any, 3));
            socket.Listen(0);

            new Thread(() =>
            {
                acc = socket.Accept();
                MessageBox.Show("Connection Accepted!");
                socket.Close();

                while (true)
                {
                    try
                    {
                        byte[] buffer = new byte[4096];
                        int rec = acc.Receive(buffer, 0, buffer.Length, 0);

                        if (rec <= 0)
                        {
                            throw new SocketException();
                        }

                        Array.Resize(ref buffer, rec);

                        Invoke((MethodInvoker)delegate
                        {
                            listBox1.Items.Add(Encoding.Default.GetString(buffer));
                        });
                    }
                    catch
                    {
                        MessageBox.Show("Disconected!");
                        break;
                    }
                }
                Application.Exit();
            }).Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.Default.GetBytes(textBox1.Text);
            acc.Send(data, 0, data.Length, 0);
        }
        */
        private void button3_Click(object sender, EventArgs e)
        {
            socket = SocketCreate();

            socket.Bind(new IPEndPoint(0, 3));
            socket.Listen(0);

            acc = socket.Accept();

            socket.Close();

            new Thread(() =>
            {
                while (true)
                {
                    byte[] sizeBuf = new byte[4];
                    acc.Receive(sizeBuf, 0, sizeBuf.Length, 0);

                    int size = BitConverter.ToInt32(sizeBuf, 0);

                    MemoryStream ms = new MemoryStream();

                    while (size > 0)
                    {
                        byte[] buffer;
                        if (size < acc.ReceiveBufferSize)
                        {
                            buffer = new byte[size];
                        }
                        else buffer = new byte[acc.ReceiveBufferSize];

                        int rec = acc.Receive(buffer, 0, buffer.Length, 0);

                        size -= rec;

                        ms.Write(buffer, 0, buffer.Length);
                    }

                    ms.Close();

                    byte[] data = ms.ToArray();

                    ms.Dispose();

                    if (!hasReceived1 && !hasReceived2)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            sentData1 = Encoding.Default.GetString(data);
                        });
                        hasReceived1 = true;
                    }
                    else if (hasReceived1 && !hasReceived2)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            sentData2 = Encoding.Default.GetString(data);
                        });
                        hasReceived2 = true;
                    }
                    else if (hasReceived1 && hasReceived2)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            sentData3 = Encoding.Default.GetString(data);
                        });
                        hasReceived1 = false;
                        hasReceived2 = false;
                        if (String.Empty != sentData1 && String.Empty != sentData2 && String.Empty != sentData3)
                        {
                            SendToRecever sendToRecever = new SendToRecever();
                            sendToRecever.SendData(sentData1, sentData2, sentData3);
                        }
                    }

                }
            }).Start();
        }
    }
}