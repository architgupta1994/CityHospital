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
    public class AppointmentsController : ApiController
    {
        private ApplicationDbContext _context;

        public AppointmentsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        /// <summary>
        /// GET: /api/appointments/GetAppointments
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAppointments()
        {
            return Ok(_context.Appointments.ToList().Select(Mapper.Map<Appointment, AppointmentDto>));
        }
        
        /// <summary>
        /// GET: /api/appointments/GetAppointment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetAppointment(int id)
        {
            var appointment = _context.Appointments.SingleOrDefault(c => c.Id == id);
            if (appointment == null)
                return NotFound();

            return Ok(Mapper.Map<Appointment, AppointmentDto>(appointment));

        }

        //POST: /api/customer
        /// <summary>
        /// POST: /api/appointments/CreateAppointment
        /// </summary>
        /// <param name="appointmentDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CreateAppointment(AppointmentDto appointmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var appointment = Mapper.Map<AppointmentDto, Appointment>(appointmentDto);
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            appointmentDto.Id = appointment.Id;

            return Created(new Uri(Request.RequestUri + "/" + appointment.Id), appointmentDto);
        }

        /// <summary>
        /// api/appointments/DeleteAppointment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="appointmentDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult UpdateAppointment(int id, AppointmentDto appointmentDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var appointmentInDb = _context.Appointments.SingleOrDefault(a => a.Id == id);
            if (appointmentInDb == null)
                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());

            Mapper.Map(appointmentDto, appointmentInDb);
            _context.SaveChanges();

            return Ok();

        }

        /// <summary>
        /// DELETE: api/appointments/DeleteAppointment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult DeleteAppointment(int id)
        {
            var appointmentInDB = _context.Appointments.SingleOrDefault(p => p.Id == id);

            if (appointmentInDB == null)
                return NotFound();

            _context.Appointments.Remove(appointmentInDB);
            _context.SaveChanges();

            return Ok();
        }
    }
}
