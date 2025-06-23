using Hospital_Managment.Model;

namespace Hospital_Managment.Repositories
{
    public class InMemoryAppointmentRepository : IAppointmentRepository
    {
        private readonly List<Appointment> _appointments = new();
        private int _nextId = 1;

        public IEnumerable<Appointment> GetAll() => _appointments;

        public Appointment? GetById(int id) => _appointments.FirstOrDefault(a => a.Id == id);

        public void Add(Appointment appointment)
        {
            appointment.Id = _nextId++;
            _appointments.Add(appointment);
        }

        public void Update(int id, Appointment updated)
        {
            var existing = GetById(id);
            if (existing == null) return;

            existing.PatientName = updated.PatientName;
            existing.DoctorName = updated.DoctorName;
            existing.StartDate = updated.StartDate;
            existing.EndDate = updated.EndDate;
        }

        public void Delete(int id)
        {
            var appt = GetById(id);
            if (appt != null) _appointments.Remove(appt);
        }
    }
}
