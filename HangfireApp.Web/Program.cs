using FluentValidation;
using FluentValidation.AspNetCore;
using Hangfire;
using HangfireApp.Web.Models;
using HangfireApp.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// EmailService
builder.Services.AddScoped<IEmailService, EmailService>();

// EmailService
builder.Services.AddScoped<IWatermarkService, WatermarkService>();

// EmailReportService
builder.Services.AddScoped<IEmailReportService, EmailReportService>();

// WatermarkInformService
builder.Services.AddScoped<IWatermarkInformService, WatermarkInformService>();

// Hangfire
var connectionString = builder.Configuration.GetConnectionString("HangfireConnection");
builder.Services.AddHangfire(config => config.UseSqlServerStorage(connectionString));

builder.Services.AddHangfireServer();

// Add services to the container.
builder.Services.AddControllersWithViews();

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<PictureSaveVM>();

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

// Hangfire
app.UseHangfireDashboard();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
