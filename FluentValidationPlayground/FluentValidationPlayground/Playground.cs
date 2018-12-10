using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using FluentValidationPlayground.Source.Entities;
using FluentValidationPlayground.Source.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FluentValidationPlayground
{
    [TestClass]
    public class Playground
    {
        [TestMethod]
        public void Basic()
        {
            var customer = new Customer();
            var validator = new CustomerValidator();

            var result = validator.Validate(customer);

            result.Should().NotBeNull();

            DisplayErrors(result);
        }



        [TestMethod]
        public void GetAllErrorMessages()
        {
            var customer = new Customer();
            var validator = new CustomerValidator();

            var result = validator.Validate(customer);

            result.Should().NotBeNull();

            var allMessages = result.ToString();

            Console.WriteLine(allMessages);
        }

        [TestMethod]
        public void GetAllErrorMessagesWithASeparator()
        {
            var customer = new Customer();
            var validator = new CustomerValidator();

            var result = validator.Validate(customer);

            result.Should().NotBeNull();

            var allMessages = result.ToString("~");

            Console.WriteLine(allMessages);
        }

        [TestMethod]
        public void ValidateAndThrow()
        {
            var customer = new Customer();
            var validator = new CustomerValidator();

            try
            {
                validator.ValidateAndThrow(customer);
            }
            catch (ValidationException vx)
            {
                Console.WriteLine(vx.Message);
            }
        }

        [TestMethod]
        public void RuleForEach()
        {
            var person = new Person();
            var validator = new PersonValidator();

            var result = validator.Validate(person);

            result.Should().NotBeNull();

            DisplayErrors(result);
        }


        #region Helper Methods

        private static void DisplayErrors(ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    Console.WriteLine($"Property [{error.PropertyName}] failed validation. Error was: {error.ErrorMessage}");
                }
            }
        }

        #endregion Helper Methods
    }
}
