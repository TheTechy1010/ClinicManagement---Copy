using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Repositories
{
    public interface ICommon
    {
        void Complete();
        void Delete(int id);
    }
}
