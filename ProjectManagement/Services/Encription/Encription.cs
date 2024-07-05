using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ProjectManagement.Services.Encription
{
    public class Encription : IEncription
    {
        private readonly string Key;
        public Encription()
        {
            Key = Convert.ToBase64String(Encoding.UTF8.GetBytes("abcdefghijklmnopqrstuvwxyz012345"));
        }

        public string EncryptString(string text)
        {
            byte[] key = Convert.FromBase64String(Key);
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.GenerateIV(); // Generate a random IV
                using (var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (var swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(text);
                            }
                        }
                        var iv = aesAlg.IV;
                        var encryptedContent = msEncrypt.ToArray();
                        var result = new byte[iv.Length + encryptedContent.Length];
                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(encryptedContent, 0, result, iv.Length, encryptedContent.Length);
                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        public string DecryptString(string cipherText)
        {
            byte[] fullCipher = Convert.FromBase64String(cipherText);
            byte[] iv = new byte[16]; // IV length is 16 bytes for AES
            byte[] cipher = new byte[fullCipher.Length - 16];
            Array.Copy(fullCipher, iv, 16);
            Array.Copy(fullCipher, 16, cipher, 0, fullCipher.Length - 16);

            byte[] key = Convert.FromBase64String(Key);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                using (var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                {
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }

    }
}
