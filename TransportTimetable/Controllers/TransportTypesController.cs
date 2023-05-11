using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransportTimetable.BLL.DataTransferObjects;
using TransportTimetable.BLL.Interfaces;
using TransportTimetable.ViewModels.TransportType;

namespace TransportTimetable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportTypesController : ControllerBase
    {
        private readonly ITransportTypeService _service;
        private readonly IMapper _mapper;
        
        public TransportTypesController(ITransportTypeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var transportTypes = await _service.GetAll();

            var transportTypesViewModels = _mapper.Map<IEnumerable<TransportTypeViewModel>>(transportTypes);
            
            return Ok(transportTypesViewModels);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetById(Guid id)
        {
            var transportType = await _service.GetById(id);
            
            if (transportType == null)
            {
                return NotFound();
            }
            
            var transportTypeViewModel = _mapper.Map<TransportTypeViewModel>(transportType);

            return Ok(transportTypeViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Post([FromBody] TransportTypeForCreationViewModel vm)
        {
            var transportTypeDto = _mapper.Map<TransportTypeDto>(vm);
            
            await _service.Create(transportTypeDto);

            var resultViewModel = _mapper.Map<TransportTypeViewModel>(transportTypeDto);

            return CreatedAtAction(nameof(GetById), new { id = resultViewModel.Id }, resultViewModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Put(Guid id, [FromBody] TransportTypeForCreationViewModel vm)
        {
            if (!await _service.IsExist(id))
            {
                return NotFound();
            }

            var transportTypeDto = _mapper.Map<TransportTypeDto>(vm);
            transportTypeDto.Id = id;
            
            await _service.Update(id, transportTypeDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _service.IsExist(id))
            {
                return NotFound();
            }
            
            await _service.Delete(id);

            return NoContent();
        }
    }
}
