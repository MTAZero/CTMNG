using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Class
{
    public class DoiTuong
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public DoiTuong(int _id, string name)
        {
            ID = _id;
            Name = name;
        }

        public DoiTuong()
        {
            ID = 0;
            Name = "";
        }
    }
}
