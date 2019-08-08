using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Models
{
    public class Assignment
    {
        public Assignment()
        {
            Hardwares = new List<Hardware>();
            Softwares = new List<Software>();
        }

        public long  Id { get; set; }
        //[ForeignKey("Users")]
        public long UserID { get; set; }
        public long SoftwareID { get; set; }
        public long HardwareID { get; set; }
        public List<Hardware> Hardwares { get; set; }
        public List<Software> Softwares { get; set; }
    }
}
