using CookBook.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Domain.Entities
{
    public class IgredientName : ValueObject
    {
        public string Value { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
