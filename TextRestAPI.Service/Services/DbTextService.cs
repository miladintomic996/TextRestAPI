using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreRepositoryAndUnitOfWorkPattern.Data.Models;
using NetCoreRepositoryAndUnitOfWorkPattern.Data.Repositories;

namespace NetCoreRepositoryAndUnitOfWorkPattern.Service.Services
{
    public class DbTextService : IDbTextService
    {
        private readonly ITextRepository _textRepository;

        public DbTextService(ITextRepository textRepository)
        {
            _textRepository = textRepository;
        }

        public async Task<List<Text>> GetAllTextsAsync()
        {
            return await _textRepository.GetAllTextsAsync();
        }

        public async Task<Text> GetTextByIdAsync(int id)
        {
            return await _textRepository.GetTextByIdAsync(id);
        }

        public async Task<Text> AddTextAsync(Text newText)
        {
            return await _textRepository.AddAsync(newText);
        }
    }
}