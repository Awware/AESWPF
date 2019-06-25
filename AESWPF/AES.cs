using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AESWPF
{
    public class AES
    {
        public string AESEncryption(string text, string key)
        {
            try
            {
                byte[] nullBytes = Encoding.Unicode.GetBytes(text);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes bdp = new Rfc2898DeriveBytes(key, new byte[]
                    { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = bdp.GetBytes(32);
                    encryptor.IV = bdp.GetBytes(16);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(nullBytes, 0, nullBytes.Length);
                            cs.Close();
                        }
                        text = Convert.ToBase64String(ms.ToArray());
                    }
                }
                return text;
            }
            catch { return null; }
        }

        public string AESDecryption(string text, string key)
        {
            try
            {
                byte[] cipherBytes = Convert.FromBase64String(text);
                using (Aes decryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes bdp = new Rfc2898DeriveBytes(key, new byte[]
                    { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    decryptor.Key = bdp.GetBytes(32);
                    decryptor.IV = bdp.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        byte[] w = ms.ToArray();
                        text = Encoding.Unicode.GetString(w);
                    }
                }
                return text;
            }
            catch { return null; }
        }
    }
}
