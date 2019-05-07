using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;



namespace ForLimestone.Models
{
    public static class SeeData
    {
        public static void EnsurePopulated (IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            if (!context.CompanyUsersIPAddresses.Any())
            {
                context.CompanyUsersIPAddresses.AddRange(
                    new CompanyUsers_IP_address[]
                    {
                        new CompanyUsers_IP_address
                        {
                           Company = "LimeStone",
                           ListUsersIP = new  List <IP_address> { new IP_address { IPaddress = "192.168.88.75" },
                                                                  new IP_address { IPaddress = "192.168.88.76" },
                                                                  new IP_address { IPaddress = "192.168.88.77" },
                                                                  new IP_address { IPaddress = "192.168.0.53" },
                                                                  new IP_address { IPaddress = "0.0.0.1" }}
                        }
                    });

                context.SaveChanges();
            }
        }
    }
}
