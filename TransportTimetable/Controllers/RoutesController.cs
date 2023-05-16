using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportTimetable.BLL.DataTransferObjects;
using TransportTimetable.BLL.Interfaces;
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
    }
}
