using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CheckPoint4.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        public String ClientFirstName { get; set; }
        public String ClientLastName { get; set; }
        public String ClientAddress { get; set; }
        public String ClientCity { get; set; }
        public String ClientState { get; set; }
        public String ClientZip { get; set; }
        public String ClientEmail { get; set; }
        public String ClientPhone { get; set; }
    }
}