using CheckPoint4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CheckPoint4.DAL
{
    public class BlowoutContext : DbContext
    {
        public BlowoutContext() : base("BlowoutContext")
        {

        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Instrument> Instrument { get; set; }
        public DbSet<NewClient> NewClient { get; set; }
    }
}