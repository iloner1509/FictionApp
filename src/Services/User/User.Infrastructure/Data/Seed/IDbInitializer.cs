using System.Threading.Tasks;

namespace User.Infrastructure.Data.Seed
{
    public interface IDbInitializer
    {
        Task Initialize();
    }
}