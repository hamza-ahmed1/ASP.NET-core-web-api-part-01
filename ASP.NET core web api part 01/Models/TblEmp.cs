using System;
using System.Collections.Generic;

namespace ASP.NET_core_web_api_part_01.Models
{
    public partial class TblEmp
    {
        public int EmpId { get; set; }
        public string Name { get; set; } = null!;
        public int Salary { get; set; }
    }
}
