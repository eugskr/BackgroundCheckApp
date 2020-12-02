using BackgroundChecks.Web.Validators;
using NUnit.Framework;
using BackgroundChecks.Data.Models;
using System;
using System.Linq;
using FluentValidation.Results;

namespace BackgroundChecks.Tests.Web.Validation
{
    public class CheckRequestValidatorTests
    {
        CheckRequestValidator validator;
        [SetUp]
        public void Setup()
        {
            validator = new CheckRequestValidator();
        }

        [Test]
        public void CheckRequestValidator_FirstNameIsEmpty_ValidationFailed()
        {
            var model = new CheckRequest
            {
                FirstName = "",
                LastName = "Skrypnyk",
                DateOfBirth = new DateTime(2002, 10, 10),
                SSN = "123456789"
            };

            var validationResult = validator.Validate(model);

            VerifyValidationResult(validationResult, "FirstName", "Please, provide a first name");
        }

        [TestCase("Yev2n")]
        [TestCase("y?vhen")]
        public void CheckRequestValidator_FirstNameIsNotValid_ValidationFailed(string firstName)
        {
            var model = new CheckRequest
            {
                FirstName = firstName,
                LastName = "Skrypnyk",
                DateOfBirth = new DateTime(2002, 10, 10),
                SSN = "123456789"
            };

            var validationResult = validator.Validate(model);

            VerifyValidationResult(validationResult, "FirstName", "Please, provide only letters");
        }

        [Test]
        public void CheckRequestValidator_LastNameIsEmpty_ValidationFailed()
        {
            var model = new CheckRequest
            {
                FirstName = "Yevhen",
                LastName = "",
                DateOfBirth = new DateTime(2002, 10, 10),
                SSN = "123456789"
            };

            var validationResult = validator.Validate(model);

            VerifyValidationResult(validationResult, "LastName", "Please, provide a last name");
        }

        [TestCase("Skr21ypnyk")]
        [TestCase("skr*nyk")]
        public void CheckRequestValidator_LastNameIsNotValid_ValidationFailed(string lastName)
        {
            var model = new CheckRequest
            {
                FirstName = "Yevhen",
                LastName = lastName,
                DateOfBirth = new DateTime(2002, 10, 10),
                SSN = "123456789"
            };

            var validationResult = validator.Validate(model);

            VerifyValidationResult(validationResult, "LastName", "Please, provide only letters");
        }

        [TestCase("2002-12-31")]
        [TestCase("2010-09-11")]
        [TestCase("2003-04-24")]

        public void CheckRequestValidator_DateOfBirthLessThanEighteenYearsAgo_ValidationFailed(DateTime dateOfBirth)
        {
            var model = new CheckRequest
            {
                FirstName = "Yevhen",
                LastName = "Skrypnyk",
                DateOfBirth = dateOfBirth,
                SSN = "123456789"
            };

            var validationResult = validator.Validate(model);

            VerifyValidationResult(validationResult, "DateOfBirth", "You are under 18 years old");
        }

        private static void VerifyValidationResult(ValidationResult validationResult, string errorField, string errorMessage)
        {
            var errors = validationResult.Errors;
            var isDateOfBirthFailedOnly = errors.All(x => x.PropertyName == errorField);
            var isRequiredMessageExist = errors.Any(x => x.PropertyName == errorField
                && x.ErrorMessage == errorMessage);
            Assert.IsTrue(isDateOfBirthFailedOnly);
            Assert.IsTrue(isRequiredMessageExist);
        }
    }
}
