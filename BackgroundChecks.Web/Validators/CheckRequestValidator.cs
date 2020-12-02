using BackgroundChecks.Data.Models;
using BackgroundChecks.Services.Models;
using FluentValidation;
using System;

namespace BackgroundChecks.Web.Validators
{
    public class CheckRequestValidator:AbstractValidator<CheckRequest>
    {
        public CheckRequestValidator()
        {          
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Please, provide a first name")
                .Matches("^[a-zA-Z]+$").WithMessage("Please, provide only letters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Please, provide a last name")
                .Matches("^[a-zA-Z]+$").WithMessage("Please, provide only letters");

            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Please provide Date of birth")
                .LessThan(x=>DateTime.Now.AddYears(-18)).WithMessage("You are under 18 years old");

            RuleFor(x => x.SSN).NotEmpty().Matches(SSN.ValidationRegEx).WithMessage("SSN number is not valid");

        }
    }
}
