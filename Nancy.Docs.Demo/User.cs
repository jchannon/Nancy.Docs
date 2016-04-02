using System;
using Nancy.Hosting.Self;
using Nancy.Metadata.Modules;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Nancy.Docs.Demo
{

    public class User
    {
        [Required]
        public string Name { get; set; }

        [Range(1, 100)]
        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Address Address { get; set; }

        public Role Role { get; set; }

        public IList<string> Tags { get; set; }
    }
    
}
