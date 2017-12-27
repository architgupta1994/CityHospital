using CityHospital.ViewModels;
using CityHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CityHospital.Controllers
{
    public class AppointmentsController : Controller
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

        public ActionResult Index()
        {
            var appointments = _context
                               .Appointments
                               .Include(a => a.Doctors)
                               .Include(d => d.Doctors.Department)
                               .Include(a => a.Patients)
                               .Include(p => p.Patients.Gender)
                               .Include(p => p.Patients.BloodGroup).ToList();

            return View(appointments);
        }
        

        public ActionResult Book()
        {
            var patients = _context.Patients
                                    .Include(p => p.Gender)
                                    .Include(p => p.BloodGroup).ToList();
            var doctors = _context.Doctors
                                    .Include(d => d.Department);
            var departments = _context.DepartmentTypes.ToList();

            var viewModel = new AppointmentFromViewModel
            {
                Appointment = new Appointment(),
                Patients = patients,
                Doctors = doctors,
                Departments= departments              
            };
            return View("AppointmentForm", viewModel);
        }

        public ActionResult fillDept(int doctorId)
        {
            Doctor doctor = _context.Doctors.SingleOrDefault(c => c.Id == doctorId);

            var department = _context.DepartmentTypes.Where(d => d.Id == doctor.DepartmentId);
            return Json(department, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// POST: 
        /// PUT:
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(AppointmentFromViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModels = new AppointmentFromViewModel()
                {
                    Patients = _context.Patients.ToList(),
                    Doctors = _context.Doctors.ToList(),
                    Appointment = viewModel.Appointment
                };

                return View("AppointmentForm", viewModels);
            }

            if (viewModel.Appointment.Id == 0)
                _context.Appointments.Add(viewModel.Appointment);
            else
            {
                var appointmentInDb = _context.Appointments.Single(a => a.Id == viewModel.Appointment.Id);

                appointmentInDb.AppointmentDate = viewModel.Appointment.AppointmentDate;
                appointmentInDb.PatientId = viewModel.Appointment.PatientId;
                appointmentInDb.DoctorId = viewModel.Appointment.DoctorId;                
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Appointments");
        }

        /// <summary>
        /// Patients/Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var appointment = _context.Appointments.SingleOrDefault(a => a.Id == id);

            if (appointment == null)
                return HttpNotFound();

            var viewModel = new AppointmentFromViewModel()
            {
                Appointment = appointment,
                Doctors = _context.Doctors.ToList(),
                Patients = _context.Patients.ToList()
            };

            return View("AppointmentForm", viewModel);
        }

        /// <summary>
        /// GET: /Patients/Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var appointment = _context
                                .Appointments
                                .Include(a => a.Doctors)
                                .Include(d => d.Doctors.Department)
                                .Include(a => a.Patients)
                                .Include(p => p.Patients.Gender)
                                .Include(p => p.Patients.BloodGroup)
                                .SingleOrDefault(a => a.Id==id);
            if (appointment == null)
                return HttpNotFound();

            var viewModel = new AppointmentFromViewModel
            {
                Appointment = appointment,
                Patients = _context.Patients.ToList(),
                Doctors = _context.Doctors.ToList()
            };

            return View(viewModel);
        }

    }
}