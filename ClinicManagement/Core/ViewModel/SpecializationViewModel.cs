using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicManagement.Core.ViewModel
{
    public class SpecializationViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3),MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public string Header { get { return (Id != 0) ? "Edit the Specialization" : "Add a Specialization"; } set { } }
        public string Action
        {
            get
            {
                return (Id != 0) ? "EditSpecialization" : "AddSpecialization";
            }
            set { }
        }
    }
}