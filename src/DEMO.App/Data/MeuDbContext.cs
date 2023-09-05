using DEMO.App.Models;
using Microsoft.EntityFrameworkCore;

namespace DEMO.App.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options)
        : base(options)
        {
            
        }

        public DbSet<Aluno> Alunos { get; set; }    

    }
}
