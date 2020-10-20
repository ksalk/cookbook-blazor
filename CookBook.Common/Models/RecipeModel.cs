using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Common.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }
    }
}
