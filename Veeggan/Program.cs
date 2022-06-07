using Microsoft.EntityFrameworkCore;
using Veegan.Data.Access.Repository;
using Veegan.Data.Access.Repository.IRepository;
using Vegan.DataAccess.Data;
using System;
using Microsoft.AspNetCore.Identity;


//THIS IS THE CONTAINER 


var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();;

// Add services to the container.
builder.Services.AddRazorPages();


//adding DBContext with the application
builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(
       builder.Configuration.GetConnectionString("DefaultConnection")
    ));

//AddScoped is used for working with DB adding all the Db items at once.
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

//AddScoped is used for working with DB adding all the IUNITOFORK  items at once.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllersWithViews();


var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;
app.UseAuthorization();

app.MapRazorPages();

// we add map controllers so we an use API to properly route 
app.MapControllers();
app.Run();
