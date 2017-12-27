using CityHospital.Models;
using System.Collections.Generic;

namespace CityHospital.ViewModels
{
    public class PatientFormViewModel
    {
        public IEnumerable<Gender> Genders { get; set; }
        public IEnumerable<BloodGroup> BloodGroups { get; set; }
        public Patient Patients { get; set; }
        public string Title
        {
            get
            {   
                if (Patients.Id!=0)
                    return "Edit Patient";

                return "Register Patient";
            }
        }
        
    }
}