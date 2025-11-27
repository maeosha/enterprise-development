using System.Dynamic;

namespace Clinic.Models.Entities;

/// <summary>
/// Represents a medical specialisation in the clinic.
/// </summary>
public class Specialization
{
    /// <summary>
    /// Gets or sets the id specialization.
    /// </summary>
    required public int Id { get; set; }
    
    /// <summary>
    /// Gets or sets the specialization name.
    /// </summary>
    required public string Name { get; set; }
}
