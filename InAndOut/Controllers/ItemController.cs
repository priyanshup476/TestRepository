using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        //Dependency Injection Object recieve another objects
        private readonly ApplicationDBContext _db;

        public ItemController(ApplicationDBContext  db)
        {
            _db =db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;  //find data in db and displaying in view
            return View(objList);
        }

        //Get-Create
        public IActionResult Create()
        {
         
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Post-Create
        public IActionResult Create(Item obj)
        {
            _db.Items.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
