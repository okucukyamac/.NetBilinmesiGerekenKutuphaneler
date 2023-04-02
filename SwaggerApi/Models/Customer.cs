using System;
using System.Collections.Generic;

#nullable disable

namespace SwaggerApi.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime? BirthDay { get; set; }
        public int Gender { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
