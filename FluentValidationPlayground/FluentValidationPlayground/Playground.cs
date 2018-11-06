using FluentAssertions;
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

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine($"Property [{failure.PropertyName}] failed validation. Error was: {failure.ErrorMessage}");
                }
            }
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
    }
}
