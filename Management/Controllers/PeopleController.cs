using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Management.Models;
using Management.Models.Person;

namespace Management.Controllers
{
    public class PeopleController : Controller
    {
        private ManagementDBContext db = new ManagementDBContext();

        // GET: People
        public ActionResult Index()
        {
            if (Session["CurrentUserId"] != null && Session["CurrentUserIsAdminister"] != null)
                if ((bool)Session["CurrentUserIsAdminister"])
                    return View(db.Persons.ToList());
                else
                    return RedirectToAction("info", "Home", new { Info = "Accout " + Session["CurrentUserId"] + " Is Not Administer" });
            else
                return RedirectToAction("Info", "Home", new { Info = "Please Login Before Operation!!!" });
            
        }
    
        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["CurrentUserId"] != null && Session["CurrentUserIsAdminister"] != null)
            {
                if ((bool)Session["CurrentUserIsAdminister"])
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
                    return RedirectToAction("info", "Home", new { Info = "Accout " + Session["CurrentUserId"] + " Is Not Administer" });
            }
            else
                return RedirectToAction("Info", "Home", new { Info = "Please Login Before Operation!!!" });
        }

/********************************************** 调试用版本 **************************************/
        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }
/*
        // GET: People/Create
        public ActionResult Create()
        {
            if (Session["CurrentUserId"] != null && Session["CurrentUserIsAdminister"] != null)
            {
                if ((bool)Session["CurrentUserIsAdminister"])
                    return View();
                else
                    return RedirectToAction("info", "Home", new { Info = "Accout " + Session["CurrentUserId"] + " Is Not Administer" });
            }
            else
                return RedirectToAction("Info", "Home", new { Info = "Please Login Before Operation!!!" });
        }
*/

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,Password,Name,Phone,Department,IsAdminister")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["CurrentUserId"] != null && Session["CurrentUserIsAdminister"] != null)
            {
                if ((bool)Session["CurrentUserIsAdminister"])
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
                    return RedirectToAction("info", "Home", new { Info = "Accout " + Session["CurrentUserId"] + " Is Not Administer" });
            }
            else
                return RedirectToAction("Info", "Home", new { Info = "Please Login Before Operation!!!" });
        }

/********************************************** 修改IsAdminister **************************************/
/**************************************** 更新Session[IsAdminister]的状态 **************************************/
        // POST: People/Edit/5
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

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["CurrentUserId"] != null && Session["CurrentUserIsAdminister"] != null)
            {
                if ((bool)Session["CurrentUserIsAdminister"])
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
                    return RedirectToAction("info", "Home", new { Info = "Accout " + Session["CurrentUserId"] + " Is Not Administer" });
            }
            else
                return RedirectToAction("Info", "Home", new { Info = "Please Login Before Operation!!!" });
        }

/**************************************** 更改自己账户bug **************************************/
        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Persons.Find(id);
            db.Persons.Remove(person);
            db.SaveChanges();
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
