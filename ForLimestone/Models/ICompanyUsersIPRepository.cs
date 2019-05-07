using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForLimestone.Models
{
    public interface ICompanyUsersIPRepository
    {
        IEnumerable<CompanyUsers_IP_address> CompanyUsersIP { get; }
        IEnumerable<IP_address> IPAddress { get; }
    }
}
