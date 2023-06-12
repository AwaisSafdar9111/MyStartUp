using Microsoft.EntityFrameworkCore;
using PracticeProgram.Migrations;
using PracticeProgram.Repository.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));



builder.Configuration.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Configuration.GetValue<string>("EnviromentName")}.json", optional: true, reloadOnChange: true)
.Build();

builder.Services.AddSingleton<DbConfiguration>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnectionString");

    return new DbConfiguration { ConnectionString = connectionString };
});

builder.Services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
{
    var dbConfig = serviceProvider.GetRequiredService<DbConfiguration>();
    options.UseSqlServer(dbConfig.ConnectionString);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
