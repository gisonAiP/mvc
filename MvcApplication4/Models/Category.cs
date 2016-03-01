using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication4.Models;

namespace MvcApplication4.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Note> Notes { get; set; }


       
    }
}