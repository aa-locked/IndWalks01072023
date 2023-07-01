using IndWalks.API.Model.Domain;
namespace IndWalks.API.Repository
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetRegionById(Guid id);
    }
}
