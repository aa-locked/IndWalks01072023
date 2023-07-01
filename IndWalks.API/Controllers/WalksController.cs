using AutoMapper;
using IndWalks.API.CustomActionFilter;
using IndWalks.API.Model.Domain;
using IndWalks.API.Model.DTO.Walks;
using IndWalks.API.Repository.Walks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndWalks.API.Controllers
{
    //api/Walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalksRepository _walksRepository;

        public WalksController(IMapper mapper, IWalksRepository walksRepository)
        {
            _mapper = mapper;
            _walksRepository = walksRepository;
        }

        //Create Walk
        //Post : /api/Walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            if (ModelState.IsValid)
            {
                //Map DTO to Domain Model
                var WalkDomain = _mapper.Map<Walk>(addWalkRequestDTO);
                //Add to Repository
                var walksDomainEwsult = await _walksRepository.CreateAsync(WalkDomain);
                //Map Domain Model to DTO             
                return Ok(_mapper.Map<WalkDTO>(walksDomainEwsult));
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        //Get Walks
        //Get : /api/Walks?filterOn=Name&filterQuery=Track
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int PageNumber = 1, [FromQuery] int RecordsonPage = 200
            , [FromQuery] string? WordToFilter = null, [FromQuery] string? ColumnName = null, [FromQuery] string? OrderByClmName = null
            , [FromQuery] bool? IsDesc = false
            )
        {
            var Result = await _walksRepository.GetAllAsync(PageNumber, RecordsonPage, WordToFilter, ColumnName, OrderByClmName, IsDesc);
            var resultDto = _mapper.Map<List<WalkDTO>>(Result);
            return Ok(resultDto);
        }

        //Get Walk by Id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkdomainmodel = await _walksRepository.GetById(id);
            if (walkdomainmodel == null)
            {
                return NotFound();
            }
            var resutDTO = _mapper.Map<WalkDTO>(walkdomainmodel);
            return Ok(resutDTO);
        }

        //Update Walk
        //Put
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] UpdateWalkReqDTO updateWalkReqDTO)
        {
            //DTO To Domain
            var mappedDomain = _mapper.Map<Walk>(updateWalkReqDTO);
            var result = await _walksRepository.UpdateWalk(id, mappedDomain);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalkDTO>(result));
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _walksRepository.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDTO>(result));
        }
    }
}
