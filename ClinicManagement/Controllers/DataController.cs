using ClinicManagement.Core;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.Repositories;
using ClinicManagement.Core.ViewModel;
using ClinicManagement.Persistence;
using ClinicManagement.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace ClinicManagement.Controllers
{
    public class DataController : Controller
    {
        private IUnitofWork _unitofWork;

        public DataController(UnitOfWork _repo)
        {
            _unitofWork = _repo;
        }

        //GET: City CRUD Operation
        public ActionResult Cities()
        {
            var allCities = _unitofWork.Cities.GetCities();
            return View(allCities);
        }

        public ActionResult AddCity()
        {
            return View("CityForm", new CityViewModel());
        }

        [HttpPost]

        public ActionResult AddCity(CityViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.Cities.AddCity(new City { Name = viewModel.Name });
                return RedirectToActionPermanent("Cities");
            }
            return View("CityForm", viewModel);
        }

        public ActionResult EditCity(int id)
        {
            var cityToEdit = _unitofWork.Cities.GetCity(id);
            var viewModel = new CityViewModel { Name = cityToEdit.Name, Id = cityToEdit.Id };
            return View("CityForm", viewModel);
        }

        [HttpPost]

        public ActionResult EditCity(CityViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var city = _unitofWork.Cities.GetCity(viewModel.Id);
                city.Name = viewModel.Name;
                _unitofWork.Cities.Complete();
                return RedirectToActionPermanent("Cities");
            }
            return View("CityForm", viewModel);
        }

        [HttpGet]

        public ActionResult DeleteCity(int id)
        {
            _unitofWork.Cities.Delete(id);
            return Json("Deleted", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Specializations(int? page)
        {
            var allSpecs = _unitofWork.Specializations.GetSpecializations().ToPagedList(page ?? 1, 5);
            return View(allSpecs);
        }

        public ActionResult AddSpecialization()
        {
            return View("SpecForm", new SpecializationViewModel());
        }

        [HttpPost]

        public ActionResult AddSpecialization(SpecializationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.Specializations.AddSpecialization(new Specialization { Name = viewModel.Name,Description = viewModel.Description });
                return RedirectToActionPermanent("Specializations");
            }
            return View("SpecForm", viewModel);
        }

        public ActionResult EditSpecialization(int id)
        {
            var specToEdit = _unitofWork.Specializations.GetSpecialization(id);
            var viewModel = new SpecializationViewModel { Name = specToEdit.Name, Id = specToEdit.Id,Description=specToEdit.Description = specToEdit.Description };
            return View("SpecForm", viewModel);
        }

        [HttpPost]

        public ActionResult EditSpecialization(SpecializationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var spec = _unitofWork.Specializations.GetSpecialization(viewModel.Id);
                spec.Name = viewModel.Name;
                spec.Description = viewModel.Description;
                _unitofWork.Complete();
                return RedirectToActionPermanent("Specializations");
            }
            return View("SpecForm", viewModel);
        }

        [HttpGet]
        public ActionResult DeleteSpec(int id)
        {
            _unitofWork.Specializations.Delete(id);
            _unitofWork.Complete();
            return Json("Deleted", JsonRequestBehavior.AllowGet);
        }
    }
}