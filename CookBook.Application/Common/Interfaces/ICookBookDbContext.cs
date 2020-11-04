using CookBook.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBook.Application.Common.Interfaces
{
    public interface ICookBookDbContext
    {
        DbSet<Recipe> Recipes { get; set; }

        DbSet<Ingredient> Ingredients { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
