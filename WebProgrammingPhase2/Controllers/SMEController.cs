using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebProgrammingPhase2.Models;

namespace WebProgrammingPhase2.Controllers
{
    public class SMEController : Controller
    {
        private DataBaseConnetion db = new DataBaseConnetion();

        // GET: SME
        public async Task<ActionResult> Index()
        {
            return View(await db.ApplicantDb.ToListAsync());
        }

        // GET: SME/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = await db.ApplicantDb.FindAsync(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // GET: SME/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SME/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Education,Department,jobTiltile,Skills,Rating,isTop5,isHired")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.ApplicantDb.Add(applicant);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(applicant);
        }

        // GET: SME/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = await db.ApplicantDb.FindAsync(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: SME/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Rating,isTop5")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Edit");
            }
            return View(applicant);
        }

        // GET: SME/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = await db.ApplicantDb.FindAsync(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: SME/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Applicant applicant = await db.ApplicantDb.FindAsync(id);
            db.ApplicantDb.Remove(applicant);
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
