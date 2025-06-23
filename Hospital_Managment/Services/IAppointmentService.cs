using Hospital_Managment.Model;

namespace Hospital_Managment.Services
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAll();
        Appointment? Get(int id);
        Task<bool> Create(Appointment appt);
        Task<bool> Update(int id, Appointment appt);
        void Delete(int id);
    }
}
