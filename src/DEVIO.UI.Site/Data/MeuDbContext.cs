using Microsoft.EntityFrameworkCore;

namespace DEVIO.UI.Site.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options)
            : base(options) 
        {

        }
    }
}
