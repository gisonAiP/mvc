﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication4.Models;

namespace MvcApplication4.Controllers
{ 
    public class CategoryController : Controller
    {
        private MusicStoreEntities db = new MusicStoreEntities();

        //
        // GET: /Category/

        public ViewResult Index()
        {
            return View(db.Categories.ToList());
        }
        
        //
        // GET: /Category/Details/5

        public ViewResult Details(int id)
        {
            Category category = db.Categories.Find(id);
            return View(category);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(category);
        }
        
        //
        // GET: /Category/Edit/5
 
        public ActionResult Edit(int id)
        {
            Category category = db.Categories.Find(id);
            return View(category);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //
        // GET: /Category/Delete/5
 
        public ActionResult Delete(int id)
        {
            Category category = db.Categories.Find(id);
            return View(category);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Browse(string category)
        {
            // Retrieve Genre and its Associated Albums from database
            var categoryModel = db.Categories.Include("Notes")
            .Single(g => g.Name == category);
            return View(categoryModel);
        }
    }
}