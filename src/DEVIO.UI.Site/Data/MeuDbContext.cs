using DEVIO.UI.Site.Models;
using Microsoft.EntityFrameworkCore;

namespace DEVIO.UI.Site.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options)
            : base(options) 
        {

        }

        public  DbSet<Aluno>  Alunos { get; set; }
    }
}
