using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFlix.Models
{   
    public class Min18YearsIfaMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeID == 0 || customer.MembershipTypeID == 1)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Birth date is required!");

            return (DateTime.Now.Year - customer.BirthDate.Value.Year) >= 18
                ? ValidationResult.Success
                : new ValidationResult("Customer should 18 years or old to be a member");
        }
    }
}