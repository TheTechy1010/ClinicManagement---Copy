using ClinicManagement.Core;
using ClinicManagement.Core.Repositories;
using ClinicManagement.Models;
using ClinicManagement.Persistence;
using ClinicManagement.Persistence.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Unity.Injection;
using Microsoft.AspNet.Identity;
using ClinicManagement.Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using ClinicManagement.Controllers;
using System.Data.Entity;

namespace ClinicManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICityRepository, CityRepository>();

            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<UserManager<ApplicationUser>>();
            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<IUnitofWork, UnitOfWork>(new InjectionConstructor());
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            //container.RegisterInstance(typeof(ApplicationDbContext), new ApplicationDbContext());

            //container.RegisterType<IUnitofWork, UnitOfWork>(new InjectionConstructor(new ApplicationDbContext()));
            //container.Resolve<UnitOfWork>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}