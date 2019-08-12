using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ApiTest.Models
{
    public class Software
    {
        public Software()
        {
            Assignment = new List<Assignment>();
        }
        public long Id { get; set; }
        [StringLength(30), Required]
        public string SoftwareName { get; set; }
        public IList<Assignment> Assignment { get; set; }
    }
}
