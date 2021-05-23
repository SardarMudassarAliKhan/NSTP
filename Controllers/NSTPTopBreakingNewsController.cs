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
    public class NSTPTopBreakingNewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NSTPTopBreakingNews
        public async Task<ActionResult> Index()
        {
            return View(await db.NSTPTopBreakingNews.ToListAsync());
        }

        // GET: NSTPTopBreakingNews/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NSTPTopBreakingNews nSTPTopBreakingNews = await db.NSTPTopBreakingNews.FindAsync(id);
            if (nSTPTopBreakingNews == null)
            {
                return HttpNotFound();
            }
            return View(nSTPTopBreakingNews);
        }

        // GET: NSTPTopBreakingNews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NSTPTopBreakingNews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Description,Date,CreatedOn,IsDeleted")] NSTPTopBreakingNews nSTPTopBreakingNews)
        {
            if (ModelState.IsValid)
            {
                db.NSTPTopBreakingNews.Add(nSTPTopBreakingNews);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(nSTPTopBreakingNews);
        }

        // GET: NSTPTopBreakingNews/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NSTPTopBreakingNews nSTPTopBreakingNews = await db.NSTPTopBreakingNews.FindAsync(id);
            if (nSTPTopBreakingNews == null)
            {
                return HttpNotFound();
            }
            return View(nSTPTopBreakingNews);
        }

        // POST: NSTPTopBreakingNews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Description,Date,CreatedOn,IsDeleted")] NSTPTopBreakingNews nSTPTopBreakingNews)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nSTPTopBreakingNews).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nSTPTopBreakingNews);
        }

        // GET: NSTPTopBreakingNews/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NSTPTopBreakingNews nSTPTopBreakingNews = await db.NSTPTopBreakingNews.FindAsync(id);
            if (nSTPTopBreakingNews == null)
            {
                return HttpNotFound();
            }
            return View(nSTPTopBreakingNews);
        }

        // POST: NSTPTopBreakingNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NSTPTopBreakingNews nSTPTopBreakingNews = await db.NSTPTopBreakingNews.FindAsync(id);
            db.NSTPTopBreakingNews.Remove(nSTPTopBreakingNews);
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
