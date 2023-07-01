using IndWalks.API.Data;
using IndWalks.API.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace IndWalks.API.Repository
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly IndWalksDBContext _dbcontext;
        public SQLRegionRepository(IndWalksDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
           return await _dbcontext.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionById(Guid id)
        {
            return await _dbcontext.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
