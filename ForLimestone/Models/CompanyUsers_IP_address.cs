using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ForLimestone.Models;

namespace ForLimestone.Models
{
    public class CompanyUsers_IP_address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Please enter a company name")]
        public string Company { get; set; }

        public ICollection <IP_address> ListUsersIP { get; set; }
    }
}
