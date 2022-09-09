﻿using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// RateLimiting için gerekli Servisler
builder.Services.AddOptions();

builder.Services.AddMemoryCache();

var IpRateLimiting = builder.Configuration.GetSection("IpRateLimiting");
builder.Services.Configure<IpRateLimitOptions>(IpRateLimiting);

var IpRateLimitPolicies = builder.Configuration.GetSection("IpRateLimitPolicies");
builder.Services.Configure<IpRateLimitPolicies>(IpRateLimitPolicies);

builder.Services.AddInMemoryRateLimiting();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

// Api birden fazla sunucuda ayağa kaldırılacaksa kullanılır.
//builder.Services.AddSingleton<IIpPolicyStore, DistributedCacheIpPolicyStore>(); 
//builder.Services.AddSingleton<IRateLimitCounterStore, DistributedCacheRateLimitCounterStore>();


var app = builder.Build();

var IpPolicy = app.Services.GetRequiredService<IIpPolicyStore>();
IpPolicy.SeedAsync().Wait();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// RateLimiting için gerekli middleware
app.UseIpRateLimiting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();