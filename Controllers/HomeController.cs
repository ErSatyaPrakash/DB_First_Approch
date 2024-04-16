using DB_First_Approch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_First_Approch.Controllers
{
    public class HomeController : Controller
    {
        DBFirst_ApprochEntities3 db =new DBFirst_ApprochEntities3();
        public ActionResult Index()
        {
            var data=db.tbl_student.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_student dd)
        {
            db.tbl_student.Add(dd);
            int a=db.SaveChanges();
            if (a>0)
            {
                TempData["InsertMsg"] = "<script>alert('Inserted')</script>";
                return RedirectToAction("Index");
            }
            else
            { 
                TempData["InsertMsg"] = "<script>alert('Failed')</script>";
            }
            return View();
        }
        public ActionResult Delete(int? id)
        {
            var data=db.tbl_student.Where(model => model.id == id).FirstOrDefault();
            
            return View(data);
        }
        [HttpPost]
        public ActionResult delete(tbl_student ss)
        {
            db.Entry(ss).State = System.Data.Entity.EntityState.Deleted;
           int a= db.SaveChanges();
            if (a > 0)
            {
                TempData["DeleteMessage"] = "Deleted 👍";
            }
            else
            {
                TempData["UpdateMessage"] = "Detele Failed 😔😔";
            }
            return RedirectToAction("Index");
           
        }

        public ActionResult Edit(int? id)
        {
            var row = db.tbl_student.Where(model => model.id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(tbl_student data)
        {
            db.Entry(data).State = System.Data.Entity.EntityState.Modified;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["UpdateMessage"] = "Data Updated 👍";
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.UpdateMessage = "Data Updated Failed 👍";

            }
            return View();
        }
        
    }
}
