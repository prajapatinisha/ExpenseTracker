using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1.Models;
using System.Web.Security;

namespace Project1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using(cs db = new cs())
            {
                return View(db.UserAccounts.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if(ModelState.IsValid)
            {
                using (cs db = new cs())
                {
                    db.UserAccounts.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName+ " " + account.LastName+" successfully registerd.";
            }
            return RedirectToAction("Login");
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using(cs db = new cs())
            {
                 bool isValid = db.UserAccounts.Any(u=>u.UserName== user.UserName && u.Password == user.Password);
                if (isValid)
                {
                    //Session["UserId"] = usr.UserId.ToString();
                    //Session["UserName"] = usr.UserName.ToString();

                    FormsAuthentication.SetAuthCookie(user.UserName,false);
                    return RedirectToAction("Index","Expenses");
                }
                ModelState.AddModelError("", "username or password is wrong.");

                return View();
            }
        }

      /*  public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Expenses");
            }
        }*/
    }
}