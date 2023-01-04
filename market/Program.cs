using market.Data.Context;
using market.Data.Contracts.UnitsOfWork;
using market.Data.UnitsOfWork;
using market.Domain.DataEntities.User;
using market.Host.Areas.Identity.Factory;
using market.Host.Extentions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;    
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDBContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDBContextConnection' not found.");


builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

const string defaultCulture = "en-GB";
var supportedCultures = new[]
{
    new CultureInfo(defaultCulture),
    new CultureInfo("uk")
};

builder.Services.Configure<RequestLocalizationOptions>(options => {
    options.DefaultRequestCulture = new RequestCulture(defaultCulture);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.FallBackToParentUICultures = true;

});

builder.Services.AddControllersWithViews()
    .AddDataAnnotationsLocalization()
    .AddViewLocalization();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddRazorPages().AddViewLocalization();

builder.Services.AddTransient<IViewLocalizer, ViewLocalizer>();

builder.Services.AddScoped<RequestLocalizationCookiesMiddleware>();

builder.Services.AddMvc();

builder.Services.AddDbContext<AppDBContext>();

builder.Services.AddIdentity<UserEntity, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddEntityFrameworkStores<AppDBContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

IConfiguration configuration = null;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;


})
    .AddCookie(options =>
    {
        options.LoginPath = "/account/google-login";
    })
    .AddGoogle(options =>
    {
        options.ClientId = configuration.GetValue<string>("ClientId");
        options.ClientSecret = configuration.GetValue<string>("ClientSecret");

        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

    });

/*
builder.Services.AddAuthentication();
*/


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole",
         policy => policy.RequireRole("Administrator"));
});



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUserClaimsPrincipalFactory<UserEntity>, ApplicationUserClaimsPrincipalFactory>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


configuration = app.Services.GetRequiredService<IConfiguration>();



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.UseRequestLocalizationCookies();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();


app.MapControllerRoute(
    name: "search",
    pattern: "{controller=Search}/{action=Index}/{request?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
