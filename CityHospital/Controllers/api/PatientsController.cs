using AutoMapper;
using CityHospital.Dtos;
using CityHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace CityHospital.Controllers.api
{
    public class PatientsController : ApiController
    {
        private ApplicationDbContext _context;

        public PatientsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Get: /api/customer 
        /// <summary>
        /// api/patients/GetPatients
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetPatients()
        {
            return Ok(_context.Patients.ToList().Select(Mapper.Map<Patient, PatientDto>));
        }

        /// <summary>
        /// api/patients/GetPatient
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetPatient(int id)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.Id == id);
            if (patient == null)
                return NotFound();

            return Ok(Mapper.Map<Patient, PatientDto>(patient));

        }

        //POST: /api/customer
        /// <summary>
        /// api/patients/CreatePatient
        /// </summary>
        /// <param name="patientDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CreatePatient(PatientDto patientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var patient = Mapper.Map<PatientDto, Patient>(patientDto);
            _context.Patients.Add(patient);
            _context.SaveChanges();
            patientDto.Id = patient.Id;

            return Created(new Uri(Request.RequestUri + "/" + patient.Id), patientDto);
        }

        //PUT: /api/customer/id
        /// <summary>
        /// api/patients/UpdateUpdate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patientDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult UpdateUpdate(int id, PatientDto patientDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var patientInDB = _context.Patients.SingleOrDefault(c => c.Id == id);
            if (patientInDB == null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

            Mapper.Map(patientDto, patientInDB);
            _context.SaveChanges();

            return Ok();

        }

        /// <summary>
        /// DELETE: api/patients/DeletePatient
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult DeletePatient(int id)
        {
            var patientInDB = _context.Patients.SingleOrDefault(p => p.Id == id);

            if (patientInDB == null)
                return NotFound();

            _context.Patients.Remove(patientInDB);
            _context.SaveChanges();

            return Ok();
        }
    }
}
