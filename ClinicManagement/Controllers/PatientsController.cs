using ClinicManagement.Core;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagement.Controllers
{
    public class PatientsController : Controller
    {
        private IUnitofWork _unitofWork;
        public PatientsController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (!string.IsNullOrWhiteSpace(sortOrder) || !string.IsNullOrWhiteSpace(searchString))
            {
                var searchPatients = _unitofWork.Patients.GetPatients(sortOrder, currentFilter, searchString).ToPagedList(page ?? 1, 10);
                ViewBag.Search = string.Join(" ", sortOrder, searchString);
                return View(searchPatients);
            }
            var allPatients = _unitofWork.Patients.GetPatients().ToPagedList(page ?? 1, 10);
            return View(allPatients);
        }
        public ActionResult AddPatient()
        {
            var viewModel = new PatientFormViewModel()
            {
                Cities = _unitofWork.Cities.GetCities(),
                Heading = "New Patient"
            };
            return View("PatientForm", viewModel);
        }
        [HttpPost]
        public ActionResult AddPatient(PatientFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {

                viewModel.Cities = _unitofWork.Cities.GetCities();
                viewModel.Heading = "New Patient";

                return View(viewModel);
            }
            var patient = new Patient()
            {
                Name = viewModel.Name,
                Address = viewModel.Address,
                BirthDate = viewModel.GetBirthDate(),
                CityId = viewModel.City,
                DateTime = DateTime.Now,
                Sex = viewModel.Sex,
                DStatus = true,
                Phone = viewModel.Phone,
                Height = viewModel.Height,
                Weight = viewModel.Weight,
                Token = DateTime.Now.ToString("ddMMyyyy") + new Random(1000).Next(1000).ToString()
            };
            _unitofWork.Patients.Add(patient);
            _unitofWork.Complete();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdatePatient(PatientFormViewModel viewModel)
        {


            if (!ModelState.IsValid)
            {
                viewModel.Cities = _unitofWork.Cities.GetCities();
                return View("PatientForm", viewModel);
            }
            var patientInDb = _unitofWork.Patients.GetPatient(viewModel.Id);
            if (patientInDb == null)
            {
                return HttpNotFound();
            }
            patientInDb.Id = viewModel.Id;
            patientInDb.Name = viewModel.Name;
            patientInDb.Phone = viewModel.Phone;
            patientInDb.BirthDate = viewModel.GetBirthDate();
            patientInDb.Address = viewModel.Address;
            patientInDb.Height = viewModel.Height;
            patientInDb.Weight = viewModel.Weight;
            patientInDb.Sex = viewModel.Sex;
            patientInDb.CityId = viewModel.City;

            _unitofWork.Complete();
            return RedirectToAction("Index", "Patients");


        }
        // GET: Patients
        public ActionResult UpdatePatient(int id)
        {
            var patient = _unitofWork.Patients.GetPatient(id);

            var viewModel = new PatientFormViewModel
            {
                Heading = "Edit Patient",
                Id = patient.Id,
                Name = patient.Name,
                Phone = patient.Phone,
                Date = patient.DateTime,
                //Date = patient.DateTime.ToString("d MMM yyyy"),
                BirthDate = patient.BirthDate.ToString("dd/MM/yyyy"),
                Address = patient.Address,
                Height = patient.Height,
                Weight = patient.Weight,
                Sex = patient.Sex,
                City = (byte)patient.CityId,
                Cities = _unitofWork.Cities.GetCities()
            };
            return View("PatientForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var viewModel = new PatientDetailViewModel();
            viewModel.Patient = _unitofWork.Patients.GetPatient(id);
            //viewModel.CountAttendance = _unitofWork.Attendances.CountAttendances(id);
            viewModel.CountAttendance = 0;
            viewModel.CountAppointments = _unitofWork.Appointments.CountAppointments(id);
            return View(viewModel);

        }
        public ActionResult Delete(int id)
        {
            _unitofWork.Patients.Delete(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}