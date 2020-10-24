using CookBook.Core.Entities.Base;
using CookBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Core.Entities
{
    public class Ingredient : Entity
    {
        public IgredientName Name { get; set; }

        public string Amount { get; set; }
    }
}
