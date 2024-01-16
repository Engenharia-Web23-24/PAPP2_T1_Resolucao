using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PAPP2.Models;

namespace PAPP2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UnidadeCurricular> UnidadesCurriculares { get; set; }

        public DbSet<Inscricao> Inscricoes { get; set; }
    }
}
