using System;

namespace ApiTest.Models
{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool IsComplete { get; set; }
        public DateTime LastSessionDateTime { get; set; }

    }
}
