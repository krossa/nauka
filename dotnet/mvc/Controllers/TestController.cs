using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc.Db;
using mvc.Models;

namespace mvc.Controllers
{
    public class TestController : Controller
    {
    
        public IActionResult Index([FromServices] BookContext context)
        {  
            var note = context.Notes.Where(n => n.Title == "note 3").Select(n => n.Title).First();
            ViewData["Message"] = $"we have {context.Books.Count()} books and {context.Notes.Count()} notes XXXX \n {note}";
            return View();
        }
    }
}
