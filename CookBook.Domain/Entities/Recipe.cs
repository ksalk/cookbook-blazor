using CookBook.Core.Entities.Base;
using CookBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.Core.Entities
{
    public class Recipe : AggregateRoot
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public List<Ingredient> Ingredients { get; private set; }

        public DateTime Created { get; private set; }

        public Recipe(string name, string description)
        {
            Name = name;
            Description = description;
            Ingredients = new List<Ingredient>();
            Created = DateTime.Now;
        }

        public Ingredient AddIngredient(string name, string amount)
        {
            var newIngredient = new Ingredient(name, amount);
            if (Ingredients.Any(i => i.Name == newIngredient.Name))
                throw new ArgumentException($"Recipe already has ingredient with name: {newIngredient.Name.Value}.");

            Ingredients.Add(newIngredient);
            return newIngredient;
        }
    }
}
