﻿using Autosalon.Domain.Commons;
using Autosalon.Domain.Entities.Cars;

namespace Autosalon.Domain.Entities.Users
{
    public class User : Auditable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public Car Car { get; set; }

        public int Check { get; set; }
    }
}
