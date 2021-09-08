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

    public class ManagementDBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Record> Records { get; set; }
    }

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
            return View();
        }

        // GET: Operation/Return
        public ActionResult Return()
        {
            return View();
        }

        // GET: Operation/Regester
        public ActionResult Consumption()
        {
            return View();
        }
    }
}