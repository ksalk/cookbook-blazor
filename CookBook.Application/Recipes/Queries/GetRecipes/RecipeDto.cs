using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Application.Recipes.Queries.GetRecipes
{
    //TODO: possibly move Dtos to Common project
    public class RecipeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }
    }
}
