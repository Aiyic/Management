using Management.Models;
using Management.Models.Goods;
using Management.Models.Person;
using Management.Models.Record;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Management.Controllers
{
    
    public class OperationController : Controller
    {

        private ManagementDBContext db = new ManagementDBContext();
        
        // GET: Operation
        public ActionResult Index()
        {
            return View();
        }


        // GET: Operation/Borrow
        public ActionResult Borrow()
        {
            if (Session["CurrentUserId"] != null && Session["CurrentUserIsAdminister"] != null)
                return View();
            else
                return RedirectToAction("Info", "Home", new { Info = "请先登录" });
        }

        // POST: Records/Borrow
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Borrow([Bind(Include = "PersonId,GoodId,OperationNum,OperationType,OperationTime")] Record record)
        {
            if (ModelState.IsValid)
            {
                Goods goods = db.Goods.Find(record.GoodId);
                if (goods != null)
                {
                    if(goods.GoodsNum < record.OperationNum)
                        return RedirectToAction("Info", "Home", new { Info = "借用数量大于商品数量！！！" });
                    record.PersonId = (int)Session["CurrentUserId"];
                    if(goods.GoodsType==GoodType.借用品)
                        record.OperationType = OpType.借用;
                    else if(goods.GoodsType == GoodType.消耗品)
                        record.OperationType = OpType.消耗;
                    record.OperationTime = DateTime.Now;

                    goods.GoodsNum -= record.OperationNum;
                    db.Entry(goods).State = EntityState.Modified;
                    
                    db.Records.Add(record);
                    db.SaveChanges();
                    return RedirectToAction("Info", "Home", new { Info = "操作成功" });
                }
                else
                    return RedirectToAction("Info", "Home", new { Info = "商品编号 " + record.GoodId + " 不存在" });
            }
            return View(record);
        }

        // GET: Operation/Return
        public ActionResult Return()
        {
            if (Session["CurrentUserId"] != null && Session["CurrentUserIsAdminister"] != null)
                return View();
            else
                return RedirectToAction("Info", "Home", new { Info = "请先登录" });
        }
        // POST: Records/Return
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Return([Bind(Include = "PersonId,GoodId,OperationNum,OperationType,OperationTime")] Record record)
        {
            if (ModelState.IsValid)
            {
                Goods goods = db.Goods.Find(record.GoodId);
                if (goods == null)
                    return RedirectToAction("Info", "Home", new { Info = "商品编号 " + record.GoodId + " 不存在" });

                if (goods.GoodsType == GoodType.消耗品)
                    return RedirectToAction("Info", "Home", new { Info = "商品编号 " + record.GoodId + " 是消耗品" });

                int CurrentUserId = (int)Session["CurrentUserId"];
                
                var BorrowRecords =
                    from Record in db.Records
                    where Record.PersonId == CurrentUserId
                        && Record.OperationType == OpType.借用
                        && Record.GoodId == record.GoodId
                    select new { number = Record.OperationNum };

                var ReturnRecords =
                    from Record in db.Records
                    where Record.PersonId == CurrentUserId
                        && Record.OperationType == OpType.归还
                        && Record.GoodId == record.GoodId
                    select new { number = Record.OperationNum };

                int TotalBorrowNum = 0, TotalReturnNum = 0;
                if(BorrowRecords != null)
                    foreach (var i in BorrowRecords.ToArray())
                    {
                        TotalBorrowNum += i.number;
                    }
                else
                    return RedirectToAction("Info", "Home", new { Info = "用户 " + Session["CurrentUserId"] + " 未借用商品 " + record.GoodId });

                if (BorrowRecords != null)
                    foreach (var i in ReturnRecords.ToArray())
                    {
                        TotalReturnNum += i.number;
                    }

                if(TotalBorrowNum-TotalReturnNum < record.OperationNum)
                {
                    return RedirectToAction("Info", "Home", new { Info = "用户 " + Session["CurrentUserId"] + " 归还数量大于借用数" });
                }
                record.PersonId = (int)Session["CurrentUserId"];
                record.OperationType = OpType.归还;
                record.OperationTime = DateTime.Now;

                goods.GoodsNum += record.OperationNum;
                db.Entry(goods).State = EntityState.Modified;

                db.Records.Add(record);
                db.SaveChanges();
                return RedirectToAction("Info", "Home", new { Info = "操作成功" });
               
            }
            return View(record);
        }


        // GET: Operation/Consumption
        public ActionResult Consumption()
        {
            if (Session["CurrentUserId"] != null && Session["CurrentUserIsAdminister"] != null)
                return View();
            else
                return RedirectToAction("Info", "Home", new { Info = "请先登录" });
        }
        // POST: Records/Consumption
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Consumption([Bind(Include = "PersonId,GoodId,OperationNum,OperationType,OperationTime")] Record record)
        {
            if (ModelState.IsValid)
            {
                Goods goods = db.Goods.Find(record.GoodId);
                if (goods != null)
                {
                    record.PersonId = (int)Session["CurrentUserId"];
                    record.OperationType = OpType.消耗;
                    record.OperationTime = DateTime.Now;

                    goods.GoodsNum -= record.OperationNum;
                    db.Entry(goods).State = EntityState.Modified;

                    db.Records.Add(record);
                    db.SaveChanges();
                    return RedirectToAction("Info", "Home", new { Info = "操作成功" });
                }
                else
                    return RedirectToAction("Info", "Home", new { Info = "商品编号 " + record.GoodId + " 不存在" });
            }
            return View(record);
        }
        
        // GET: Operation/Search
        public ActionResult Search()
        {
            if (Session["CurrentUserId"] != null && Session["CurrentUserIsAdminister"] != null)
                return View();
            else
                return RedirectToAction("Info", "Home", new { Info = "请先登录" });
        }

        // POST: Records/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string GoodsName)
        {
            IQueryable<Goods> goodsinfo = null;
            if (ModelState.IsValid)
            {
                goodsinfo =
                    from Goods in db.Goods
                    where Goods.GoodsName.Contains(GoodsName)
                    select Goods;
                
                if (goodsinfo == null)
                    return RedirectToAction("Info", "Home", new { Info = "商品名 " + GoodsName + " 不存在" });
            }
            return View(goodsinfo.ToList<Goods>());
        }


        // GET: Operation/PersonRecord
        public ActionResult PersonRecord()
        {
            if (Session["CurrentUserId"] != null && Session["CurrentUserIsAdminister"] != null)
            {
                int CurrentUserId = (int)Session["CurrentUserId"];
                IQueryable<Record> person_record = null;
                person_record =
                    from Record in db.Records
                    where Record.PersonId == CurrentUserId
                    select Record;

                if (person_record == null)
                    return RedirectToAction("Info", "Home", new { Info = "用户 " + Session["CurrentUserId"] + " 暂无借还记录" });

                return View(person_record.ToList<Record>());
            }
            else
                return RedirectToAction("Info", "Home", new { Info = "请先登录" });

        }
    }
}