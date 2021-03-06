using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestApplicationInforce.Areas.Identity.Data;
using TestApplicationInforce.Data;
using TestApplicationInforce.Services;
using TestApplicationInforce.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TestApplicationInforceContextConnection") ?? throw new InvalidOperationException("Connection string 'TestApplicationInforceContextConnection' not found.");

builder.Services.AddDbContext<TestApplicationInforceContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<TestApplicationInforceUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<TestApplicationInforceContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

// Add services to the container.
builder.Services.AddScoped<IShortenerService, ShortenerService>();
builder.Services.AddScoped<IUrlService, UrlService>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
AdminAccount.SetupAdminAccounts(app);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Url}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});
app.Run();
