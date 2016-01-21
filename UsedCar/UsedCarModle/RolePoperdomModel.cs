using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedCarModle
{
    public class RolePoperdomModel
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public Nullable<System.DateTime> RoleCreateTime { get; set; }
        public int PopedomId { get; set; }
        public string PopedomName { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string Url { get; set; }
        public Nullable<int> sortId { get; set; }
        public Nullable<int> ParentType { get; set; }
    }
}
