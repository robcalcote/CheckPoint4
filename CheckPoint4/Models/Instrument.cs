using System;
using System.Collections.Generic;
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
        public int InstrumentID { get; set; }
        public String InstrumentDesc { get; set; }
        public String InstrumentType { get; set; }
        public String InstrumentPrice { get; set; }

        [ForeignKey("Client")]
        public virtual int ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}