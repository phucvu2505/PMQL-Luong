using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQL_Luong.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PassWord { get; set; }
        public string Permission { get; set; }
        public string SDT { get; set; }
    }
}
