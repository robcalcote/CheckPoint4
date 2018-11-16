using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckPoint4.DAL;
using CheckPoint4.Models;

namespace CheckPoint4.Controllers
{
    public class HomeController : Controller
    {
        private BlowoutContext db = new BlowoutContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rentals()
        {
            ViewBag.Rentals = "We offer only the highest quality rentals, both new and used are typically available. Please see look below for a list of the instruments that we rent.";

            return View(db.Instrument.ToList());
        }

        [HttpGet]
        public ActionResult Create(int ID)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ClientID,ClientFirstName,ClientLastName,ClientAddress,ClientCity,ClientState,ClientEmail,ClientPhone")] Client client, int ID)
        {
            if (ModelState.IsValid)
            {
                // If Model is correct, we will Add a new client and save the changes
                db.Client.Add(client);
                db.SaveChanges();

                // Lookups the instrument
                Instrument instrument = db.Instrument.Find(ID);

                // update Instruments
                instrument.ClientID = client.ClientID;

                // Saves changes
                db.SaveChanges();

                return RedirectToAction("Summary", new { ClientID = client.ClientID, InstrumentID = instrument.InstrumentID });
            }
            return View(client);
        }

        public ActionResult Summary(int ClientID, int InstrumentID)
        {
            Client client = db.Client.Find(ClientID);
            Instrument instrument = db.Instrument.Find(InstrumentID);

            ViewBag.Client = client;
            ViewBag.Instrument = instrument;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}