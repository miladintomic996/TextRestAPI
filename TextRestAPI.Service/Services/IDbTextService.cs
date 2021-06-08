using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreRepositoryAndUnitOfWorkPattern.Data.Models;

namespace NetCoreRepositoryAndUnitOfWorkPattern.Service.Services
{
    public interface IDbTextService
    {
        Task<List<Text>> GetAllTextsAsync();
        Task<Text> GetTextByIdAsync(int id);
        Task<Text> AddTextAsync(Text newText);
    }
}