using CityHospital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CityHospital.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AppointmentDate { get; set; }

        [Required]
        public int DoctorId { get; set; }        

        [Required]
        public int PatientId { get; set; }
    }
}