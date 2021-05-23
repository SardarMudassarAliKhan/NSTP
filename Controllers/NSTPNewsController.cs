using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NSTP_DAL.Data;
using NSTP_DAL.Models;

namespace NSTP.Controllers
{
    public class NSTPNewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NSTPNews
        public async Task<ActionResult> Index()
        {
            return View(await db.NSTPNews.ToListAsync());
        }

        // GET: NSTPNews/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NSTPNews nSTPNews = await db.NSTPNews.FindAsync(id);
            if (nSTPNews == null)
            {
                return HttpNotFound();
            }
            return View(nSTPNews);
        }

        // GET: NSTPNews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NSTPNews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Description,Date,CreatedOn,IsDeleted")] NSTPNews nSTPNews)
        {
            if (ModelState.IsValid)
            {
                db.NSTPNews.Add(nSTPNews);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(nSTPNews);
        }

        // GET: NSTPNews/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NSTPNews nSTPNews = await db.NSTPNews.FindAsync(id);
            if (nSTPNews == null)
            {
                return HttpNotFound();
            }
            return View(nSTPNews);
        }

        // POST: NSTPNews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Description,Date,CreatedOn,IsDeleted")] NSTPNews nSTPNews)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nSTPNews).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nSTPNews);
        }

        // GET: NSTPNews/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NSTPNews nSTPNews = await db.NSTPNews.FindAsync(id);
            if (nSTPNews == null)
            {
                return HttpNotFound();
            }
            return View(nSTPNews);
        }

        // POST: NSTPNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NSTPNews nSTPNews = await db.NSTPNews.FindAsync(id);
            db.NSTPNews.Remove(nSTPNews);
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
