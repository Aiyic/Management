using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Management.Models;
using Management.Models.Goods;

namespace Management.Controllers
{
    public class GoodsController : Controller
    {
        private ManagementDBContext db = new ManagementDBContext();

        // GET: Goods
        public ActionResult Index()
        { 
            if (Session["CurrentUserId"] != null && Session["CurrentUserIsAdminister"] != null)
            {
                return View(db.Goods.ToList());
            }
            else
                return RedirectToAction("Info", "Home", new { Info = "请先登录" });
        }

        // GET: Goods/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["CurrentUserId"] != null && Session["CurrentUserIsAdminister"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Goods goods = db.Goods.Find(id);
                if (goods == null)
                {
                    return HttpNotFound();
                }
                return View(goods);
            }
            else
                return RedirectToAction("Info", "Home", new { Info = "请先登录" });
        }

        // GET: Goods/Create
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

        // POST: Goods/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GoodsName,GoodsNum,GoodsPrice,GoodsType,GoodsBuyTime")] Goods goods)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    goods.GoodsBuyTime = DateTime.Now;
                    db.Goods.Add(goods);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return RedirectToAction("info", "Home", new { Info = "添加出错" });
            }
            return View(goods);
        }

        // GET: Goods/Edit/5
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
                    Goods goods = db.Goods.Find(id);
                    if (goods == null)
                    {
                        return HttpNotFound();
                    }
                    return View(goods);
                }
                else
                    return RedirectToAction("info", "Home", new { Info = "账号 " + Session["CurrentUserId"] + " 不是管理员" });
            }
            else
                return RedirectToAction("Info", "Home", new { Info = "请先登录" });
        }

        // POST: Goods/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GoodsId,GoodsName,GoodsNum,GoodsPrice,GoodsType,GoodsBuyTime")] Goods goods)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(goods).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(goods);
            }
            catch
            {
                return RedirectToAction("info", "Home", new { Info = "编辑出错" });
            }
        }

        // GET: Goods/Delete/5
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
                    Goods goods = db.Goods.Find(id);
                    if (goods == null)
                    {
                        return HttpNotFound();
                    }
                    return View(goods);
                }
                else
                    return RedirectToAction("info", "Home", new { Info = "账号 " + Session["CurrentUserId"] + " 不是管理员" });
            }
            else
                return RedirectToAction("Info", "Home", new { Info = "请先登录" });
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Goods goods = db.Goods.Find(id);
            db.Goods.Remove(goods);
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
