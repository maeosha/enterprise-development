using Clinic.Models.Enums;

namespace Clinic.Models.Entities
{
    public class Patient
    {
        public required string PassportNumber { get; set; }
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public string? Patronymic { get; set; }
        public required Gender Gender { get; set; }
        public required DateTime BirthDate { get; set; }
        public required string Address { get; set; }
        public required BloodGroup BloodGroup { get; set; }
        public required RhesusFactor RhesusFactor { get; set; }
        public required string PhoneNumber { get; set; }

        public Patient() { }

        public string GetFullName()
        {
            if (Patronymic == null)
            {
                return $"{LastName} {FirstName}";
            }
            return $"{LastName} {FirstName} {Patronymic}";
        }
    }
}