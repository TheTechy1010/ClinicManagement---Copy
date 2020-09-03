using ClinicManagement.Core;
using ClinicManagement.Core.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace ClinicManagement.Controllers
{
    [Authorize]
    public class DoctorsController : Controller
    {
        private readonly IUnitofWork _unitOfWork;

        public DoctorsController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (!string.IsNullOrWhiteSpace(sortOrder) || !string.IsNullOrWhiteSpace(searchString))
            {
                var searchDocs = _unitOfWork.Doctors.GetDoctors(sortOrder, currentFilter, searchString).ToPagedList(page ?? 1, 10);
                ViewBag.Search = string.Join(" ", sortOrder, searchString);
                return View(searchDocs);
            }
            var doctors = _unitOfWork.Doctors.GetDoctors().ToPagedList(page ?? 1, 10);
            return View(doctors);
        }
        // GET: Doctors
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var viewModel = new DoctorDetailViewModel
            {
                Doctor = _unitOfWork.Doctors.GetDoctor(id),
                UpcomingAppointments = _unitOfWork.Appointments.GetTodaysAppointments(id),
                Appointments = _unitOfWork.Appointments.GetAppointmentsByDoctor(id)
            };

            return View(viewModel);
        }
        public ActionResult DoctorProfile()
        {
            if (!Request.IsAuthenticated)
            {
                return View("_NotFound");
            }
            var id = User.Identity.GetUserId();
            var doctor = _unitOfWork.Doctors.GetProfile(id);
            var viewModel = new DoctorDetailViewModel()
            {
                Doctor = doctor
                
                
            };
            viewModel.UpcomingAppointments = _unitOfWork.Appointments.GetTodaysAppointments(doctor.Id);
            viewModel.Appointments = _unitOfWork.Appointments.GetAppointmentsByDoctor(doctor.Id);
            return View(viewModel);
        }
        public ActionResult Edit(int id)
        {
            var doctor = _unitOfWork.Doctors.GetDoctor(id);
            if (doctor == null) return HttpNotFound();
            var viewModel = new DoctorFormViewModel()
            {
                Address = doctor.Address,
                IsAvailable = doctor.IsAvailable,
                Name = doctor.Name,
                Phone = doctor.Phone,
                Specialization = doctor.SpecializationId,
                Id = doctor.Id,
                Specializations = _unitOfWork.Specializations.GetSpecializations()
                
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DoctorFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Specializations = _unitOfWork.Specializations.GetSpecializations();
                return View(model);
            }
            var docInDb = _unitOfWork.Doctors.GetDoctor(model.Id);
            docInDb.Id = model.Id;
            docInDb.IsAvailable = model.IsAvailable;
            docInDb.Name = model.Name;
            docInDb.Phone = model.Phone;
            docInDb.Address = model.Address;
            docInDb.SpecializationId = model.Specialization;
            _unitOfWork.Complete();
            return RedirectToAction("DoctorProfile");
        }
        public ActionResult GetUpcomingAppointments(int id)
        {
            var appts = _unitOfWork.Appointments.GetAppointmentsByDoctor(id);

            return PartialView(appts);
        }
        [HttpPost]
        public ActionResult ToggleAvail(int id)
        {
            var doctor = _unitOfWork.Doctors.GetDoctor(id);
            if (doctor == null) return HttpNotFound();
            doctor.IsAvailable = !doctor.IsAvailable;
            _unitOfWork.Complete();
            return Json(true,JsonRequestBehavior.AllowGet);
        }
    }
}