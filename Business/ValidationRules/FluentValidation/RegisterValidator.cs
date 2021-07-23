using Entity.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RegisterValidator:AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).NotNull();
            RuleFor(u => u.Email).MinimumLength(10);
        }
    }
}
