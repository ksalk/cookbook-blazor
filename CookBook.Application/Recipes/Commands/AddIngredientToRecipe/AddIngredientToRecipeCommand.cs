using CookBook.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBook.Application.Recipes.Commands.AddIngredientToRecipe
{
    public class AddIngredientToRecipeCommand : IRequest<CreatedRecipeIngredientDto>
    {
        [Required]
        public int RecipeId { get; set; }

        [Required]
        public string IngredientName { get; set; }

        public string Amount { get; set; }
    }

    public class AddIngredientToRecipeCommandHandler : IRequestHandler<AddIngredientToRecipeCommand, CreatedRecipeIngredientDto>
    {
        private readonly ICookBookDbContext _dbContext;

        public AddIngredientToRecipeCommandHandler(ICookBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CreatedRecipeIngredientDto> Handle(AddIngredientToRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = await _dbContext.Recipes.FirstOrDefaultAsync(r => r.Id == request.RecipeId);
            if (recipe == null)
                throw new ArgumentException($"There is no recipe with Id: {request.RecipeId}.");

            var createdIngredient = recipe.AddIngredient(request.IngredientName, request.Amount);
            return new CreatedRecipeIngredientDto()
            {
                Id = createdIngredient.Id
            };
        }
    }
}
