using DEMO.App.Data;
using DEMO.App.Servicos;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Adicionando o MVC
builder.Services.AddMvc();

//Adicionando o IConfiguration
var configuration = builder.Configuration;

builder.Services.Configure<RazorViewEngineOptions>(option =>
{
    option.AreaViewLocationFormats.Clear();
    option.AreaViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
    option.AreaViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
    option.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
});

//ADICIONANDO O DBCONTEXT
builder.Services.AddDbContext<MeuDbContext>(options => 
    options.UseSqlServer(configuration.GetConnectionString("MeuDbContext")));

// Add services to the container.
builder.Services.AddRazorPages();

//builder.Services.AddTransient<PedidoRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();

builder.Services.AddTransient<IOperacaoTransient, Operacao>();
builder.Services.AddScoped<IOperacaoScoped, Operacao>();
builder.Services.AddSingleton<IOperacaoSingleton, Operacao>();
builder.Services.AddSingleton<IOperacaoSingletonInstance>(new Operacao(Guid.Empty));

builder.Services.AddTransient<OperacaoService>();

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


//app.MapControllerRoute(
//    name: "areas",
//    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute("AreaProdutos", "Produtos", "Produtos/{controller=Cadastro}/{action=Index}/{id?}");
app.MapAreaControllerRoute("AreaVendas", "Vendas", "Vendas/{controller=Pedidos}/{action=Index}/{id?}");

app.UseAuthorization();

app.MapRazorPages();


app.Run();
