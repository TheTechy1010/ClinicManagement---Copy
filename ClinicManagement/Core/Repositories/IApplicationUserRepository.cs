using ClinicManagement.Core.Models;
using ClinicManagement.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagement.Core.Repositories
{
    public interface IApplicationUserRepository:ICommon
    {
        List<UserViewModel> GetUsers();
        ApplicationUser GetUser(string id);
    }
}