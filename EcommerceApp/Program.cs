
using E_Core.Interfaces;
using EcommerceApp.Errors;
using EcommerceApp.Extentions;
using EcommerceApp.Middleware;
using EcommerceClasslib.DBContext;
using Microsoft.EntityFrameworkCore;
using EcommerceClasslib.Data;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddAppServices(builder.Configuration);
var app = builder.Build();
app.UseStatusCodePagesWithReExecute("/error/{0}");
app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}


app.UseAuthorization();
app.UseStaticFiles();
app.UseCors("CorsPolicy");
app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<EContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync();
    await ContextSeed.SeedAsync(context);
}
catch (Exception e)
{
   logger.LogError(e,"An Error occured during migration............................................................");
}



app.Run();
