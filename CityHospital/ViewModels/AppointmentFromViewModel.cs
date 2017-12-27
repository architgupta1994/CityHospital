using CityHospital.Models;
using System.Collections.Generic;

namespace CityHospital.ViewModels
{
	public class AppointmentFromViewModel
	{
        public IEnumerable<Patient> Patients { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<DepartmentType> Departments { get; set; }
        public Appointment Appointment { get; set; }
        public string Title
        {
            get
            {
                if (Appointment.Id!=0)
                    return "Edit Appointment";

                return "Book Appointment";
            }
        }
    }
}