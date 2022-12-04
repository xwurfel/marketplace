using market.Data.Context;
using market.Data.Contracts.Repositories.Products;
using market.Data.Repositories.Products;
using Microsoft.AspNetCore.Identity;
using market.Domain.DataEntities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.Extensions.Options;
using market.Host.Areas.Identity.Factory;
using market.Host.Extentions;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Localization;
using market.Data.UnitsOfWork;
using market.Data.Contracts.UnitsOfWork;


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

builder.Services.AddRazorPages().AddViewLocalization();

//builder.Services.TryAdd(ServiceDescriptor.Transient<IViewLocalizer, ViewLocalizer>());
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



builder.Services.AddAuthorization(options =>
{
    /*options.AddPolicy("RequireAdministratorRole",
         policy => policy.RequireRole("Administrator"));*/
});



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<IUnitOfWork, EntityFrameworkUnitOfWork>();


builder.Services.AddScoped<IUserClaimsPrincipalFactory<UserEntity>, ApplicationUserClaimsPrincipalFactory>();


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
app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.UseRequestLocalizationCookies();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
    name: "search",
    pattern: "{controller=Search}/{action=Index}/{request?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
