using Microsoft.OpenApi.Models;
using NikosPizza.Infraestructure;
using NikosPizza.Application;
using NikosPizza.Api.Routes;
using static NikosPizza.Application.ApplicationServiceRegistration;
using Microsoft.AspNetCore.Identity;

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
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<PizzaDbContext>();
builder.Services.AddAuthorization();
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
app.UseStaticFiles(); // Esto permite servir archivos est�ticos (CSS, JS, im�genes, etc.)
app.UseRouting();

app.UseAuthorization();
RouteConfig.RegisterRoutes(app);

app.MapControllers();
app.Run();
