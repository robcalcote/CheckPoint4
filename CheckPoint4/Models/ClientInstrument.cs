using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CheckPoint4.Models
{
    public class ClientInstrument
    {
        public Client client { get; set; }
        public Instrument instrument { get; set; }
    }
}