using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_CRUD.Context;

namespace Test_CRUD.Controllers
{
    public class StudentController : Controller
    {
        db_testEntities dbObj = new db_testEntities();

        //public StudentController(db_testEntities dbObj)
        //{
        //    this.dbObj = dbObj;
        //}

        // GET: Student
        [HttpGet]
        [Authorize]
        public ActionResult Student()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddStudent(tbl_Student model)
        {
            tbl_Student std_obj = new tbl_Student();

            std_obj.Name = model.Name;
            std_obj.Fname = model.Fname;
            std_obj.Email = model.Email;
            //std_obj.mobile = 
            std_obj.Description = model.Description;
            std_obj.Mobile = model.Mobile;

            dbObj.tbl_Student.Add(std_obj);
            dbObj.SaveChanges();
            return RedirectToAction("Student", "Student");
        }
        [Authorize]
        public ActionResult ViewStd()
        {
            List<tbl_Student> students = new List<tbl_Student>();
            var objects = dbObj.tbl_Student.ToList();
            foreach (var obj in objects)
            {
                tbl_Student std = new tbl_Student();
                std.ID = obj.ID;
                std.Name = obj.Name;
                std.Fname = obj.Fname;
                std.Mobile = obj.Mobile;
                std.Email = obj.Email;
                std.Description = obj.Description;
                students.Add(std);
            }

            ViewBag.students = students;
            return View();
        }
        [Authorize]
        public ActionResult UpdateData(DataUpdate obj)
        {
            var std = dbObj.tbl_Student.FirstOrDefault(a => a.ID == obj.id);
            if (std != null || obj != null)
            {
                std.Name = obj.name;
                std.Fname = obj.fname;
                std.Mobile = obj.mobile;
                std.Email = obj.email;
                std.Description = obj.desc;
                dbObj.SaveChanges();
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            return Json("Data Error", JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public ActionResult delete(DataUpdate obj)
        {
            var std = dbObj.tbl_Student.FirstOrDefault(a => a.ID == obj.id);
            if (std != null || obj != null)
            {
                dbObj.tbl_Student.Remove(std);
                dbObj.SaveChanges();
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            return Json("Data Error", JsonRequestBehavior.AllowGet);
        }

    }

    public class DataUpdate
    {
        public int id       { get; set; }
        public string name  { get; set; }
        public string fname { get; set; }
        public string email { get; set; }
        public string mobile{ get; set; }
        public string desc { get; set; }
    }
}