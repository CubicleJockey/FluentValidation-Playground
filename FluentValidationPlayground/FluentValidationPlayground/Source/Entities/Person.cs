using System.Collections.Generic;

namespace FluentValidationPlayground.Source.Entities
{
    public class Person
    {
        public IEnumerable<string> AddressLines { get; set; } = new List<string>();
    }
}
