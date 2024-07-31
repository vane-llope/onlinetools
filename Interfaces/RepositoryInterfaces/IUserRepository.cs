

using onlinetools.Models;

namespace onlinetools.Interfaces.RepositoryInterFaces
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<User> FindUserByIEmail(string email);
        Task<List<User>> GetAll();
        Task Add(User user);
        Task Edit(User user);
        Task Delete(int id);
        
    }
}
