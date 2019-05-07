using System.Collections.Generic;
using ForLimestone.Models;

namespace ForLimestone.Models.ViewModels
{
    public class CompaniesIPListModel
    {
        public IEnumerable<CompanyUsers_IP_address> CompanyUsersIP { get; set; }
        public IEnumerable<IP_address> IPAddress { get; set; }
    }
}
