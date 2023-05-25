using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ReceverGUI
{
    internal class VerifyDoc
    {
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
