using Hospital_Managment.Model;
using Hospital_Managment.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Managment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(IAppointmentService service)
        {
            _service = service;
        }
        /// <summary>
        /// Get All Appointments
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Get() => Ok(_service.GetAll());

        /// <summary>
        /// Get Specific appointment details
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _service.Get(id);
            return item != null ? Ok(item) : NotFound();
        }
        /// <summary>
        /// Add Appointment
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Appointment appt)
        {
            var result = await _service.Create(appt);
            return Ok(result);
        }
        /// <summary>
        ///Update existing appointment
        /// </summary>
        /// <returns></returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Appointment appt)
        {
            var existing = _service.Get(id);
            if (existing == null) return NotFound();

            var result = await _service.Update(id, appt);
            return Ok(result);
        }
        /// <summary>
        /// Delete Specific appointment
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _service.Get(id);
            if (existing == null) return NotFound();

            _service.Delete(id);
            return NoContent();
        }
    }
}
