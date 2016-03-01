using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication4.Models;

namespace MvcApplication4.Models
{
    public class Note
    {
     

     public int NoteId { get; set; }
     public int CategoryId { get; set; }
      public int Lat { get; set; }
      public int Lng { get; set; }
      public string Title { get; set; }
      public Category Category { get; set; }
      

    }
}