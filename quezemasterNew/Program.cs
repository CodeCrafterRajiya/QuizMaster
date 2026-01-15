using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using quezemasterNew.Data;
using quezemasterNew.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<QuizeMasterNewContext>(options =>
    options.UseSqlServer(connectionString));



builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


// ✅ Redirect root URL to login
app.MapGet("/", async context =>
{
    if (context.User.Identity != null && context.User.Identity.IsAuthenticated)
    {
        // Redirect to dashboard if already logged in
        context.Response.Redirect("/Home/NewDashboard");
    }
    else
    {
        // Otherwise, redirect to login
        context.Response.Redirect("/Identity/Account/Login");
    }
    await Task.CompletedTask;
});



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=NewDashboard}/{id?}");
app.MapRazorPages();

app.Run();
