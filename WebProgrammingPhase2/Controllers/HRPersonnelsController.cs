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
    public class HRPersonnelsController : Controller
    {
        private DataBaseConnetion db = new DataBaseConnetion();

        // GET: HRPersonnels
        public async Task<ActionResult> Index()
        {
            return View(await db.HRPersonnel.ToListAsync());
        }

        // GET: HRPersonnels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HRPersonnel hRPersonnel = await db.HRPersonnel.FindAsync(id);
            if (hRPersonnel == null)
            {
                return HttpNotFound();
            }
            return View(hRPersonnel);
        }

        // GET: HRPersonnels/Create
        public ActionResult Create()
        {
            return View();
        }
       

        // POST: HRPersonnels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,JobTitle,shortDes,Department,Position,RequiredSkills,ApplyTill,LongDes")] HRPersonnel hRPersonnel)
        {
            if (ModelState.IsValid)
            {
                db.HRPersonnel.Add(hRPersonnel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(hRPersonnel);
        }

        // GET: HRPersonnels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HRPersonnel hRPersonnel = await db.HRPersonnel.FindAsync(id);
            if (hRPersonnel == null)
            {
                return HttpNotFound();
            }
            return View(hRPersonnel);
        }

        // POST: HRPersonnels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,JobTitle,shortDes,Department,Position,RequiredSkills,ApplyTill,LongDes")] HRPersonnel hRPersonnel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hRPersonnel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hRPersonnel);
        }

        // GET: HRPersonnels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HRPersonnel hRPersonnel = await db.HRPersonnel.FindAsync(id);
            if (hRPersonnel == null)
            {
                return HttpNotFound();
            }
            return View(hRPersonnel);
        }

        // POST: HRPersonnels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HRPersonnel hRPersonnel = await db.HRPersonnel.FindAsync(id);
            db.HRPersonnel.Remove(hRPersonnel);
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
