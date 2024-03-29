using GerenciamentoDeClientes.Data;
using GerenciamentoDeClientes.Services;
using System.Data;
using System.Data.SqlClient;
    
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connString = builder.Configuration.GetConnectionString("sqlServer");

builder.Services.AddScoped<IDbConnection>(db => new SqlConnection(connString));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<Service>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
