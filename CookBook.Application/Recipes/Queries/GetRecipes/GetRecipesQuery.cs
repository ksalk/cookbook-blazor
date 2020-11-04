using CookBook.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CookBook.Application.Recipes.Queries.GetRecipes
{
    public class GetRecipesQuery : IRequest<List<RecipeDto>>
    {
    }

    public class GetRecipesQueryHandler : IRequestHandler<GetRecipesQuery, List<RecipeDto>>
    {
        private readonly ICookBookDbContext _dbContext;

        public GetRecipesQueryHandler(ICookBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<RecipeDto>> Handle(GetRecipesQuery request, CancellationToken cancellationToken)
        {
            var recipes = await _dbContext.Recipes.ToListAsync();
            return recipes.Select(x => new RecipeDto()
            {
                Id = x.Id,
                Name = x.Name,
                Created = x.Created
            }).ToList();
        }
    }
}
