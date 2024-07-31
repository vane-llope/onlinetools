using onlinetools.Models;

namespace onlinetools.Interfaces.RepositoryInterfaces
{
    public interface ISubToolsRepository
    {
        Task<List<SubTool>> GetAll(int toolId);
        Task<SubTool> GetById(int id);
        Task Add(SubTool subTool);
        Task Edit(SubTool subTool);
        Task Delete(int id);
    }
}
