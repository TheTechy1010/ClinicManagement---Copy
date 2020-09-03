using ClinicManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagement.Core.ViewModel
{
    public class CityViewModel
    {
        public int Id { get; set; }
        [ValidateCity]
        public string Name { get; set; }
        public string Header { get { return (Id != 0) ? "Edit the City" : "Add a City"; } set { } }
        public string Action
        {
            get
            {
                return (Id != 0) ? "EditCity" : "AddCity";
            }
            set { }
        }
        public CityViewModel()
        {
           
        }
        public CityViewModel(int cityid)
        {
            this.Id = cityid;
        }
    }
}