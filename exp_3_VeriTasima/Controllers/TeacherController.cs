using exp_3_VeriTasima.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exp_3_VeriTasima.Controllers
{  
    public class TeacherController : Controller
    {

        List<Teacher> ogretmenler = new List<Teacher>()
        {
            new Teacher { Id=1,Ad="Ali", Soyad="Yılmaz", Brans= Brans.Felsefe}
        };

        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View(ogretmenler);
        }

        public ActionResult Add()
        {
            ViewBag.dropdownVD = new SelectList(Enum.GetValues(typeof(Brans)));
            
            var model = new Teacher();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Teacher model)
        {
            model.Id = ogretmenler.Max(x => x.Id) + 1;
            ogretmenler.Add(model);
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var teacherToBeEdited = ogretmenler.FirstOrDefault(x => x.Id == id);
            return View(teacherToBeEdited);
        }

        [HttpPost]
        public ActionResult Edit(Teacher model)
        {
            var ogretmen = ogretmenler.FirstOrDefault(x => x.Id == model.Id);

            if (ogretmen != null)
            {
                ogretmen.Ad = model.Ad;
                ogretmen.Soyad = model.Soyad;
                ogretmen.Brans = model.Brans;

            }
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var ogretmen = ogretmenler.FirstOrDefault(x => x.Id == id);

            if (ogretmen != null)
            {
                ogretmenler.Remove(ogretmen);
            }
            return RedirectToAction("List");
        }
    }
}