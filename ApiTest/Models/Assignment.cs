using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Models
{
    public class Assignment
    {

        //[Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        //public long Id { get; set; }
       
        public long UserID { get; set; }
        public User User { get; set; }
        
        public long SoftwareID { get; set; }
        public Software Software { get; set; }
        
        public long HardwareID { get; set; }
        public Hardware Hardware { get; set; }

     
    }
}
