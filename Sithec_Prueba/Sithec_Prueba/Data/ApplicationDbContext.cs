using Microsoft.EntityFrameworkCore;
using Sithec_Prueba.Entities;

namespace Sithec_Prueba.Data
{

    public class ApplicationDbContext : DbContext
    {
        public DbSet<EntHumano> Humano { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
    
}
