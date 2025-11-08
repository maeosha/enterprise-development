using Clinic.Models.Common;
using Clinic.Models.ReferenceBooks;

namespace Clinic.Models.Entities;

/// <summary>
/// Represents a doctor with personal and professional details.
/// </summary>
public class Doctor : PersonInfo
{
    /// <summary>
    /// Gets or sets the list of medical specializations the doctor holds.
    /// </summary>
    required public List<Specialization> Specializations { get; set; }

    /// <summary>
    /// Gets or sets the number of years of experience the doctor has.
    /// </summary>
    required public int ExperienceYears { get; set; }
}
