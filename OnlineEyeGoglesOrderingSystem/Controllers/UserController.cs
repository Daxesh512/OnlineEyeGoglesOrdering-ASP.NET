using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using OnlineEyeGoglesOrderingSystem.Models;
using System.Data.Entity;

namespace OnlineEyeGoglesOrderingSystem.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Order()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactTbl contactTbl)
        {
            using (DataGoglesEntities db = new DataGoglesEntities())
            {
                if (ModelState.IsValid)
                {
                    db.ContactTbls.Add(contactTbl);
                    db.SaveChanges();
                    ViewBag.message = "Feedback Send Sucessfully";
                    ModelState.Clear();
                }
            }
            return View(contactTbl);
        }
    [HttpPost]
        public ActionResult Registration(TblUser tblUser)
        {
            using (DataGoglesEntities db = new DataGoglesEntities())
            {
                if (ModelState.IsValid)
                {
                    db.TblUsers.Add(tblUser);
                    db.SaveChanges();
                    ViewBag.message = "Feedback Send Sucessfully";
                    ModelState.Clear();
                }
            }
            return View(tblUser);
        }
        [HttpPost]
        public ActionResult Login(TblUser tblUser)
        {
            using (DataGoglesEntities db = new DataGoglesEntities())
            {
                if (ModelState.IsValid)
                {
                    var obj = db.TblUsers.Where(a => a.email.Equals(tblUser.email) && a.pass.Equals(tblUser.pass)).FirstOrDefault();
                    if (obj != null)
                    {
                        //Session["UserID"] = obj.UserId.ToString();
                        //Session["UserName"] = obj.email.ToString();
                        return RedirectToAction("Home/Order");
                    }
                }
            }
            return View(tblUser);
        }
        [HttpPost]
        public ActionResult Order(OrderTB orderTB)
        {
            using (DataGoglesEntities db = new DataGoglesEntities())
            {
                if (ModelState.IsValid)
                {
                    db.OrderTBs.Add(orderTB);
                    db.SaveChanges();
                    ViewBag.message = "Order Sucessfully";
                    ModelState.Clear();
                }
            }
            return View(orderTB);
        }
    }
}