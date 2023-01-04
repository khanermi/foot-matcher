using FootMatcher.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.BusinessServices.Interfaces.Interfaces
{
    public interface ISessionBusinessService : IBusinessService
    {
        Session GenerateDefaultSession();
    }
}
