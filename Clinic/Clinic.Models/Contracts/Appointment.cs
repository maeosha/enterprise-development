using Clinic.Models.Entities;

namespace Clinic.Models.Contracts
{
    public class Appointment
    {
        public required Patient Patient { get; set; }
        public required Doctor Doctor { get; set; }
        public required DateTime DateTime { get; set; }
        public required int RoomNumber { get; set; }
        public required bool IsReturnVisit { get; set; }


    }
}