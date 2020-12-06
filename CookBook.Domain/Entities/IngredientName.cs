using CookBook.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Domain.Entities
{
    public class IngredientName : ValueObject
    {
        public string Value { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public IngredientName(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException($"Ingredient name cannot be empty.");

            Value = value;
        }
    }
}
