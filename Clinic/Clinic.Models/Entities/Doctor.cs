using System.Collections.Generic;
using Clinic.Models.ReferenceBooks;

namespace Clinic.Models.Entities
{
    public class Doctor
    {
        public required string PassportNumber { get; set; }  
        public required string LastName { get; set; }        
        public required string FirstName { get; set; }       
        public string? Patronymic { get; set; }             
        public required int BirthYear { get; set; }         
        public required List<Specialisation> Specializations { get; set; }
        public required int ExperienceYears { get; set; } 

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