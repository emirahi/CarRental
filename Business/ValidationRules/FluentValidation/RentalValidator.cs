using Entity.ConCreate;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentalsId).NotNull();
            RuleFor(r => r.RentalsId).Must(isNumber);
        }

        private bool isNumber(int arg)
        {
            if (arg <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
