using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Job_Portal.context;

namespace Job_Portal.Controllers
{
    public class StudentController : Controller
    {
        RohitEntities objDb = new RohitEntities();



        // GET: Student
        public ActionResult student(tbl_3 obj)
        {
            if (obj != null)
            {
                return View(obj);
            }
            else
            return View();
        }
        [HttpPost]
        public ActionResult addStudent(tbl_3 Model)
        {

            if (ModelState.IsValid)
            {
                tbl_3 objTbl = new tbl_3();
                
                objTbl.id = Model.id;
                objTbl.name = Model.name;
                objTbl.rollno = Model.rollno;
                objTbl.phone = Model.phone;
                objTbl.Email = Model.Email;

                if (Model.id == 0)
                {

                objDb.tbl_3.Add(objTbl);
                objDb.SaveChanges();
                }
                else
                {
                    objDb.Entry(objTbl).State = System.Data.Entity.EntityState.Modified;
                    objDb.SaveChanges();

                }


            }
            ModelState.Clear();

            return View("student");
        }

        public ActionResult ShowData()
        {
            var res = objDb.tbl_3.ToList();
            return View(res);
        }
        public ActionResult Delete(int id)
            
        {
            var res = objDb.tbl_3.Where(x=>x.id==id).First();
            objDb.tbl_3.Remove(res);
            objDb.SaveChanges();

            var list = objDb.tbl_3.ToList();

            return View("ShowData",list);
        }
    }
}