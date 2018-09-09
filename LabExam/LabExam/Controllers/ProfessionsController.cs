using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabExam.Map;
using LabExam.Models;

namespace LabExam.Controllers
{
    public class ProfessionsController : Controller
    {
        private LabContext db = new LabContext();

        // GET: Professions
        public async Task<ActionResult> Index()
        {
            var professions = db.Professions.Include(p => p.Institute);
            return View(await professions.ToListAsync());
        }

        // GET: Professions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession profession = await db.Professions.FindAsync(id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            return View(profession);
        }

        // GET: Professions/Create
        public ActionResult Create()
        {
            ViewBag.InstituteID = new SelectList(db.Institutes, "InstituteID", "Name");
            return View();
        }

        // POST: Professions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProfessionID,Name,AddTime,InstituteID")] Profession profession)
        {
            if (ModelState.IsValid)
            {
                db.Professions.Add(profession);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.InstituteID = new SelectList(db.Institutes, "InstituteID", "Name", profession.InstituteID);
            return View(profession);
        }

        // GET: Professions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession profession = await db.Professions.FindAsync(id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstituteID = new SelectList(db.Institutes, "InstituteID", "Name", profession.InstituteID);
            return View(profession);
        }

        // POST: Professions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProfessionID,Name,AddTime,InstituteID")] Profession profession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profession).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.InstituteID = new SelectList(db.Institutes, "InstituteID", "Name", profession.InstituteID);
            return View(profession);
        }

        // GET: Professions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession profession = await db.Professions.FindAsync(id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            return View(profession);
        }

        // POST: Professions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Profession profession = await db.Professions.FindAsync(id);
            db.Professions.Remove(profession);
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
