using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ClinicManagement.Core.Models
{
    public enum AppointmentStatus
    {
        [Description("Pending")]
        Pending=0,
        [Description("Approved")]
        Approved,
        [Description("Rejected")]
        Rejected
    }
}