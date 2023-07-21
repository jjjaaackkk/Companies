using Companies;
using Companies.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDBContext>(
    options => options.UseInMemoryDatabase(databaseName: "Companies")
    );

// Let's view our pages
builder.Services.AddRazorPages();

// Let's view context
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Debugging in dev mode
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseDeveloperExceptionPage();
}

app.UseRouting();


// minimal API v1
app.MapGroup("/api/v1")
    .MapAPI()
    .WithTags("Public");


app.UseStaticFiles();
app.UseHttpsRedirection();

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();
