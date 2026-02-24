namespace Clinic.Application.Interfaces.Services;

/// <summary>
/// Generic interface for application services that provides CRUD operations.
/// This interface can be used to type all service functions with specific DTOs and entities.
/// </summary>
/// <typeparam name="TEntity">The entity type used in the database layer.</typeparam>
/// <typeparam name="TGetDto">The DTO type for retrieving entities.</typeparam>
/// <typeparam name="TSaveDto">The DTO type for create and update operations.</typeparam>
public interface IBaseServices<TGetDto, TSaveDto>
    where TGetDto : class
    where TSaveDto : class
{
    /// <summary>
    /// Retrieves all entities from the database and maps them to DTOs.
    /// </summary>
    /// <returns>A read-only collection of DTOs representing all entities.</returns>
    public IReadOnlyCollection<TGetDto> GetAll();

    /// <summary>
    /// Retrieves a single entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity to retrieve.</param>
    /// <returns>The entity as a DTO if found; otherwise, null.</returns>
    public TGetDto? Get(int id);

    /// <summary>
    /// Creates a new entity in the database.
    /// </summary>
    /// <param name="createDto">The DTO containing entity creation data.</param>
    /// <returns>The created entity as a DTO if successful; otherwise, null.</returns>
    public TGetDto? Create(TSaveDto createDto);

    /// <summary>
    /// Updates an existing entity with the given identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity to update.</param>
    /// <param name="updateDto">The DTO containing updated entity data.</param>
    /// <returns>The updated entity as a DTO if successful; otherwise, null.</returns>
    public TGetDto? Update(int id, TSaveDto updateDto);

    /// <summary>
    /// Deletes an entity from the database by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity to delete.</param>
    /// <returns>True if the entity was successfully deleted; otherwise, false.</returns>
    public bool Delete(int id);
}
