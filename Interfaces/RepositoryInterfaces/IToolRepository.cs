using Microsoft.Extensions.Hosting;
using onlinetools.Models;

namespace onlinetools.Interfaces.RepositoryInterFaces
{
    public interface IToolRepository
    {
        Task<List<Tool>> GetAll();
        Task<Tool> GetById(int id);
        Task Add(Tool tool);
        Task Edit(Tool tool);
        Task Delete(int id);
    }
}
