using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBook.Application.Recipes.Commands.AddRecipe;
using CookBook.Application.Recipes.Queries.GetRecipes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CookBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly ILogger<RecipesController> _logger;
        //TODO: possibly move to base controller class
        private readonly IMediator _mediator;

        public RecipesController(ILogger<RecipesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        // GET: api/<RecipesController>
        [HttpGet]
        public async Task<IEnumerable<RecipeDto>> Get()
        {
            return await _mediator.Send(new GetRecipesQuery());
        }

        // GET api/<RecipesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RecipesController>
        [HttpPost]
        public async Task<CreatedRecipeDto> Post([FromBody] AddRecipeCommand command)
        {
            return await _mediator.Send(command);
        }

        // PUT api/<RecipesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecipesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
