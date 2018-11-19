﻿using FluentValidation.Attributes;
using WCFvsWebAPI.Domain.Validations;

namespace WCFvsWebAPI.Domain.Entities
{
    [Validator(typeof(EmployeeValidator))]
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Gender { get; set; }
    }
}
