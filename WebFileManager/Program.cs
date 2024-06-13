using GleamTech.AspNet.Core;


var builder = WebApplication.CreateBuilder(args);

//Change Root Path from Appsettings.json
var rootFolder = builder.Configuration.GetSection("RootFolder").Value;
Console.WriteLine(rootFolder);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddGleamTech();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseGleamTech();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
