using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportTimetable.BLL.DataTransferObjects;
using TransportTimetable.BLL.Interfaces;
using TransportTimetable.ViewModels.TimeTable;

namespace TransportTimetable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTablesController : CrudControllerBase<ITimeTableService, TimeTableDto, TimeTableViewModel, TimeTableViewModelForCreation, TimeTableViewModelForUpdate>
    {
        public TimeTablesController(ITimeTableService service, IMapper mapper) : base(service, mapper)
        {
        }

        [HttpGet("byRoteAndStop")]
        public async Task<IActionResult> GetByRouteAndStop(Guid routeId, Guid stopId)
        {
            var dto = await Service.GetByRoteAndStop(routeId, stopId);
            var vm = Mapper.Map<IEnumerable<TimeTableViewModel>>(dto);

            return Ok(vm);
        }
    }
}
