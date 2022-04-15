using LojaQuadrinhos.Services.Cryptography.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LojaQuadrinhos.Services.Cryptography.Algorithms
{
    public class AesCryptography : IAesCryptography
    {

        byte[] myKey = Convert.FromBase64String("/4ldQ/JwTNhWkOioWoDjBwKl5z/moRD6nPgyWSvapZc=");
        byte[] myIV = Convert.FromBase64String("ASs9CGO+Mhtzyp8JC69CLw==");

        public AesCryptography()
        {
            using (Aes myAes = Aes.Create())
            {
                //this.myKey = myAes.Key;
                //this.myIV = myAes.IV;                
            }
        }

        public string Encrypt(string plainText)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (this.myKey == null || this.myKey.Length <= 0)
                throw new ArgumentNullException("Key");
            if (this.myIV == null || this.myIV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = this.myKey;
                aesAlg.IV = this.myIV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return Convert.ToBase64String(encrypted);
        }


        public string Decrypt(string cipherText)
        {
            try
            {
                // Check arguments.
                if (cipherText == null || cipherText.Length <= 0)
                    throw new ArgumentNullException("plainText");
                if (this.myKey == null || this.myKey.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (this.myIV == null || this.myIV.Length <= 0)
                    throw new ArgumentNullException("IV");

                // Declare the string used to hold
                // the decrypted text.
                string plaintext = null;

                // Create an Aes object
                // with the specified key and IV.
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = this.myKey;
                    aesAlg.IV = this.myIV;

                    // Create a decryptor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    // Create the streams used for decryption.
                    using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {

                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                return plaintext;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
         return "erro";
        }

    }
}
