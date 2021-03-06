﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CheckPoint4.DAL;
using CheckPoint4.Models;
using System.Data.Entity;

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
        public ActionResult Create([Bind(Include = "ClientID,ClientFirstName,ClientLastName,ClientAddress,ClientCity,ClientState,ClientZip,ClientEmail,ClientPhone")] Client client, int ID)
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

            // These viewbags store a summary of what the customer checked out with
            ViewBag.InstrumentDesc = instrument.InstrumentDesc;
            ViewBag.InstrumentType = instrument.InstrumentType;
            ViewBag.InstrumentPrice = instrument.InstrumentPrice;
            ViewBag.ClientFirstName = client.ClientFirstName;
            ViewBag.ClientLastName = client.ClientLastName;
            ViewBag.ClientAddress = client.ClientAddress;
            ViewBag.ClientCity = client.ClientCity;
            ViewBag.ClientState = client.ClientState;
            ViewBag.ClientZip = client.ClientZip;
            ViewBag.ClientEmail = client.ClientEmail;
            ViewBag.ClientPhone = client.ClientPhone;
            ViewBag.Instrument = instrument;
            ViewBag.ClientID = client.ClientID;

            // This stores images for the Viewbag depending on what image the customer selected

            if (ViewBag.InstrumentDesc == "Trumpet")
            {
                    ViewBag.InstrumentPic = "~/Graphics/Trumpet.jpg";
            }
            else if (ViewBag.InstrumentDesc == "Trombone")
            {
                ViewBag.InstrumentPic = "~/Graphics/Trombone.jpg";
            }
            else if (ViewBag.InstrumentDesc == "Flute")
            {
                ViewBag.InstrumentPic = "~/Graphics/Flute.jpg";
            }
            else if (ViewBag.InstrumentDesc == "Clarinet")
            {
                ViewBag.InstrumentPic = "~/Graphics/Clarinet.jpg";
            }
            else if (ViewBag.InstrumentDesc == "Tuba")
            {
                ViewBag.InstrumentPic = "~/Graphics/Tuba.jpg";
            }
            else if (ViewBag.InstrumentDesc == "Saxophone")
            {
                ViewBag.InstrumentPic = "~/Graphics/Saxophone.jpg";
            };

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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginSuccess(FormCollection form)
        {
            string sUsername = form["Username"].ToString();
            string sPassword = form["Password"].ToString();
            ViewBag.UnsuccessfulLogin = "Your Username and/or password did not match our records. Please try again";

            if ((sUsername == "Missouri") && (sPassword == "ShowMe"))
            {
                // This will navigate you to the ActionResult listed below - a new list which shows clients and the instruments they rent
                return View(db.Instrument.ToList());
            }
            else
            {
                // This will navigate you back to the login page if authentication is unsuccessful
                return View("Login");
            }
        }

        // Delete method
        public ActionResult Delete(int id)
        {
            Client newclient = db.Client.Find(id);
            db.Client.Remove(newclient);
            db.SaveChanges();
            List<Instrument> newinstrument = db.Instrument.Where(i => i.ClientID == id).ToList();
            Instrument lastinstrument = newinstrument.Find(i => i.ClientID == id);
            lastinstrument.ClientID = null;
            db.Entry(lastinstrument).State = EntityState.Modified;
            db.SaveChanges();
            return View("LoginSuccess", db.Instrument.ToList());
        }
    }
}