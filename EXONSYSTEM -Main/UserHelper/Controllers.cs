using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserHelper
{
    public class Controllers
    {
        private static Controllers instance;
        public static Controllers Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Controllers();
                }
                return instance;
            }
        }
        private Controllers() { }

        public void WriteLog(int errorCode, string message)
        {
            FileStream fs = new FileStream(@"C:\Users\duong\Desktop\Log.txt", FileMode.Create);//Tạo file mới tên là test.txt            
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);//fs là 1 FileStream 
            sWriter.WriteLine(string.Format("{0} :{1}", errorCode, message));
            sWriter.Flush();
            fs.Close();
        }
    }
}
