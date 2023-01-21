using Microsoft.EntityFrameworkCore;

namespace Surasshu.Data
{
    public class SurasshuContext : DbContext
    {
        public SurasshuContext(DbContextOptions<SurasshuContext> options)
            : base(options)
        {
        }

    }
}
