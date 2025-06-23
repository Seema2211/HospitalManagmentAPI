using System.ComponentModel.DataAnnotations;

namespace Hospital_Managment.Model
{
    public class Appointment
    {
        public int Id { get; set; }
        [Required]
        public string PatientName { get; set; } = string.Empty;
        [Required]
        public string DoctorName { get; set; } = string.Empty;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
