using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Class
{
    public class HinhThucCauHoi
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public HinhThucCauHoi(int _id, string name)
        {
            ID = _id;
            Name = name;
        }

        public HinhThucCauHoi()
        {
            ID = 0;
            Name = "";
        }
    }
}
