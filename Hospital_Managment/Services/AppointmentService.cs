using Hospital_Managment.Model;
using Hospital_Managment.Repositories;

namespace Hospital_Managment.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repo;

        public AppointmentService(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Appointment> GetAll() => _repo.GetAll();
        public Appointment? Get(int id) => _repo.GetById(id);
        public async Task<bool> Create(Appointment appt)
        {
            if (_repo.GetAll().Any(a =>
                a.DoctorName.Equals(appt.DoctorName, StringComparison.OrdinalIgnoreCase) &&
                (a.StartDate.Date <= appt.StartDate.Date && a.StartDate.Date >= appt.EndDate.Date) &&
                (a.EndDate.Date <= appt.StartDate.Date && a.EndDate.Date >= appt.EndDate.Date)))
               
            {
                return await Task.FromResult(false);
            }

            _repo.Add(appt);
            return await Task.FromResult(true);
        }
        public async Task<bool> Update(int id, Appointment appt)
        {
            if (_repo.GetAll().Any(a =>
                a.DoctorName.Equals(appt.DoctorName, StringComparison.OrdinalIgnoreCase) && (a.Id != id) &&
                (a.StartDate.Date <= appt.StartDate.Date && a.StartDate.Date >= appt.EndDate.Date) &&
                (a.EndDate.Date <= appt.StartDate.Date && a.EndDate.Date >= appt.EndDate.Date)))

            {
                return await Task.FromResult(false);
            }

            _repo.Update(id, appt);
            return await Task.FromResult(true);
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
