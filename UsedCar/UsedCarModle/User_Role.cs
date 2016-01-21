using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedCarModle
{
    public class User_Role
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string TrueName { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public string RoleName { get; set; }
    }
}
