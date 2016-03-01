using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication4.Models;

namespace MvcApplication4.Controllers
{
    public class Store1Controller : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        //
        // GET: /Store1/

        public ActionResult Index()
        {
            var categories = storeDB.Categories.ToList();

            return View(categories);
        }
        
     
            // GET:/Store1/Browse?note=Disco

        public string Browse(string category)
        {
            string message = HttpUtility.HtmlEncode("Store1.Browse, Category = " + category);
            return message;
        }

            // GET: /Store1/Details/3


            public ActionResult Details(int id)
             {
              var category = new Category { Name = "Category" + id };
             return View(category);
              }
            //
            // GET: /Store/CategoryMenu
            [ChildActionOnly]
            public ActionResult CategoryMenu()
            {
                var categories = storeDB.Categories.ToList();
                return PartialView(categories);
            }

    }
        }
    
