using IndWalks.API.Data;
using IndWalks.API.Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace IndWalks.API.Repository.Walks
{
    public class WalksRepository : IWalksRepository
    {
        private readonly IndWalksDBContext _indWalksDBContext;

        public WalksRepository(IndWalksDBContext indWalksDBContext)
        {
            _indWalksDBContext = indWalksDBContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _indWalksDBContext.Walks.AddAsync(walk);
            await _indWalksDBContext.SaveChangesAsync();
            return walk;
        }

        public async Task<string?> Delete(Guid id)
        {
            var existwalk = await _indWalksDBContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existwalk == null)
            {
                return null;
            }
            _indWalksDBContext.Walks.Remove(existwalk);
            await _indWalksDBContext.SaveChangesAsync();
            return "Region Deleted Successfully!";
        }

        public async Task<List<Walk>> GetAllAsync(int PageNumber, int RecordsonPage, string? WordToFilter, string? ColumnName, string OrderByClmName = null
            , bool? IsDesc = false)
        {
            var walkresult = _indWalksDBContext.Walks.Include("Difficulty").Include("region").AsQueryable();

            //Filtering
            if (WordToFilter != null && ColumnName != null)
            {
                if (WordToFilter.Length > 0 && ColumnName.Length > 0)
                {
                    if (ColumnName == "Name")
                    {
                        walkresult = walkresult.Where(x => x.Name.Contains(WordToFilter));
                    }
                    else if (ColumnName == "Description")
                    {
                        walkresult = walkresult.Where(x => x.Description.Contains(WordToFilter));
                    }

                }
            }

            //Ordering
            if(OrderByClmName!=null)
            {
                if(OrderByClmName.Length>0)
                {
                    if(IsDesc==true)
                    {
                        if (OrderByClmName.Equals("name", StringComparison.OrdinalIgnoreCase))
                        {
                            walkresult = walkresult.OrderByDescending(x => x.Name);
                        }
                        else if(OrderByClmName == "Description")
                        {
                            walkresult = walkresult.OrderByDescending(x => x.Description);
                        }
                        else if (OrderByClmName == "LengthInKm")
                        {
                            walkresult = walkresult.OrderByDescending(x => x.LengthInKm);
                        }

                    }
                    else
                    {
                        if (OrderByClmName.Equals("name", StringComparison.OrdinalIgnoreCase))
                        {
                            walkresult = walkresult.OrderBy(x => x.Name);
                        }
                        else if (OrderByClmName == "Description")
                        {
                            walkresult = walkresult.OrderBy(x => x.Description);
                        }
                        else if (OrderByClmName == "LengthInKm")
                        {
                            walkresult = walkresult.OrderBy(x => x.LengthInKm);
                        }
                    }
                }
            }


            //Pagination
            //(2-1)*5
            var skipresult = (PageNumber - 1) * RecordsonPage;


            return await walkresult.Skip(skipresult).Take(RecordsonPage).ToListAsync();


            //var walkresult = await _indWalksDBContext.Walks.Include("Difficulty").Include("region").ToListAsync();
            //return walkresult;
        }

        public async Task<Walk?> GetById(Guid id)
        {
            return await _indWalksDBContext.Walks.Include("Difficulty").Include("region").FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Walk?> UpdateWalk(Guid id, Walk walk)
        {
            var exist = await _indWalksDBContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null)
            {
                return null;
            }
            exist.Name = walk.Name;
            exist.Description = walk.Description;
            exist.WalkImageUrl = walk.WalkImageUrl;
            exist.DifficultyId = walk.DifficultyId;
            exist.RegionId = walk.RegionId;

            await _indWalksDBContext.SaveChangesAsync();
            return exist;
        }
    }
}
