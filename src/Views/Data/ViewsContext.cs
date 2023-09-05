using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Views.Models;

namespace Views.Data
{
    public class ViewsContext : DbContext
    {
        public ViewsContext (DbContextOptions<ViewsContext> options)
            : base(options)
        {
        }

        public DbSet<Views.Models.Veiculos> Veiculos { get; set; } = default!;
    }
}
