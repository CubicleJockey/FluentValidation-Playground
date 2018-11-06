using FluentValidation;
using FluentValidationPlayground.Source.Entities;

namespace FluentValidationPlayground.Source.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Surname).NotNull();
        }
    }
}
