using Entity.ConCreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImagesValidator :AbstractValidator<CarImages>
    {
        public CarImagesValidator()
        {
            RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.CarId).NotNull();
        }
    }
}
