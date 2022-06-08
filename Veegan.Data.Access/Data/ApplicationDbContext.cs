﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vegan.Models;
using Vegan.Models.Model;

namespace Veegan.Data.Access.Data;

public class ApplicationDbContext : IdentityDbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Category { get; set; }
    //public object FoodType { get; set; }
    public DbSet<FoodType> FoodType { get; set; }

    public DbSet<MenuItem> MenuItem { get; set; }

     public DbSet<ApplicationUser> ApplicationUser { get; set; }

     public DbSet<ShoppingCart> ShoppingCart { get; set; }

}

