using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CheckPoint4.DAL;
using CheckPoint4.Models;

namespace CheckPoint4.Controllers
{
    public class NewClientsController : Controller
    {
        private BlowoutContext db = new BlowoutContext();

        // GET: NewClients
        public ActionResult Index()
        {
            return View(db.NewClient.ToList());
        }

        // GET: NewClients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewClient newClient = db.NewClient.Find(id);
            if (newClient == null)
            {
                return HttpNotFound();
            }
            return View(newClient);
        }

        // GET: NewClients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientID,ClientFirstName,ClientLastName,ClientAddress,ClientCity,ClientState,ClientZip,ClientEmail,ClientPhone")] NewClient newClient)
        {
            if (ModelState.IsValid)
            {
                db.NewClient.Add(newClient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newClient);
        }

        // GET: NewClients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewClient newClient = db.NewClient.Find(id);
            if (newClient == null)
            {
                return HttpNotFound();
            }
            return View(newClient);
        }

        // POST: NewClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientID,ClientFirstName,ClientLastName,ClientAddress,ClientCity,ClientState,ClientZip,ClientEmail,ClientPhone")] NewClient newClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newClient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newClient);
        }

        // GET: NewClients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewClient newClient = db.NewClient.Find(id);
            if (newClient == null)
            {
                return HttpNotFound();
            }
            return View(newClient);
        }

        // POST: NewClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewClient newClient = db.NewClient.Find(id);
            db.NewClient.Remove(newClient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
