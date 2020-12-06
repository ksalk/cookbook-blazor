using CookBook.Application.Common.Interfaces;
using CookBook.Core.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace CookBook.Application.Recipes.Commands.AddRecipe
{
    public class AddRecipeCommand : IRequest<CreatedRecipeDto>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }

    public class AddRecipeCommandHandler : IRequestHandler<AddRecipeCommand, CreatedRecipeDto>
    {
        private readonly ICookBookDbContext _dbContext;

        public AddRecipeCommandHandler(ICookBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CreatedRecipeDto> Handle(AddRecipeCommand request, CancellationToken cancellationToken)
        {
            var newRecipe = new Recipe(request.Name, request.Description);
            await _dbContext.Recipes.AddAsync(newRecipe);
            await _dbContext.SaveChangesAsync();

            return new CreatedRecipeDto()
            {
                Id = newRecipe.Id,
                Name = newRecipe.Name,
                Description = newRecipe.Description,
            };
        }
    }
}
