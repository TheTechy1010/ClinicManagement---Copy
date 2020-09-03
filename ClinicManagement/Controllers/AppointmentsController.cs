using ClinicManagement.Core;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Http.Results;
using System.Net;
using Newtonsoft.Json;
using ClinicManagement.Core.Helpers;

namespace ClinicManagement.Controllers
{
    public class AppointmentsController : Controller
    {
        private IUnitofWork _unitofWork;
        public AppointmentsController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        // GET: Appointments
        public ActionResult AllAppointments(string sortOrder, string currentFilter, string searchString,int? page)
        {
            if (!string.IsNullOrWhiteSpace(sortOrder) || !string.IsNullOrWhiteSpace(searchString))
            {
                var searchDocs = _unitofWork.Appointments.GetFilteredAppointents(sortOrder, currentFilter, searchString).ToPagedList(page ?? 1, 10);
                ViewBag.Type = sortOrder.Split('_')[1].ToPascal();
                ViewBag.Search = string.Join(" ", sortOrder, searchString);
                return View(searchDocs);
            }
            var allApps = _unitofWork.Appointments.GetAppointments().ToPagedList(page ?? 1, 10); ;
            return View(allApps);
        }
        public ActionResult Details(int id)
        {
            var viewModel = _unitofWork.Appointments.GetAppointment(id);
            return View(viewModel);
        }
        public ActionResult AllDocAppts()
        {
            var id = User.Identity.GetUserId();
            var doc = _unitofWork.Doctors.GetProfile(id);
            var allAppts = _unitofWork.Appointments.GetAppointmentsByDoctor(doc.Id);
            if (Request.IsAjaxRequest())
            {
                return PartialView(allAppts);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult MakeAppointment(int id)
        {
            var viewModel = new AppointmentFormViewModel
            {
                Patient = id,
                Doctors = _unitofWork.Doctors.GetAvailableDoctors(),

                Heading = "New Appointment"
            };

            viewModel.DoctorsList = _unitofWork.Doctors.DoctorsToSelectList();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeAppointment(AppointmentFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.DoctorsList = _unitofWork.Doctors.DoctorsToSelectList();
                return View("AttendanceForm", viewModel);
            }
            
            var appoint = new Appointment()
            {
                DoctorId=viewModel.Doctor,
                Doctor = _unitofWork.Doctors.GetDoctor(viewModel.Doctor),
                Detail = viewModel.Detail,
                PatientId = viewModel.Patient,
                StartDateTime = viewModel.GetStartDateTime(),
                AppointmentStatus = AppointmentStatus.Pending,
                DStatus = true
            };
            if (_unitofWork.Appointments.ValidateAppointment(viewModel.GetStartDateTime(),viewModel.Doctor))
            {
                viewModel.DoctorsList = _unitofWork.Doctors.DoctorsToSelectList();
                ViewBag.ApptError = "Appointment not available in the choosen Datetime";
                return View( viewModel);
                
            }
            _unitofWork.Appointments.AddAppointment(appoint);
            _unitofWork.Complete();
            return RedirectToActionPermanent("AllAppointments", "Appointments");
        }
        public ActionResult ApproveAppointment(int id)
        {
            var appt = _unitofWork.Appointments.GetAppointment(id);
            if (appt == null) return HttpNotFound();
            appt.AppointmentStatus = AppointmentStatus.Approved;
            _unitofWork.Complete();
            return RedirectToAction("Details", "Appointments", new { Id = id });
        }
        public ActionResult RejectAppointment(int id)
        {
            var appt = _unitofWork.Appointments.GetAppointment(id);
            if (appt == null) return HttpNotFound();
            appt.AppointmentStatus = AppointmentStatus.Rejected;
            _unitofWork.Complete();
            return RedirectToAction("Details", "Appointments", new { Id = id });
        }
        public ActionResult PendingAppointment(int id)
        {
            var appt = _unitofWork.Appointments.GetAppointment(id);
            if (appt == null) return HttpNotFound();
            appt.AppointmentStatus = AppointmentStatus.Pending;
            _unitofWork.Complete();
            return RedirectToAction("Details", "Appointments", new { Id=id});
        }
    }
}