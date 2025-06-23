using Hospital_Managment.Model;

namespace Hospital_Managment.Repositories
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAll();
        Appointment? GetById(int id);
        void Add(Appointment appointment);
        void Update(int id, Appointment appointment);
        void Delete(int id);
    }
}
