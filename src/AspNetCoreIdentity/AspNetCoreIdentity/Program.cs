using KissLog;
using KissLog.AspNetCore;
using KissLog.CloudListeners.Auth;
using KissLog.CloudListeners.RequestLogsListener;
using KissLog.Formatters;
using Microsoft.EntityFrameworkCore;
using AspNetCoreIdentity.Config;

var builder = WebApplication.CreateBuilder(args);

//SETANDO OS ARQUIVOS DO APPSETTINGS PARA TODOS OS AMBIENTES
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json",true,true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json",true,true)
    .AddEnvironmentVariables();

//CASO SEJA O AMBIENTE DE PRODUÇÃO ELE PEGA OS DADOS DA PRÓPRIA MÁQUINA
if (builder.Environment.IsProduction())
{
    builder.Configuration.AddUserSecrets<Program>();
}

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
    app.UseExceptionHandler("/erro/500");
    app.UseStatusCodePagesWithRedirects("/erro/{0}");
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

app.UseKissLogMiddleware(options => {
    options.Listeners.Add(new RequestLogsApiListener(new Application(
        builder.Configuration["KissLog.OrganizationId"],    //  "46163ad1-19b3-402e-802e-3457ef288160"
        builder.Configuration["KissLog.ApplicationId"])     //  "67015c81-7405-4e9e-a74b-3ad0c76e7b17"
    )
    {
        ApiUrl = builder.Configuration["KissLog.ApiUrl"]    //  "https://api.kisslog.net"
    });
});

app.Run();
