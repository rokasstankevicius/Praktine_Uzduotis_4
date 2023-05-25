using Newtonsoft.Json;
using System;
using System.Buffers.Text;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ClientGUI
{
    class SignDoc
    {
        public static Tuple<string, string> SignTheText(byte[] textBytes)
        {
            string publicKeyString = "";
            string signatureString = "";
            try
            {
                // Create an RSA key pair
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    // Generate the private and public key pair
                    RSAParameters privateKey = rsa.ExportParameters(true);
                    RSAParameters publicKey = rsa.ExportParameters(false);
                    
                    string Base64 = XmlToString(publicKey);

                    //MessageBox.Show(Base64);

                    RSAParameters publicKeypepe = StringToXml(Base64);
                        //FromBase64<RSAParameters>(Base64);
                    
                    // Message to be signed
                    //string message = "This is the message to be signed.";

                    // Sign the message
                    byte[] signature = SignData(textBytes, privateKey);

                    publicKeyString = //ToBase64(publicKey);
                                      XmlToString(publicKey);

                    signatureString = Convert.ToBase64String(signature);
                    //Console.WriteLine("Digital Signature generated.");

                    // Verify the signature
                    /*
                    bool isSignatureValid = VerifySignature(textBytes, signature, publicKey);
                    
                    if (isSignatureValid)
                    {
                        MessageBox.Show("Signature is valid. Message has not been tampered with.");
                    }
                    else
                    {
                        MessageBox.Show("Signature is invalid. Message may have been tampered with.");
                    }
                    */
                    //return Tuple.Create(publicKeyString, signatureString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return Tuple.Create(publicKeyString, signatureString);
        }


        public static string XmlToString(RSAParameters obj)
        {
            string serializedData = string.Empty;                   // The string variable that will hold the serialized data

            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, obj);
                serializedData = sw.ToString();
                return serializedData;
            }
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

        public static string ToBase64(RSAParameters obj)
        {
            string json = JsonConvert.SerializeObject(obj);

            byte[] bytes = Encoding.Default.GetBytes(json);

            return Convert.ToBase64String(bytes);
        }

        
        /*
        public static RSAParameters FromBase64<T>(string base64Text)
        {
            byte[] bytes = Convert.FromBase64String(base64Text);

            string json = Encoding.Default.GetString(bytes);

            return JsonConvert.DeserializeObject<RSAParameters>(json);
        }
        */
        static byte[] SignData(byte[] data, RSAParameters privateKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Import the private key parameters
                rsa.ImportParameters(privateKey);

                // Create an RSAPKCS1SignatureFormatter object and pass it the RSA instance to transfer the private key
                RSAPKCS1SignatureFormatter formatter = new RSAPKCS1SignatureFormatter(rsa);

                // Set the hash algorithm to SHA256
                formatter.SetHashAlgorithm("SHA256");

                // Create a hash value of the data
                SHA256Managed sha256 = new SHA256Managed();
                byte[] hash = sha256.ComputeHash(data);

                // Sign the hash value
                byte[] signature = formatter.CreateSignature(hash);

                return signature;
            }
        }

        public static bool VerifySignature(byte[] text, byte[] signature, RSAParameters publicKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Import the public key parameters
                rsa.ImportParameters(publicKey);

                // Create an RSAPKCS1SignatureDeformatter object and pass it the RSA instance to transfer the public key
                RSAPKCS1SignatureDeformatter deformatter = new RSAPKCS1SignatureDeformatter(rsa);

                // Set the hash algorithm to SHA256
                deformatter.SetHashAlgorithm("SHA256");

                // Create a hash value of the data
                SHA256Managed sha256 = new SHA256Managed();
                byte[] hash = sha256.ComputeHash(text);

                // Verify the signature
                bool isSignatureValid = deformatter.VerifySignature(hash, signature);

                return isSignatureValid;
            }
        }
    }
}
