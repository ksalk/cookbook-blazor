using CookBook.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Core.Entities
{
    public class RecipeIngredient : Entity
    {
        public Ingredient Ingredient { get; set; }

        public double Amount { get; set; }
    }
}
