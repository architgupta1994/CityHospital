using System.ComponentModel.DataAnnotations;

namespace CityHospital.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DepartmentType Department { get; set; }

        [Display(Name="Department")]
        public int DepartmentId { get; set; }
    }
}