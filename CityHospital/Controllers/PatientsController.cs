using CityHospital.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using CityHospital.ViewModels;

namespace CityHospital.Controllers
{
    public class PatientsController : Controller
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

        /// <summary>
        /// GET: Patients
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var patients = _context
                            .Patients
                            .Include(p => p.Gender)
                            .Include(p => p.BloodGroup).ToList();

            return View(patients);
        }

        /// <summary>
        /// GET: /Patients/Register
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            var bloodGroups = _context.BloodGroups.ToList();
            var genders = _context.Genders.ToList();
            var viewModel = new PatientFormViewModel()
            {
                Patients = new Patient(),
                Genders = genders,
                BloodGroups= bloodGroups
            };            

            return View("PatientForm", viewModel);
                        
        }

        /// <summary>
        /// POST: 
        /// PUT:
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PatientFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModels = new PatientFormViewModel()
                {
                    Patients = viewModel.Patients,
                    Genders = _context.Genders.ToList(),
                    BloodGroups = _context.BloodGroups.ToList()
                };

                return View("patientForm", viewModels);
            }

            if (viewModel.Patients.Id == 0)
                _context.Patients.Add(viewModel.Patients);
            else
            {
                var patientInDb = _context.Patients.Single(c => c.Id == viewModel.Patients.Id);

                patientInDb.FirstName = viewModel.Patients.FirstName;
                patientInDb.LastName = viewModel.Patients.LastName;
                patientInDb.DateOfJoin = viewModel.Patients.DateOfJoin;
                patientInDb.Age = viewModel.Patients.Age;
                patientInDb.CellPhone = viewModel.Patients.CellPhone;
                patientInDb.Address = viewModel.Patients.Address;
                patientInDb.Disease = viewModel.Patients.Disease;
                patientInDb.Gender = viewModel.Patients.Gender;
                patientInDb.BloodGroup = viewModel.Patients.BloodGroup;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Patients");
        }

        /// <summary>
        /// Patients/Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.Id == id);

            if (patient == null)
                return HttpNotFound();
            var viewModel = new PatientFormViewModel()
            {
                Patients = patient,
                Genders = _context.Genders.ToList(),
                BloodGroups = _context.BloodGroups.ToList()
            };           

            return View("PatientForm", viewModel);
        }

        /// <summary>
        /// GET: /Patients/Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var patient = _context.Patients
                                    .Include(p => p.Gender)
                                    .Include(p => p.BloodGroup)
                                    .SingleOrDefault(p => p.Id == id);

            if (patient == null)
                return HttpNotFound();
            var viewModel = new PatientFormViewModel
            {
                Patients = patient,
                Genders = _context.Genders.ToList(),
                BloodGroups = _context.BloodGroups.ToList()
            };

            return View(viewModel);
        }

        /// <summary>
        /// DELETE: //Patients/Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.Id == id);

            if (patient == null)
                return HttpNotFound();

            _context.Patients.Remove(patient);
            _context.SaveChanges();

            return RedirectToAction("Index", "Patients");
        }

    }
}