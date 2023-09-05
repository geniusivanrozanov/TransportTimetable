using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportTimetable.BLL.DataTransferObjects;
using TransportTimetable.BLL.Interfaces;
using TransportTimetable.ViewModels.Stop;

namespace TransportTimetable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopsController : CrudControllerBase<IStopService, StopDto, StopViewModel, StopViewModelForCreation, StopViewModelForUpdate>
    {
        public StopsController(IStopService service, IMapper mapper) : base(service, mapper)
        {
        }

        public override async Task<IActionResult> GetById(Guid id)
        {
            var dto = await Service.GetById(id);
            if (dto == null)
            {
                return NotFound();
            }

            var vm = Mapper.Map<StopWithRoutesViewModel>(dto);

            return Ok(vm);
        }
    }
}
