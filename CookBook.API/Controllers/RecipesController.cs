using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBook.Common.Models;
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
        public IEnumerable<RecipeModel> Get()
        {
            var rand = new Random();
            var schabowy = new RecipeModel() { Name = "Schabowy", Created = DateTime.Now.AddMinutes(-rand.Next(10000)) };
            var bigos = new RecipeModel() { Name = "Bigos", Created = DateTime.Now.AddMinutes(-rand.Next(10000)) };
            var shakshuka = new RecipeModel() { Name = "Shakshuka", Created = DateTime.Now.AddMinutes(-rand.Next(10000)) };
            var butterChicken = new RecipeModel() { Name = "Butter chicken", Created = DateTime.Now.AddMinutes(-rand.Next(10000)) };
            return new RecipeModel[] { schabowy, bigos, shakshuka, butterChicken };
        }

        // GET api/<RecipesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RecipesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
