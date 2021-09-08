using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Management.Models.Person;

namespace Management.Controllers
{
    public class HomeController : Controller
    {
        private ManagementDBContext db = new ManagementDBContext();

        // GET: Home
        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("Index", "Operation");
        }

        // GET: Home/Info
        public ActionResult Info(string info)
        {
            ViewBag.Info = info;
            return View();
        }

        // GET: Home/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        // GET: Home/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Home/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "PersonId,Password")] Person person)
        {
            //if (ModelState.IsValid)
            //{
                var userinfo = db.Persons.FirstOrDefault(u => u.PersonId == person.PersonId && u.Password == person.Password);

                if (userinfo != null)
                {
                    ViewBag.LoginState = true;
                }
                else
                    ViewBag.LoginState = false;
            //}
            if (ViewBag.LoginState)
            {
                Session["CurrentUserId"] = userinfo.PersonId;
                Session["CurrentUserIsAdminister"] = userinfo.IsAdminister;
                return RedirectToAction("info", new { Info = ((bool)Session["CurrentUserIsAdminister"] ? "Administer :" : "General User :")+ Session["CurrentUserId"].ToString() + " Login" });
            }
            else
            {
                return RedirectToAction("info", new { Info = "Accout " + person.PersonId + " Login Failed" });
            }
        }


        // GET: Home/Regester
        public ActionResult Register()
        {
            return View();
        }

        // POST: Home/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Password,Name,Phone,Department")] Person person)
        {
            if (ModelState.IsValid)
            {
                person.IsAdminister = false;
                db.Persons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Info", new { info = ("Your Register Account Number Is: " + person.PersonId) });
            }
            else
            {
                return RedirectToAction("Info", new { info = "Register Failed"});
            }
        }
        

    }
}