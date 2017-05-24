using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQL_Luong.Entities
{
    public class User
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String PassWord { get; set; }
        public String Permission { get; set; }
    }
}
