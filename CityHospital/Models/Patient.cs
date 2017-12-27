using System;
using System.ComponentModel.DataAnnotations;

namespace CityHospital.Models
{
    public class Patient
    {
            public int Id { get; set; }

            [StringLength(20)]
            [Display(Name = "First Name")]
            [Required]
            public string FirstName { get; set; }

            [StringLength(20)]
            [Display(Name = "Surame")]
            [Required]
            public string LastName { get; set; }

            [Display(Name = "Date of Join")]
        
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime? DateOfJoin { get; set; }
        
            public Gender Gender { get; set; }

            [Required]
            [Display(Name ="Gender")]
            public int? GenderId { get; set; }

            public BloodGroup BloodGroup { get; set; }

            [Display(Name = "Blood Group")]
            [Required]
            public int? BloodGroupId { get; set; }

            public int? Age { get; set; }

            [Display(Name = "Phone")]
            [Range(1000000000, 9999999999, ErrorMessage ="The field Phone must be a 10 digit number")]
            public long? CellPhone { get; set; }

            [StringLength(20)]
            [Required]        
            public string Address { get; set; }

            [StringLength(20)]
            [Required]
            public string Disease { get; set; }

    }
}