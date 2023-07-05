using EstoqueAlarmaq.Application.Interfaces;
using EstoqueAlarmaq.Application.Repositories;
using EstoqueAlarmaq.Infra.Data;
using EstoqueAlarmaq.Infra.Identity;
using EstoqueAlarmaq.Infra.Interfaces;
using EstoqueAlarmaq.Infra.Models;
using EstoqueAlarmaq.Infra.Repositories;
using EstoqueAlarmaq.Services.Interfaces;
using EstoqueAlarmaq.Services.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection");
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(connectionString.Value));

builder.Services.AddIdentity<UserModel, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true; //false
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+"; //idem
    options.Password.RequireNonAlphanumeric = false; //true
    options.Password.RequireUppercase = false; //true;
    options.Password.RequireLowercase = false; //true;
    options.Password.RequireDigit = false; //true;
    options.Password.RequiredUniqueChars = 1; //1;
    options.Password.RequiredLength = 6; //6;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3); //5
    options.Lockout.MaxFailedAccessAttempts = 5; //5
    options.Lockout.AllowedForNewUsers = true; //true		
    options.SignIn.RequireConfirmedEmail = true; //false
    options.SignIn.RequireConfirmedPhoneNumber = false; //false
    options.SignIn.RequireConfirmedAccount = false; //false
})
.AddEntityFrameworkStores<DataContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<IUserApplication, UserApplication>();
builder.Services.AddScoped<IIdentityRepository, IdentityRepository>();
builder.Services.AddScoped<IProductApplication, ProductApplication>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISendMailApplication, SendMailApplication>();
builder.Services.AddScoped<ISendMail, SendMail>();
builder.Services.AddScoped<IParameterRepository, ParameterRepository>();

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//})
//.AddCookie(options =>
//{
//    options.LoginPath = "/Account/Login";
//    options.LogoutPath = "/Account/Logout";
//    options.ExpireTimeSpan = TimeSpan.FromDays(30); // Definir a duração do cookie de autenticação
//    options.SlidingExpiration = true;
//});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "OEstoque"; //AspNetCore.Cookies
    options.Cookie.HttpOnly = true; //true
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5); //14 dias
    options.LoginPath = "/Account/Login"; // /Account/Login
    options.LogoutPath = "/Account/Logout";  // /Account/Logout
    options.AccessDeniedPath = "/Account/AccessDenied"; // /Account/AccessDenied
    options.SlidingExpiration = true; //true - gera um novo cookie a cada requisição se o cookie estiver com menos de meia vida
    options.ReturnUrlParameter = "returnUrl"; //returnUrl
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

await CreateRolesAsync(app);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();

async Task CreateRolesAsync(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using(var scope = scopedFactory.CreateScope())
    {

    }
}


