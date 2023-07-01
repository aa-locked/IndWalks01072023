using AutoMapper;
using IndWalks.API.Data;
using IndWalks.API.Model.Domain;
using IndWalks.API.Model.DTO;
using IndWalks.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IndWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class RegionsController : ControllerBase
    {
        private readonly IndWalksDBContext _dbContext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IndWalksDBContext dBContext, IRegionRepository regionRepository, IMapper mapper)
        {
            _dbContext = dBContext;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            //var result = new List<Region>{
            //    new Region
            //    {
            //        Id=Guid.NewGuid(),
            //        Name="Neral Region",
            //        Code="NR",
            //        RegionImageUrl= "https://en.wikipedia.org/wiki/Neral,_India#/media/File:Neral_ganesh_ghat.jpg"
            //    },
            //};
            //var result = _dbContext.Regions.ToList();

            //var result = _dbContext.Regions.ToList();
            //return Ok(result);


            //Get Data from Database
            var resultDomain = await _regionRepository.GetAllAsync();
            //Map Domain Model to DTOs

            var regionDto = new List<RegionDTO>();
            foreach (var region in resultDomain)
            {
                regionDto.Add(new RegionDTO()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl,
                });
            }
            // by using mapper

            regionDto =_mapper.Map<List<RegionDTO>>(resultDomain);

            // Return DTOs
            return Ok(regionDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            //Find is only works on primary Key
            var region1 = _dbContext.Regions.Find(id);

            //First Or Default works on All the fields
            var region = _dbContext.Regions.FirstOrDefault(x => x.Id == id);

            //By Using repository

            region = await _regionRepository.GetRegionById(id);


            if (region == null)
            {
                return NotFound();
            }
            return Ok(region);
        }

        //Post To Create A New Region
        //Post : https://localhost:portnumber/api/Regions
        [HttpPost]
           [Authorize]
        public async Task<IActionResult> CreateNewRegion([FromBody] AddRegionReqDTO addRegionReqDTO)
        {
            //Map And Convert DTO To Domain Model
            var regionDomainModel = new Region()
            {
                Code = addRegionReqDTO.Code,
                Name = addRegionReqDTO.Name,
                RegionImageUrl = addRegionReqDTO.RegionImageUrl,
            };

            // Use Domain Model To Create Region

            await _dbContext.Regions.AddAsync(regionDomainModel);
            await _dbContext.SaveChangesAsync();

            //Map RegionDomain To RegionDTO
            var region = new RegionDTO()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            // Return Created At Action 201
            return CreatedAtAction(nameof(GetRegionById), new { id = region.Id }, region);

        }

        //Update Region
        //Put : https://localhost:portnumber/api/Regions
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionReqDTO updateRegionReqDTO)
        {
            var regionDomain = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            regionDomain.Code = updateRegionReqDTO.Code;
            regionDomain.Name = updateRegionReqDTO.Name;
            regionDomain.RegionImageUrl = updateRegionReqDTO.RegionImageUrl;
            await _dbContext.SaveChangesAsync();

            var regionDto = new RegionDTO()
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            return Ok(regionDto);

        }

        //Deelete Region
        //https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var regionDomain = await _dbContext.Regions.FirstOrDefaultAsync(y => y.Id == id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            //Delete Region
            _dbContext.Regions.Remove(regionDomain);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
