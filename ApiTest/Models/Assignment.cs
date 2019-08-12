using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Models
{
    public class Assignment
    {
       

        public long  Id { get; set; }
        //[ForeignKey("Users")]
        public long UserID { get; set; }
        public User User { get; set; }
        public long SoftwareID { get; set; }
        public Software Software { get; set; }
        public long HardwareID { get; set; }
        public Hardware Hardware { get; set; }

     
    }
}
