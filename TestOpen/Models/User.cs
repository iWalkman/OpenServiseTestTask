using System;
using System.Collections.Generic;

namespace TestOpen.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Post Posts { get; set; }
    }
}
