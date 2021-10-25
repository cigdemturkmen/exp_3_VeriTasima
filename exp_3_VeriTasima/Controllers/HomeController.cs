using exp_3_VeriTasima.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exp_3_VeriTasima.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            /*
             * Controllerdan view'a veri taşımak için kullanılan nesneler. bu nesneler sadece controllerdan view'a veri taşırken kullanılır. view'dan controller'a taşımak için başka yöntemler kullanılır.TempData'nın farkı action'dan actiona da tek seferlik veri taşıyabilmesidir. en çok kullandığımız nesne ViewBag.;
             * 
             * ViewData["key"] = value;
                Tempdata["key"] = value;
               ViewBag.Key = value; */

            ViewData["AdSoyad"] = "Nur Öztürk";

            TempData["Fiyat"] = 10.30;

            //öğrenci listesi oluşturunuz.

            var ogrenciList = new List<Ogrenci>()
            {
                new Ogrenci()
                {
                    Ad="Leyla",
                    Soyad="Taş"
                },
                new Ogrenci()
                {
                    Ad="Çiğdem",
                    Soyad="Türkmen"
                },
            };

            ViewBag.OgrenciListesi = ogrenciList;

            return View();
        }

        public ActionResult Hakkimizda()
        {
            var fiyat = TempData["Fiyat"];

            return View();
        }

        public ActionResult Iletisim()
        {
            // 1. yöntem uzun yöntem. birden fazla bilgi göndermek için.
            ViewBag.Adres = "ankara";
            ViewBag.Telefon = "03122500938";
            ViewBag.Fax = "03123456789";
            ViewBag.Bayiler = new List<string>()
            {
                "çankaya","keçiören","yenimahalle"
            };

            // 2. yöntem: göndereceğiniz bilgileri model olarak(yeni bir nesne) olarak tanımlayabilriisniz. modelde yeni bir sınıf oluişturuldu.

            var viewModel = new IletisimViewModel()
            {
                Adres = "ankara",
                Telefon = "03122500938",
                Fax = "03123456789",
                Bayiler = new List<string>()
                {
                    "çankaya","keçiören","yenimahalle"
                }
            };
            return View(viewModel);
        }
    }
}