using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Required]
        [DisplayName("Client ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientID { get; set; }
        [Required]
        [DisplayName("Client First Name")]
        public String ClientFirstName { get; set; }
        [Required]
        [DisplayName("Client Last Name")]
        public String ClientLastName { get; set; }
        [Required]
        [DisplayName("Client Address")]
        public String ClientAddress { get; set; }
        [Required]
        [DisplayName("Client City")]
        public String ClientCity { get; set; }
        [Required]
        [DisplayName("Client State")]
        public String ClientState { get; set; }
        [Required]
        [DisplayName("Client Zip")]
        public String ClientZip { get; set; }
        [Required]
        [DisplayName("Client Email")]
        public String ClientEmail { get; set; }
        [Required]
        [DisplayName("Client Phone")]
        public String ClientPhone { get; set; }
    }
}