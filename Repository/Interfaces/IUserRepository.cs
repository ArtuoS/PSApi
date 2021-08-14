using PremierAPI.Models;

namespace PremierAPI.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public string GenerateId();
    }
}
