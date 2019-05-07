using System.Collections.Generic;


namespace ForLimestone.Models
{
    public class EFCompanyIPRepository : ICompanyUsersIPRepository
    {
        private ApplicationDbContext context;

        public EFCompanyIPRepository(ApplicationDbContext ctxt)
        {
            context = ctxt;
        }

        public IEnumerable<CompanyUsers_IP_address> CompanyUsersIP => context.CompanyUsersIPAddresses;
        public IEnumerable<IP_address> IPAddress => context.IP_Addresses;

    }
}
