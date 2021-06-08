using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreRepositoryAndUnitOfWorkPattern.Data.Models;

namespace NetCoreRepositoryAndUnitOfWorkPattern.Data.Repositories
{
    public interface ITextRepository : IRepository<Text>
    {
        Task<Text> GetTextByIdAsync(int id);

        Task<List<Text>> GetAllTextsAsync();
    }
}