using System;
using System.Collections.Generic;

namespace ASP.NET_core_web_api_part_01.Models
{
    public partial class TblStudent
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Age { get; set; }
    }
}
