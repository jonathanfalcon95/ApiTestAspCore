using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ApiTest.Models
{
    public class User
    {

        public User()
        {
            Assignment = new List<Assignment>();
        }
        public long Id { get; set; }
        [StringLength(30), Required]
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime LastSessionDateTime { get; set; }
        
        public IList<Assignment> Assignment { get; set; }

    }
}
