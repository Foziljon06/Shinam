//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Shinam.Api.Brokers;
using Shinam.Api.Brokers.Storages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger sozlamalari
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shinam.Api", Version = "v1" });
});

// Ma'lumotlar bazasini sozlash
builder.Services.AddDbContext<StorageBroker>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// IStorage brokerni qo`shyapman

builder.Services.AddTransient<IstorageBroker,StorageBroker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shinam.Api v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Migratsiyani bajarish
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<StorageBroker>();
    dbContext.Database.Migrate();
}

app.Run(); app.Run();