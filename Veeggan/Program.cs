using Microsoft.EntityFrameworkCore;
using Veegan.Data.Access.Repository;
using Veegan.Data.Access.Repository.IRepository;
using System;
using Microsoft.AspNetCore.Identity;
using Veegan.Data.Access.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Vegan.Utility;


// THIS IS THE CONTAINER 

var builder = WebApplication.CreateBuilder(args);

;
//var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));;



builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
       builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddSingleton<IEmailSender, EmailSender>();
// scope makes it limited to one per request
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


//this builder service allows the authorize in details page to work with videw details
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";

});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
//app.UseEndpoints(endpoints => { endpoints.MapControllers(); endpoints.MapRazorPages(); });
app.Run();