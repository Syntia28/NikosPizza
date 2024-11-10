using Microsoft.OpenApi.Models;
using NikosPizza.Infraestructure;
using NikosPizza.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddApplicationServices();

builder.Services.AddInfrectuctureServicePizza(builder.Configuration);
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NikosPizza.API", Version = "v1" });
});

builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
   // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NikosPizza.API v1"));
}

//app.UseHttpsRedirection();
app.UseStaticFiles(); // Esto permite servir archivos estáticos (CSS, JS, imágenes, etc.)
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllers();
app.Run();
