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
    [Authorize]
    public class AdminContactsController : Controller
    {
        private DataBaseConnetion db = new DataBaseConnetion();

        // GET: AdminContacts
        public async Task<ActionResult> Index()
        {
            return View(await db.AdminContacts.ToListAsync());
        }

        // GET: AdminContacts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminContact adminContact = await db.AdminContacts.FindAsync(id);
            if (adminContact == null)
            {
                return HttpNotFound();
            }
            return View(adminContact);
        }

        // GET: AdminContacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Email,Title,Message")] AdminContact adminContact)
        {
            if (ModelState.IsValid)
            {
                db.AdminContacts.Add(adminContact);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(adminContact);
        }

        // GET: AdminContacts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminContact adminContact = await db.AdminContacts.FindAsync(id);
            if (adminContact == null)
            {
                return HttpNotFound();
            }
            return View(adminContact);
        }

        // POST: AdminContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Email,Title,Message")] AdminContact adminContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminContact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(adminContact);
        }

        // GET: AdminContacts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminContact adminContact = await db.AdminContacts.FindAsync(id);
            if (adminContact == null)
            {
                return HttpNotFound();
            }
            return View(adminContact);
        }

        // POST: AdminContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AdminContact adminContact = await db.AdminContacts.FindAsync(id);
            db.AdminContacts.Remove(adminContact);
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
