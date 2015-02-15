using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DogOnline.Models;
using System.IO;

namespace DogOnline.Controllers
{
    public class DetailsController : Controller
    {
        private DogOnlineDbContext db = new DogOnlineDbContext();

        // GET: Details
        public ActionResult Index()
        {
            return View(db.Details.ToList());
        }

        // GET: Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Details details = db.Details.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }

        // GET: Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "DetailsId,Name,Breed,Gender,Age,Location,Contact,Image,ImageFileName")] Details details)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Details.Add(details);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(details);
        //}

        // GET: Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Details details = db.Details.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }

        // POST: Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DetailsId,Name,Breed,Gender,Age,Location,Contact,Image,ImageFileName")] Details details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(details);
        }

        // GET: Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Details details = db.Details.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Details details = db.Details.Find(id);
            db.Details.Remove(details);
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

        [HttpPost]
        public ActionResult Create(Details details, HttpPostedFileBase file)
        {
            string fileName = "";
            byte[] bytes;
            int BytesToRead=0;
            int NumberOfBytesRead=0;

            fileName = Path.GetFileName(file.FileName);
            bytes = new byte[file.ContentLength];
            BytesToRead = (int)file.ContentLength;

            while (BytesToRead > 0)
            {
                int n = file.InputStream.Read(bytes, NumberOfBytesRead, BytesToRead);
                
                if (n == 0)
                    break;

                NumberOfBytesRead = NumberOfBytesRead + n;
                BytesToRead = BytesToRead - n;
            }

            details.Image = bytes;

            //DogOnlineDbContext dogOnlineDbContext = new DogOnlineDbContext();

            db.Details.Add(details);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
