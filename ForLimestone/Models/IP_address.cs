using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForLimestone.Models
{
    public class IP_address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public Guid CompanyUsers_IP_addressID { get; set; }

        public string IPaddress { get; set; }
    }
}
