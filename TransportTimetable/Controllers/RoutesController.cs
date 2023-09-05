using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportTimetable.BLL.DataTransferObjects;
using TransportTimetable.BLL.Interfaces;
using TransportTimetable.DAL.Repositories;
using TransportTimetable.ViewModels.Route;

namespace TransportTimetable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : CrudControllerBase<IRouteService, RouteDto, RouteViewModel, RouteViewModelForCreation, RouteViewModelForUpdate>
    {
        public RoutesController(IRouteService service, IMapper mapper) : base(service, mapper)
        {
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public override async Task<IActionResult> GetById(Guid id)
        {
            var dto = await Service.GetById(id);
            if (dto == null)
            {
                return NotFound();
            }

            var vm = Mapper.Map<RouteWithStopsViewModel>(dto);

            return Ok(vm);
        }

        [HttpPut("{id}/stops")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutStops([FromRoute]Guid id, [FromBody]IEnumerable<Guid> ids)
        {
            if (! await Service.IsExist(id))
            {
                return NotFound();
            }

            await Service.PutStops(id, ids);
            
            return NoContent();
        }
    }
}
