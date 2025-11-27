using Clinic.Models.Common;
using Clinic.Models.Enums;

namespace Clinic.Models.Entities;

/// <summary>
/// Represents a patient entity with personal and medical information.
/// </summary>
public class Patient : PersonInfo
{
    /// <summary>
    /// Gets or sets the patient's address.
    /// </summary>
    required public string Address { get; set; }

    /// <summary>
    /// Gets or sets the patient's blood group.
    /// </summary>
    required public BloodGroup BloodGroup { get; set; }

    /// <summary>
    /// Gets or sets the patient's rhesus factor.
    /// </summary>
    required public RhesusFactor RhesusFactor { get; set; }
}
