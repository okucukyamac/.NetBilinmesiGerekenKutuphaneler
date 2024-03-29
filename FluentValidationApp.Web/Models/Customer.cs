﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FluentValidationApp.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime? BirthDay { get; set; }
        // Customer.Address[1] gibi kullanabilmeme için Ilist kullanmam gerek.
        public IList<Address> Addresses{ get; set; }
        public Gender Gender { get; set; }

        public CreditCard CreditCard { get; set; }

        public string GetFullName()
        {
            return $"{Name}-{Email}-{Age}";
        }
    }
}
