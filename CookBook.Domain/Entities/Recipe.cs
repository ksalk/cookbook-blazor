using CookBook.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace CookBook.Core.Entities
{
    public class Recipe : AggregateRoot
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public IEnumerable<RecipeIngredient> Ingredients { get; private set; }

        public IEnumerable<File> Images { get; private set; }

        public DateTime Created { get; private set; }

        public Recipe(string name, string description)
        {
            Name = name;
            Description = description;
            Created = DateTime.Now;
        }

        public RecipeIngredient AddRecipeIngredient()
        {
            throw new NotImplementedException();
        }

        public File AddImage()
        {
            throw new NotImplementedException();
        }
    }
}
