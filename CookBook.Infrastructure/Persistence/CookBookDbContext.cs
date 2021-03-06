﻿using CookBook.Application.Common.Interfaces;
using CookBook.Core.Entities;
using CookBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBook.Infrastructure.Persistence
{
    public class CookBookDbContext : DbContext, ICookBookDbContext
    {
        public CookBookDbContext(DbContextOptions<CookBookDbContext> options)  : base(options)
        {

        }

        public DbSet<Recipe> Recipes { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: extract configurations to separate classes
            modelBuilder
                .Entity<Recipe>()
                .HasKey(r => r.Id);

            modelBuilder
                .Entity<Recipe>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder
                .Entity<Ingredient>()
                .HasKey(i => i.Id);

            modelBuilder
                .Entity<Ingredient>()
                .Property(i => i.Amount)
                .IsRequired();

            modelBuilder
                 .Entity<Ingredient>()
                 .OwnsOne<IngredientName>(i => i.Name)
                 .Property(i => i.Value)
                 .HasColumnName("Name")
                 .IsRequired(); // FYI: IsRequired() does not work yet with owned types, so manual change in migration code is required
        }
    }
}
