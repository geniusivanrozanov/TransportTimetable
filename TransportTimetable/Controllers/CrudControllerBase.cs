using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Design;
using TransportTimetable.BLL.Interfaces;
using TransportTimetable.Interfaces;

namespace TransportTimetable.Controllers;

public abstract class CrudControllerBase<TService, TDto, TViewModel, TViewModelForCreation, TViewModelForUpdate> : ControllerBase
    where TService : IServiceBase<TDto>
    where TViewModel : IViewModel
    where TViewModelForCreation : IViewModelForCreation
    where TViewModelForUpdate : IViewModelForUpdate
    where TDto : IDto<Guid>
{
    protected readonly TService Service;
    protected readonly IMapper Mapper;

    protected CrudControllerBase(TService service, IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }

    [HttpGet]
    public virtual async Task<IActionResult> Get()
    {
        var dto = await Service.GetAll();

        var viewModels = Mapper.Map<IEnumerable<TViewModel>>(dto);

        return Ok(viewModels);
    }
    
    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetById(Guid id)
    {
        var dto = await Service.GetById(id);

        if (dto == null)
        {
            return NotFound();
        }
        
        var viewModel = Mapper.Map<TViewModel>(dto);

        return Ok(viewModel);
    }

    [HttpPost]
    public virtual async Task<IActionResult> Post([FromBody] TViewModelForCreation viewModelForCreation)
    {
        var dto = Mapper.Map<TDto>(viewModelForCreation);
            
        await Service.Create(dto);
    
        var resultViewModel = Mapper.Map<TViewModel>(dto);
        
        return CreatedAtAction(nameof(GetById), new { id = resultViewModel.Id }, resultViewModel);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Put(Guid id, [FromBody] TViewModelForUpdate vm)
    {
        if (!await Service.IsExist(id))
        {
            return NotFound();
        }

        var dto = Mapper.Map<TDto>(vm);
            
        await Service.Update(id, dto);

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (!await Service.IsExist(id))
        {
            return NotFound();
        }
            
        await Service.Delete(id);

        return NoContent();
    }
}