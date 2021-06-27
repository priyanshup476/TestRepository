using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDBContext _db;

        public ExpenseController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.expense;  //find data in db and displaying in view
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
        public IActionResult Create(Expense obj)
        {
            if(ModelState.IsValid)
            {
                _db.expense.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
           
        }




        
        //Get-Delete
        public IActionResult Delete(int? id)
        {
          if(id==null || id==0)
          
            {
                return NotFound();
            }
            var obj = _db.expense.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
          
            return View(obj);



        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        //Post-Delete
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.expense.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
            
                _db.expense.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
         
         

        }

        //Get-Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)

            {
                return NotFound();
            }
            var obj = _db.expense.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);



        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //Post-Update
        public IActionResult Update(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.expense.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //implementation of search
        [HttpGet]
        public async Task<IActionResult> Index(string SearchTerm)
        {
            ViewData["GetData"] = SearchTerm; ;

            var expenseData = from x in _db.expense select x;
            if(!String.IsNullOrEmpty(SearchTerm))
            {
                expenseData = expenseData.Where(x => x.ExpenseName.Contains(SearchTerm));
            }
            return View(await expenseData.AsNoTracking().ToListAsync());
        }



    }
}
