using System.Linq;
using System.Net;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ForLimestone.Models;

using Microsoft.Extensions.DependencyInjection;


namespace ForLimestone.Filters
{
    public class ClientIPCheckFilter : ActionFilterAttribute
    {
                
        public ClientIPCheckFilter()
        {
                   
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ArrayList whiteIP = new ArrayList();

            IP_address companyIP;

            ApplicationDbContext db = filterContext.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
                        
            foreach (IP_address argument in db.IP_Addresses)
            {
                companyIP = argument as IP_address;
              
                whiteIP.Add(companyIP.IPaddress);
            }
                        
            var remoteIp = filterContext.HttpContext.Connection.RemoteIpAddress.MapToIPv4();
                       
            var bytes = remoteIp.GetAddressBytes();

            var badIp = true;

            foreach (var address in whiteIP)
            {
                var testIp = IPAddress.Parse(address.ToString());

                var myTestIp = testIp.GetAddressBytes();

                if (testIp.GetAddressBytes().SequenceEqual(bytes))
                {
                    badIp = false;
                    break;
                }
            }

            if (badIp)
            {
                filterContext.Result = new StatusCodeResult(401);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}