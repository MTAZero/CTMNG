using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralManagement.Common
{
    class En_Decrypt
    {
        static string key = "";
        public En_Decrypt(string k)
        {
            key = k;
        }

        public string Encrypt(string toEncrypt)
        {
            if (toEncrypt == null) return null;
            StringBuilder inSb = new StringBuilder(toEncrypt);
            StringBuilder outSb = new StringBuilder(toEncrypt.Length);
            char c;
            for (int i = 0; i < toEncrypt.Length; i++)
            {
                c = inSb[i];
                c = (char)(c ^ key[i % key.Length]);
                outSb.Append(c);
            }
            return outSb.ToString();
        }
    }
}
