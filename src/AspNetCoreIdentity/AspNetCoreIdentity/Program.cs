using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AspNetCoreIdentity.Areas.Identity.Data;
using AspNetCoreIdentity.Extensions;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreIdentity.Config;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AspNetCoreIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'AspNetCoreIdentityContextConnection' not found.");


//IDENTITY E DBCONTEXT CONFIGURATION 
//builder.Services.AddDbContext<AspNetCoreIdentityContext>(options =>
//    options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<AspNetCoreIdentityContext>();

//AQUI CADASTRAMOS AS POLICY (CLAIMS)
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("PodeExcluir", policy => policy.RequireClaim("PodeExcluir"));
//    options.AddPolicy("PodeLer", policy => policy.Requirements.Add(new PermissaoNecessaria("PodeLer")));
//    options.AddPolicy("PodeEscrever", policy => policy.Requirements.Add(new PermissaoNecessaria("PodeEscrever")));
//});

//CLASSE RESPONSÁVEL PELO IDENTITY E DBCONTEXT
builder.Services.AddIdentityConfig(connectionString);

//CLASSE RESPONSÁVEL POR ORGANIZAR O IDENTITY (CLAIMS) DO PROJETO
builder.Services.AddAuthorizationConfig();



//INJEÇÃO DO HANDLER CRIADO
//builder.Services.AddSingleton<IAuthorizationHandler, PermissaoNecessariaHandler>();

//CLASSE RESPONSÁVEL POR ORGANIZAR AS DEPÊNDENCIAS DO PROJETO
builder.Services.ResolveDependencies();


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

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

//DEVE-SE COLOCAR O MAPEMANETO DO RAZOR PAGES PARA QUE FUNCIONE O IDENTITY UI
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
