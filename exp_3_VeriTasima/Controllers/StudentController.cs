using exp_3_VeriTasima.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exp_3_VeriTasima.Controllers
{
    public class StudentController : Controller
    {
        //student CRUD student controller'da yapılır. Herkesin CRUDu kendi Controller'ında olur.
        static List<Ogrenci> ogrList = new List<Ogrenci>() // globale tanımladık. Burası static olmak zorunda veri tabanını işin içine katmadığımız için.
        {
             new Ogrenci(){Id=1,Ad="Leyla", Soyad="Taş"},
             new Ogrenci(){Id=2, Ad="Çiğdem", Soyad="Türkmen"},
        };

        #region Öğrenci Listeleme İşlemi
        public ActionResult List()
        {
            // Veritabanından öğrencileri getiriyoruz.
            return View(ogrList);
        } 
        #endregion

        #region Öğrenci Ekleme İşlemleri
        [HttpGet] // kendiliğinden get metodu ile çalışır bu attributu yazmasan da. HTTP:veri transfer protokolü
        public ActionResult Add()
        {
            
            //var benzersizId = Guid.NewGuid();
            var model = new Ogrenci();
            return View(model);
        }

        [HttpPost] // diğer http metodlarını çalış. http metodları: get post put patch delete. WEB API'da daha sık kullanılıyolar. Mülakatta sorulur!
        public ActionResult Add(Ogrenci model)
        {
            //veritabanı işlemleri burada tamamlanır
            model.Id = ogrList.Max(x => x.Id) + 1;
            ogrList.Add(model);
            return RedirectToAction("List");
        }

        #endregion

        //model yöntemiyle iki taraflı veri taşıma yapılabiliriyor. Yani hem View'dan Controller'a hem Controller'dan View'a.

        #region Güncelleme İşlemleri
        public ActionResult Edit(int id) // bu sayfa sadece id verildiğinde açılır.
        {
            var ogrenci = ogrList.FirstOrDefault(x => x.Id == id);
            return View(ogrenci);
        }

        [HttpPost]
        public ActionResult Edit(Ogrenci model)
        {
            var ogrenci = ogrList.FirstOrDefault(x => x.Id == model.Id);

            if (ogrenci != null)
            {
                ogrenci.Ad = model.Ad;
                ogrenci.Soyad = model.Soyad;
            }

            return RedirectToAction("List");
        }
        #endregion


        #region Silme İşlemi
        public ActionResult Delete(int id)
        {
            var ogrenci = ogrList.FirstOrDefault(x => x.Id == id);

            if (ogrenci != null)
            {
                ogrList.Remove(ogrenci);
            }
            return RedirectToAction("List");
        }
        #endregion

        //WEB API'daki viewler başka bir teknoloji ile oluşturuluyor, onda viewlar yok.
    }
}