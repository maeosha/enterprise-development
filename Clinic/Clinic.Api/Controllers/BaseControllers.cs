using Microsoft.AspNetCore.Mvc;
using Clinic.Api.Interfaces.Services;
using Clinic.Api.Services;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Clinic.Api.Controllers;

/// <summary>
/// Base controller class that provides common CRUD operations for all controllers.
/// </summary>
/// <typeparam name="TEntity">Entity type for the controller.</typeparam>
/// <typeparam name="TGetDto">DTO type for retrieving entity data.</typeparam>
/// <typeparam name="TCreateDto">DTO type for creating a new entity.</typeparam>
/// <typeparam name="TUpdateDto">DTO type for updating an existing entity.</typeparam>
/// <typeparam name="TService">Service type that implements IBaseService.</typeparam>
public class BaseControllers<TGetDto, TCreateDto, TUpdateDto>(IBaseServices<TGetDto, TCreateDto, TUpdateDto> Service) : ControllerBase
    where TGetDto : class
    where TCreateDto : class
    where TUpdateDto : class
{

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>ActionResult containing a list of all entities.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public virtual ActionResult<IReadOnlyCollection<TGetDto>> GetAll()
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual ActionResult<TGetDto> Get(int id)
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
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual ActionResult<TGetDto> Create(TCreateDto dto)
    {
        var entity = Service.Create(dto);
        if (entity == null)
        {
            return BadRequest("Could not create " + GetEntityName() + ".");
        }
        var id = GetEntityId(entity);
        return CreatedAtAction(nameof(Get), new { id }, entity);
    }

    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="id">The id of the entity to update.</param>
    /// <param name="dto">The update data.</param>
    /// <returns>ActionResult containing the updated entity or NotFound if not found.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual ActionResult<TGetDto> Update(int id, TUpdateDto dto)
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual ActionResult<string> Delete(int id)
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

    /// <summary>
    /// Gets the entity ID using reflection.
    /// </summary>
    /// <param name="entity">The entity DTO.</param>
    /// <returns>The entity ID.</returns>
    protected virtual int GetEntityId(TGetDto entity)
    {
        var idProperty = typeof(TGetDto).GetProperty("Id");
        if (idProperty != null && idProperty.GetValue(entity) is int id)
        {
            return id;
        }
        return 0;
    }
}

