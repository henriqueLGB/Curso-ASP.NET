using AppMvcBasico.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppMvcBasico.Data;

public class AppMvcBasicoContext : IdentityDbContext<IdentityUser>
{
    public AppMvcBasicoContext(DbContextOptions<AppMvcBasicoContext> options)
        : base(options)
    {
    }

    public DbSet<Produto> produtos { get; set; }    
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
