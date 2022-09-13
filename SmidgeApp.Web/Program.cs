using Smidge;
using Smidge.Cache;
using Smidge.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Smidge
var smidge = builder.Configuration.GetSection("smidge");
builder.Services.AddSmidge(smidge);

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

app.UseAuthorization();

app.UseSmidge(bundle =>
{
    bundle.CreateJs("myJsBundle", "~/js/")
    .WithEnvironmentOptions(
        BundleEnvironmentOptions
        .Create()
        .ForDebug(
            builder => builder.EnableCompositeProcessing()
            .EnableFileWatcher()
            .SetCacheBusterType<AppDomainLifetimeCacheBuster>()
            .CacheControlOptions(enableEtag: false, cacheControlMaxAge: 0))
    .Build());

    bundle.CreateCss("myCssBundle", "~/css/site.css", "~/lib/bootstrap/dist/css/bootstrap.css");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
