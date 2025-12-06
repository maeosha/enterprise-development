using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Interfaces.Controllers;

/// <summary>
/// Base generic interface for controllers providing standard CRUD operations.
/// </summary>
/// <typeparam name="TGetDto">DTO type for retrieving entity data.</typeparam>
/// <typeparam name="TCreateDto">DTO type for creating a new entity.</typeparam>
/// <typeparam name="TUpdateDto">DTO type for updating an existing entity.</typeparam>
public interface IBaseController<TGetDto, TCreateDto, TUpdateDto>
    where TGetDto : class
    where TCreateDto : class
    where TUpdateDto : class
{
    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>ActionResult containing a list of all entities.</returns>
    public IActionResult GetAll();

    /// <summary>
    /// Gets a specific entity by its id.
    /// </summary>
    /// <param name="id">The id of the entity.</param>
    /// <returns>ActionResult containing the entity or NotFound if not found.</returns>
    public IActionResult Get(int id);

    /// <summary>
    /// Creates a new entity.
    /// </summary>
    /// <param name="dto">The creation data.</param>
    /// <returns>ActionResult containing the created entity or BadRequest if creation fails.</returns>
    public IActionResult Create(TCreateDto dto);

    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="id">The id of the entity to update.</param>
    /// <param name="dto">The update data.</param>
    /// <returns>ActionResult containing the updated entity or NotFound if not found.</returns>
    public IActionResult Update(int id, TUpdateDto dto);

    /// <summary>
    /// Deletes an entity by its id.
    /// </summary>
    /// <param name="id">The id of the entity to delete.</param>
    /// <returns>ActionResult indicating success or NotFound if not found.</returns>
    public IActionResult Delete(int id);
}

