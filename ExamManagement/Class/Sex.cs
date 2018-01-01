using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Class
{
    public class Sex
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Sex(int _id, string Name)
        {
            this.ID = _id;
            this.Name = Name;
        }
    }
}
