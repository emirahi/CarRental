using Entity.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarByBrandValidator:AbstractValidator<CarByBrandDto>
    {
        public CarByBrandValidator()
        {
            RuleFor(c => c.BrandName.Length != 0);
        }
    }
}
