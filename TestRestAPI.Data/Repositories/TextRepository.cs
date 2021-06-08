using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreRepositoryAndUnitOfWorkPattern.Data.Models;

namespace NetCoreRepositoryAndUnitOfWorkPattern.Data.Repositories
{
    public class TextRepository : Repository<Text>, ITextRepository
    {
        public TextRepository(TextDbContext textDbContext) : base(textDbContext)
        {
        }

        public async Task<Text> GetTextByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Text>> GetAllTextsAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}