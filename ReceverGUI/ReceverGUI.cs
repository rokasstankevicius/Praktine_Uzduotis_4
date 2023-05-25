using Newtonsoft.Json;
using System.CodeDom;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ReceverGUI
{
    public partial class ReceverGUI : Form
    {
        Socket socket;
        Socket acc;
        bool hasReceived1 = false;
        bool hasReceived2 = false;
        byte[] sentData1;
        byte[] sentData2;
        byte[] sentData3;

        public ReceverGUI()
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

        private void button1_Click(object sender, EventArgs e)
        {


            socket = SocketCreate();

            socket.Bind(new IPEndPoint(0, 5));
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
                            //sentData1 = data;
                            richTextBox1.Text = Encoding.Default.GetString(data);
                        });
                        hasReceived1 = true;
                    }
                    else if (hasReceived1 && !hasReceived2)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            sentData2 = data;
                            richTextBox2.Text = Encoding.Default.GetString(data);
                        });
                        hasReceived2 = true;
                    }
                    else if (hasReceived1 && hasReceived2)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            sentData3 = data;
                            richTextBox3.Text = Encoding.Default.GetString(data);
                        });
                        hasReceived1 = false;
                        hasReceived2 = false;
                    }

                }
            }).Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1 == null || richTextBox2 == null || richTextBox3 == null)
            {
                MessageBox.Show("All text boxes should be filled!");
            }
            else
            {
                //MessageBox.Show(richTextBox2.Text);
                //string encodedStr = Convert.ToBase64String(Encoding.UTF8.GetBytes(richTextBox2.Text));
                //bool isVerified = VerifyDoc.VerifySignature(Encoding.Default.GetBytes(richTextBox1.Text),sentData3,FromBase64<RSAParameters>(richTextBox2.Text));
                bool isVerified = VerifyDoc.VerifySignature(Encoding.Default.GetBytes(richTextBox1.Text), sentData3, StringToXml(richTextBox2.Text));
                if (!isVerified)
                {
                    MessageBox.Show("Signature is valid!");
                }
                else
                {
                    MessageBox.Show("Signature is invalid!");
                }
            }
        }

        private static RSAParameters FromBase64<T>(string base64Text)
        {
            byte[] bytes = Convert.FromBase64String(base64Text);

            string json = Encoding.Default.GetString(bytes);

            return JsonConvert.DeserializeObject<RSAParameters>(json);
        }

        public static RSAParameters StringToXml(string serializedData)
        {

            XmlSerializer deserializer = new XmlSerializer(typeof(RSAParameters));
            using (TextReader tr = new StringReader(serializedData))
            {
                var deserializedPerson = (RSAParameters)deserializer.Deserialize(tr);
                return deserializedPerson;
            }
        }
    }
}