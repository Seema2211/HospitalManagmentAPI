
# 🏥 Hospital Appointment Management API (In-Memory)

A lightweight .NET 8 Web API project for managing hospital appointments using **in-memory storage**. The architecture follows **SOLID principles** and applies the **Repository** and **Service** design patterns.




## 🚀 How to Run

1. **Clone the project**  
   ```bash
   git clone https://github.com/your-username/hospital-appointments-api.git
   cd hospital-appointments-api




2.  Run the API

dotnet run


3. Test the API

https://localhost:5001/swagger



| Method | Endpoint              | Description              |
| ------ | --------------------- | ------------------------ |
| GET    | `/api/appointments`   | Get all appointments     |
| GET    | `/api/appointments/1` | Get appointment by ID    |
| POST   | `/api/appointments`   | Create a new appointment |
| PUT    | `/api/appointments/1` | Update an appointment    |
| DELETE | `/api/appointments/1` | Delete an appointment    |




---

## 📁 Project Structure

/Controllers → API endpoints
/Services → Business logic (AppointmentService)
/Repositories → In-memory data access layer
/Models → Data model (Appointment)
Program.cs → App configuration and DI setup


---

## ✅ Features

- 📅 **Create / Read / Update / Delete** appointments
- 🔁 Prevent overlapping appointments for the same doctor
- 🛡️ Required field validation using `DataAnnotations`
- 🧠 Clean code using **SOLID** principles
- 💾 No database needed — runs entirely in-memory

---


❌ Overlapping Logic
An appointment is not allowed if the same doctor already has an appointment that overlaps:


// Overlap condition in service layer
a.DoctorName == appt.DoctorName &&
a.StartDate < appt.EndDate &&
appt.StartDate < a.EndDate



🧪 Future Enhancements
Add FluentValidation for richer validation

Use DTOs to separate API and domain models

Implement persistence using EF Core + SQLite

Add unit tests with xUnit + Moq