using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Management.Models;
using Management.Models.Record;

namespace Management.Controllers
{
    public class RecordsController : Controller
    {
        private ManagementDBContext db = new ManagementDBContext();

        // GET: Records
        public ActionResult Index()
        {
            if (Session["CurrentUserId"] != null && Session["CurrentUserIsAdminister"] != null)
            {
                if ((bool)Session["CurrentUserIsAdminister"])
                    return View(db.Records.ToList());
                else
                    return RedirectToAction("info", "Home", new { Info = "账号 " + Session["CurrentUserId"] + " 不是管理员" });
            }
            else
                return RedirectToAction("Info", "Home", new { Info = "请先登录" });
        }

        // GET: Records/Details/5
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
                    Record record = db.Records.Find(id);
                    if (record == null)
                    {
                        return HttpNotFound();
                    }
                    return View(record);
                }
                else
                    return RedirectToAction("info", "Home", new { Info = "账号 " + Session["CurrentUserId"] + " 不是管理员" });
            }
            else
                return RedirectToAction("Info", "Home", new { Info = "请先登录" });
        }

        // GET: Records/Create
        public ActionResult Create()
        {
            if (Session["CurrentUserId"] != null && Session["CurrentUserIsAdminister"] != null)
            {
                if ((bool)Session["CurrentUserIsAdminister"])
                    return View();
                else
                    return RedirectToAction("info", "Home", new { Info = "账号 " + Session["CurrentUserId"] + " 不是管理员" });
            }
            else
                return RedirectToAction("Info", "Home", new { Info = "请先登录" });
        }

        // POST: Records/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,GoodId,OperationNum,OperationType,OperationTime")] Record record)
        {
            if (ModelState.IsValid)
            {
                record.OperationTime = DateTime.Now;
                db.Records.Add(record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(record);
        }

        // GET: Records/Edit/5
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
                    Record record = db.Records.Find(id);
                    if (record == null)
                    {
                        return HttpNotFound();
                    }
                    return View(record);
                }
                else
                    return RedirectToAction("info", "Home", new { Info = "账号 " + Session["CurrentUserId"] + " 不是管理员" });
            }
            else
                return RedirectToAction("Info", "Home", new { Info = "请先登录" });
        }

        // POST: Records/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordId,PersonId,GoodId,OperationNum,OperationType,OperationTime")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(record);
        }

        // GET: Records/Delete/5
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
                    Record record = db.Records.Find(id);
                    if (record == null)
                    {
                        return HttpNotFound();
                    }
                    return View(record);
                }
                else
                    return RedirectToAction("info", "Home", new { Info = "账号 " + Session["CurrentUserId"] + " 不是管理员" });
            }
            else
                return RedirectToAction("Info", "Home", new { Info = "请先登录" });
        }

        // POST: Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Record record = db.Records.Find(id);
            db.Records.Remove(record);
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
