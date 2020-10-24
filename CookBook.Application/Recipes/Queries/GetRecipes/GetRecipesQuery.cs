using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBook.Application.Recipes.Queries.GetRecipes
{
    public class GetRecipesQuery : IRequest<List<RecipeDto>>
    {
    }

    public class GetRecipesQueryHandler : IRequestHandler<GetRecipesQuery, List<RecipeDto>>
    {
        public async Task<List<RecipeDto>> Handle(GetRecipesQuery request, CancellationToken cancellationToken)
        {
            var rand = new Random();
            var schabowy = new RecipeDto() { Name = "Schabowy", Created = DateTime.Now.AddMinutes(-rand.Next(10000)) };
            var bigos = new RecipeDto() { Name = "Bigos", Created = DateTime.Now.AddMinutes(-rand.Next(10000)) };
            var shakshuka = new RecipeDto() { Name = "Shakshuka", Created = DateTime.Now.AddMinutes(-rand.Next(10000)) };
            var butterChicken = new RecipeDto() { Name = "Butter chicken", Created = DateTime.Now.AddMinutes(-rand.Next(10000)) };

            return new List<RecipeDto>() { schabowy, bigos, shakshuka, butterChicken };
        }
    }
}
