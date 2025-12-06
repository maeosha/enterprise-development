using Microsoft.AspNetCore.Mvc;
using Clinic.Api.Interfaces.Controllers;
using Clinic.Api.Interfaces.Services;

namespace Clinic.Api.Controllers;

/// <summary>
/// Base controller class that provides common CRUD operations for all controllers.
/// </summary>
/// <typeparam name="TEntity">Entity type for the controller.</typeparam>
/// <typeparam name="TGetDto">DTO type for retrieving entity data.</typeparam>
/// <typeparam name="TCreateDto">DTO type for creating a new entity.</typeparam>
/// <typeparam name="TUpdateDto">DTO type for updating an existing entity.</typeparam>
/// <typeparam name="TService">Service type that implements IBaseService.</typeparam>
public class BaseControllers<TGetDto, TCreateDto, TUpdateDto, TService> : ControllerBase, IBaseController<TGetDto, TCreateDto, TUpdateDto>
    where TGetDto : class
    where TCreateDto : class
    where TUpdateDto : class
    where TService : IBaseServices<TGetDto, TCreateDto, TUpdateDto>
{
    protected readonly TService Service;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseController{TGetDto, TCreateDto, TUpdateDto, TService}"/> class.
    /// </summary>
    /// <param name="service">The service instance for CRUD operations.</param>
    protected BaseControllers(TService service)
    {
        Service = service;
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>ActionResult containing a list of all entities.</returns>
    [HttpGet]
    public virtual IActionResult GetAll()
    {
        var entities = Service.GetAll();
        return Ok(entities);
    }

    /// <summary>
    /// Gets a specific entity by its id.
    /// </summary>
    /// <param name="id">The id of the entity.</param>
    /// <returns>ActionResult containing the entity or NotFound if not found.</returns>
    [HttpGet("{id}")]
    public virtual IActionResult Get(int id)
    {
        var entity = Service.Get(id);
        if (entity == null)
        {
            return NotFound(GetEntityName() + " not found.");
        }
        return Ok(entity);
    }

    /// <summary>
    /// Creates a new entity.
    /// </summary>
    /// <param name="dto">The creation data.</param>
    /// <returns>ActionResult containing the created entity or BadRequest if creation fails.</returns>
    [HttpPost]
    public virtual IActionResult Create(TCreateDto dto)
    {
        var entity = Service.Create(dto);
        if (entity == null)
        {
            return BadRequest("Could not create " + GetEntityName() + ".");
        }
        return Ok(entity);
    }

    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="id">The id of the entity to update.</param>
    /// <param name="dto">The update data.</param>
    /// <returns>ActionResult containing the updated entity or NotFound if not found.</returns>
    [HttpPut("{id}")]
    public virtual IActionResult Update(int id, TUpdateDto dto)
    {
        var entity = Service.Update(id, dto);
        if (entity == null)
        {
            return NotFound(GetEntityName() + " not found.");
        }
        return Ok(entity);
    }

    /// <summary>
    /// Deletes an entity by its id.
    /// </summary>
    /// <param name="id">The id of the entity to delete.</param>
    /// <returns>ActionResult indicating success or NotFound if not found.</returns>
    [HttpDelete("{id}")]
    public virtual IActionResult Delete(int id)
    {
        var result = Service.Delete(id);
        if (!result)
        {
            return NotFound(GetEntityName() + " not found.");
        }
        return Ok(GetEntityName() + " deleted successfully.");
    }

    /// <summary>
    /// Gets the entity name for error messages.
    /// </summary>
    /// <returns>The entity name.</returns>
    protected virtual string GetEntityName()
    {
        var name = typeof(TGetDto).Name;
        return name.Replace("Get", "").Replace("Dto", "");
    }
}

