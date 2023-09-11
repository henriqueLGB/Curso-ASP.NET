using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AppMvcBasico.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppMvcBasicoContextConnection") ?? throw new InvalidOperationException("Connection string 'AppMvcBasicoContextConnection' not found.");

builder.Services.AddDbContext<AppMvcBasicoContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppMvcBasicoContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


//DEVE-SE COLOCAR O MAPEMANETO DO RAZOR PAGES PARA QUE FUNCIONE O IDENTITY UI
app.MapRazorPages();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
