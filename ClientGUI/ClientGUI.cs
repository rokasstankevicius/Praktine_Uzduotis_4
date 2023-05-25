using System.CodeDom;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ClientGUI
{
    public partial class ClientGUI : Form
    {
        Socket socket;
        bool hasSent1 = false;
        bool hasSent2 = false;
        public ClientGUI()
        {
            InitializeComponent();
            socket = SocketCreate();
            FormClosing += new FormClosingEventHandler(Form1_FormCloading);
        }

        private void Form1_FormCloading(object? sender, FormClosingEventArgs e)
        {
            socket.Close();
            socket = SocketCreate();
            try
            {
                socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3));
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

        private void button1_Click(object sender, EventArgs e)
        {
            socket = SocketCreate();
            try
            {
                socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3));
            }
            catch
            {
                MessageBox.Show("Unable to connect!");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (!hasSent1 && !hasSent2)
            {
                byte[] data = Encoding.Default.GetBytes(richTextBox1.Text);

                socket.Send(BitConverter.GetBytes(data.Length), 0, 4, 0);
                socket.Send(data);
                hasSent1 = true;
            }
            if (hasSent1 && !hasSent2)
            {
                byte[] data = Encoding.Default.GetBytes(richTextBox2.Text);

                socket.Send(BitConverter.GetBytes(data.Length), 0, 4, 0);
                socket.Send(data);
                hasSent2 = true;
            }
            if (hasSent1 && hasSent2)
            {
                byte[] data = Encoding.Default.GetBytes(richTextBox3.Text);

                socket.Send(BitConverter.GetBytes(data.Length), 0, 4, 0);
                socket.Send(data);
                hasSent1 = false;
                hasSent2 = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1 != null)
            {
                byte[] textBytes = Encoding.Default.GetBytes(richTextBox1.Text);

                var results = SignDoc.SignTheText(textBytes);
                richTextBox2.Text = results.Item1;
                richTextBox3.Text = results.Item2;
            }
            else MessageBox.Show("The text box needs to be filled!");

        }


    }
}