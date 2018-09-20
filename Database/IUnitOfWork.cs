using System.Threading.Tasks;

namespace Tv.Database
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}