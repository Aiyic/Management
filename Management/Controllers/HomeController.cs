using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Management.Models;
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
        public ActionResult Login([Bind(Include = "PersonId,Password,Name")] Person person)
        {
            Person userinfo;
            ViewBag.LoginState = false;
            if (int.TryParse(person.Name,out int id))
            {
                person.PersonId = id;
                userinfo = db.Persons.FirstOrDefault(u => u.PersonId == person.PersonId && u.Password == person.Password);
                if (userinfo != null)
                    ViewBag.LoginState = true;
                else
                {
                    userinfo = db.Persons.FirstOrDefault(u => u.Name == person.Name && u.Password == person.Password);
                    if (userinfo != null)
                        ViewBag.LoginState = true;
                }
            }
            else
            {
                userinfo = db.Persons.FirstOrDefault(u => u.Name == person.Name && u.Password == person.Password);
                if(userinfo != null)
                    ViewBag.LoginState = true;
            }
            
            if (ViewBag.LoginState)
            {
                Session["CurrentUserId"] = userinfo.PersonId;
                Session["CurrentUserIsAdminister"] = userinfo.IsAdminister;
                return RedirectToAction("info", new { Info = ((bool)Session["CurrentUserIsAdminister"] ? "管理员 : " : "普通用户 : ")+ Session["CurrentUserId"].ToString() + " 登录成功" });
            }
            else
            {
                return RedirectToAction("info", new { Info = "用户 " + person.Name + " 登录失败" });
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
            try
            {
                if (ModelState.IsValid)
                {
                    person.IsAdminister = false;
                    db.Persons.Add(person);
                    db.SaveChanges();
                    return RedirectToAction("Info", new { info = ("你注册的账户是: " + person.PersonId) });
                }
                else
                {
                    return RedirectToAction("Info", new { info = "注册失败" });
                }
            }
            catch
            {
                return RedirectToAction("Info", new { info = "用户名已被注册" });
            }
           
        }



        // GET: Home/Edit
        public ActionResult Edit(int? id)
        {
            if (Session["CurrentUserId"] != null && Session["CurrentUserIsAdminister"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Person person = db.Persons.Find(id);
                if (person == null)
                {
                    return HttpNotFound();
                }
                return View(person);
            }
            else
                return RedirectToAction("Info", "Home", new { Info = "请先登录" });
        }

        /********************************************** 修改IsAdminister **************************************/
        /**************************************** 更新Session[IsAdminister]的状态 **************************************/
        // POST: Home/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,Password,Name,Phone,Department")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }


    }
}