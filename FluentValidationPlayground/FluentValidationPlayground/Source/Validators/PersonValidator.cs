using FluentValidation;
using FluentValidationPlayground.Source.Entities;

namespace FluentValidationPlayground.Source.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleForEach(person => person.AddressLines).NotNull();
        }
    }
}
