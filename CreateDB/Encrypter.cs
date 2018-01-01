using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CreateDB
{
    class Encrypter
    {
        static string key = "exon_system";
        public Encrypter(string k)
        {
            key = k;
        }
        /// <summary>
        /// Mã hóa chuỗi có mật khẩu
        /// </summary>
        /// <param name="toEncrypt">Chuỗi cần mã hóa</param>
        /// <returns>Chuỗi đã mã hóa</returns>
        
        public string Encrypt(string toEncrypt)
        {
            if (toEncrypt == null) return null;
            StringBuilder inSb = new StringBuilder(toEncrypt);
            StringBuilder outSb = new StringBuilder(toEncrypt.Length);
            char c;
            for (int i = 0; i < toEncrypt.Length; i++)
            {
                c = inSb[i];
                c = (char)(c ^ key[i%key.Length]);
                outSb.Append(c);
            }
            return outSb.ToString();
        }
    }
}
