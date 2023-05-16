using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportTimetable.BLL.DataTransferObjects;
using TransportTimetable.BLL.Interfaces;
using TransportTimetable.ViewModels.TransportType;

namespace TransportTimetable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportTypesController : CrudControllerBase<ITransportTypeService, TransportTypeDto, TransportTypeViewModel, TransportTypeViewModelForCreation, TransportTypeViewModelForUpdate>
    {
        public TransportTypesController(ITransportTypeService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
