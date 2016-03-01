using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication4.Models;

namespace MvcApplication4.Controllers
{ 
    public class NoteController : Controller
    {
        private MusicStoreEntities db = new MusicStoreEntities();

        //
        // GET: /Note/

        public ViewResult Index(int? _categoryID)
        {
            var notes = db.Notes.Include(n => n.Category);

            if (_categoryID.HasValue)
            {
                notes = notes.Where(a => a.CategoryId == _categoryID);


            }


            return View(notes.ToList());
        }



        //
        // GET: /Note/Details/5

        public ViewResult Details(int id)
        {
            Note note = db.Notes.Find(id);
            return View(note);
        }

        //
        // GET: /Note/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        } 

        //
        // POST: /Note/Create

        [HttpPost]
        public ActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                db.Notes.Add(note);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", note.CategoryId);
            return View(note);
        }
        
        //
        // GET: /Note/Edit/5
 
        public ActionResult Edit(int id)
        {
            Note note = db.Notes.Find(id);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", note.CategoryId);
            return View(note);
        }

        //
        // POST: /Note/Edit/5

        [HttpPost]
        public ActionResult Edit(Note note)
        {
            if (ModelState.IsValid)
            {
                db.Entry(note).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", note.CategoryId);
            return View(note);
        }

        //
        // GET: /Note/Delete/5
 
        public ActionResult Delete(int id)
        {
            Note note = db.Notes.Find(id);
            return View(note);
        }

        //
        // POST: /Note/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Note note = db.Notes.Find(id);
            db.Notes.Remove(note);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}