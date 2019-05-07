using Microsoft.AspNetCore.Mvc;
using ForLimestone.Models;
using ForLimestone.Filters;
using ForLimestone.Models.ViewModels;

namespace ForLimestone.Controllers
{
    public class ListIPController : Controller
    {
        public ICompanyUsersIPRepository repository;

        public ListIPController (ICompanyUsersIPRepository repo)
        {
            repository = repo;
        }

        [ServiceFilter(typeof(ClientIPCheckFilter))]
        public ViewResult List() => View(new CompaniesIPListModel
                                                                  {CompanyUsersIP=repository.CompanyUsersIP,
                                                                   IPAddress=repository.IPAddress});
    }
}