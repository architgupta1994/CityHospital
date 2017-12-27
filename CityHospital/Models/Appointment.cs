using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CityHospital.Models
{
    public class Appointment
    {
        [Display(Name ="Appointment Id")]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Appointment Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AppointmentDate { get; set; }


        public Doctor Doctors { get; set; }

        [Required]
        [Display(Name ="Doctor")]
        public int DoctorId { get; set; }

        public Patient Patients { get; set; }

        [Required]
        [Display(Name = "Patient")]
        public int PatientId { get; set; }
               
    }
}