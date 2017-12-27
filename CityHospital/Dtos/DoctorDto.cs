using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityHospital.Dtos
{
    public class DoctorDto
    {
        public int Id { get; set; }

        public string Name { get; set; }        

        public int DepartmentId { get; set; }
    }
}