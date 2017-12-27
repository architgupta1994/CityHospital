using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CityHospital.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }

        [StringLength(20)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(20)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Date of Join")]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfJoin { get; set; }

        public int? GenderId { get; set; }

        [Required]
        public int? BloodGroupId { get; set; }

        public int? Age { get; set; }

        [Range(1000000000, 9999999999, ErrorMessage = "The field Phone must be a 10 digit number")]
        public long? CellPhone { get; set; }

        [StringLength(20)]
        [Required]
        public string Address { get; set; }

        [StringLength(20)]
        [Required]
        public string Disease { get; set; }
    }
}