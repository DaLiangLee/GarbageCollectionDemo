using Garbage.Models;
using Microsoft.EntityFrameworkCore;
using Tv.Models;

namespace Tv.Database
{
    public class TvContext : DbContext
    {
        public TvContext(DbContextOptions<TvContext> options)
            : base(options)
        {

        }
        public DbSet<TvNetwork> TvNetworks { get; set; }
        public DbSet<TvShow> TvShows { get; set; }
        public DbSet<GCCategory> GCCategories { get; set; }
        public DbSet<GCSubCategory> GCSubCategories { get; set; }
        public DbSet<GarbageModel> Garbages { get; set; }
    }
}