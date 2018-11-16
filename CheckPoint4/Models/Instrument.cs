using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CheckPoint4.Models
{
    [Table("Instrument")]
    public class Instrument
    {
        [Key]
        [Required]
        [DisplayName("Instrument ID")]
        public int InstrumentID { get; set; }
        [Required]
        [DisplayName("Instrument Description")]
        public String InstrumentDesc { get; set; }
        [Required]
        [DisplayName("Instrument Type")]
        public String InstrumentType { get; set; }
        [Required]
        [DisplayName("Instrument Monthly Price")]
        public String InstrumentPrice { get; set; }

        [ForeignKey("Client")]
        public virtual int ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}