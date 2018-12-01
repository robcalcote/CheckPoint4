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
        [DisplayName("Instrument ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstrumentID { get; set; }

        [DisplayName("Instrument Description")]
        public String InstrumentDesc { get; set; }

        [DisplayName("Instrument Type")]
        public String InstrumentType { get; set; }

        [DisplayName("Instrument Monthly Price")]
        public String InstrumentPrice { get; set; }


        public int? ClientID { get; set; }
        public virtual Client client { get; set; }
    }
}