using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NSTP.Models;
using NSTP_DAL.Models;

namespace NSTP.Controllers
{
    public class NSTPSlidersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NSTPSliders
        public async Task<ActionResult> Index()
        {
            return View(await db.NSTPSliders.ToListAsync());
        }

        // GET: NSTPSliders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NSTPSlider nSTPSlider = await db.NSTPSliders.FindAsync(id);
            if (nSTPSlider == null)
            {
                return HttpNotFound();
            }
            return View(nSTPSlider);
        }

        // GET: NSTPSliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NSTPSliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Description,SliderImage,CreatedOn,IsDeleted")] NSTPSlider nSTPSlider)
        {
            if (ModelState.IsValid)
            {
                db.NSTPSliders.Add(nSTPSlider);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(nSTPSlider);
        }

        // GET: NSTPSliders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NSTPSlider nSTPSlider = await db.NSTPSliders.FindAsync(id);
            if (nSTPSlider == null)
            {
                return HttpNotFound();
            }
            return View(nSTPSlider);
        }

        // POST: NSTPSliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Description,SliderImage,CreatedOn,IsDeleted")] NSTPSlider nSTPSlider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nSTPSlider).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nSTPSlider);
        }

        // GET: NSTPSliders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NSTPSlider nSTPSlider = await db.NSTPSliders.FindAsync(id);
            if (nSTPSlider == null)
            {
                return HttpNotFound();
            }
            return View(nSTPSlider);
        }

        // POST: NSTPSliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NSTPSlider nSTPSlider = await db.NSTPSliders.FindAsync(id);
            db.NSTPSliders.Remove(nSTPSlider);
            await db.SaveChangesAsync();
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
