using System.Threading.Tasks;

namespace Tv.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TvContext context;

        public UnitOfWork(TvContext context)
        {
            this.context = context;
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}