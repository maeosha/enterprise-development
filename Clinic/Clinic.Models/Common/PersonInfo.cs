using Clinic.Models.Enums;

namespace Clinic.Models.Common;

/// <summary>
/// Represents personal information for a person.
/// </summary>
public class PersonInfo
{
    /// <summary>
    /// Gets or sets the unique identifier.
    /// </summary>
    required public int Id { get; set; }

    /// <summary>
    /// Gets or sets the passport number.
    /// </summary>
    required public string PassportNumber { get; set; }

    /// <summary>
    /// Gets or sets the year of birth.
    /// </summary>
    required public DateOnly BirthDate { get; set; }

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    required public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    required public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the patronymic.
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Gets or sets the gender.
    /// </summary>
    required public Gender Gender { get; set; }

    /// <summary>
    /// Gets the full name composed of last name, first name and optional patronymic.
    /// </summary>
    /// <returns>The full name as a single string.</returns>
    public string GetFullName()
    {
        if (string.IsNullOrEmpty(Patronymic))
        {
            return $"{LastName} {FirstName}";
        }
        return $"{LastName} {FirstName} {Patronymic}";
    }
}