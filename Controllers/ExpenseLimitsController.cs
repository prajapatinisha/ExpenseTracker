using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project1.Models;

namespace Project1.Controllers
{
    public class ExpenseLimitsController : Controller
    {
        private cs db = new cs();

        // GET: ExpenseLimits
        public ActionResult Index()
        {
            var expenseLimits = db.ExpenseLimits.Include(e => e.expense);
            return View(expenseLimits.ToList());
        }

        // GET: ExpenseLimits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseLimit expenseLimit = db.ExpenseLimits.Find(id);
            if (expenseLimit == null)
            {
                return HttpNotFound();
            }
            return View(expenseLimit);
        }

        // GET: ExpenseLimits/Create
        public ActionResult Create()
        {
            ViewBag.ExpId = new SelectList(db.Expenses, "ExpId", "Title");
            return View();
        }

        // POST: ExpenseLimits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpLimitId,TotExpLimit,ExpId")] ExpenseLimit expenseLimit)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseLimits.Add(expenseLimit);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Data Inserted!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data Not Inserted!')</script>";
                }
                return RedirectToAction("Index");
            }

            ViewBag.ExpId = new SelectList(db.Expenses, "ExpId", "Title", expenseLimit.ExpId);
            return View(expenseLimit);
        }

        // GET: ExpenseLimits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseLimit expenseLimit = db.ExpenseLimits.Find(id);
            if (expenseLimit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpId = new SelectList(db.Expenses, "ExpId", "Title", expenseLimit.ExpId);
            return View(expenseLimit);
        }

        // POST: ExpenseLimits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpLimitId,TotExpLimit,ExpId")] ExpenseLimit expenseLimit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenseLimit).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdatedMessage"] = "<script>alert('Data Updated!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UpdatedMessage = "<script>alert('Data Not Updated!')</script>";
                }
                return RedirectToAction("Index");
            }
            ViewBag.ExpId = new SelectList(db.Expenses, "ExpId", "Title", expenseLimit.ExpId);
            return View(expenseLimit);
        }

        // GET: ExpenseLimits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseLimit expenseLimit = db.ExpenseLimits.Find(id);
            if (expenseLimit == null)
            {
                return HttpNotFound();
            }
            return View(expenseLimit);
        }

        // POST: ExpenseLimits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseLimit expenseLimit = db.ExpenseLimits.Find(id);
            db.ExpenseLimits.Remove(expenseLimit);
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["DeletedMessage"] = "<script>alert('Data Deleted!')</script>";
            }
            else
            {
                ViewBag.DeletedMessage = "<script>alert('Data Not Deleted!')</script>";
            }
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
