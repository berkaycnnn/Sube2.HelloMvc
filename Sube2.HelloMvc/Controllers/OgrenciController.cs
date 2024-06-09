using Microsoft.AspNetCore.Mvc;
using Sube2.HelloMvc.Models;


namespace Sube2.HelloMvc.Controllers
{
    public class OgrenciController : Controller
    {
        public ViewResult Index()  //Action
        {
            return View();
        }

        public ViewResult OgrenciDetay(int id)
        {
            //Ogretmen ogrt = null;
            //Models.Ogrenci ogr = null;
            //Ders ds = null;
            //if (id == 1) 
            //{
            //    ogr= new Models.Ogrenci();
            //    ogr.Ad = "Ali";
            //    ogr.Soyad = "Veli";
            //    ogr.Numara = 123;

            //    ogrt = new Ogretmen();
            //    ogrt.Ad = "Ali Berkay";
            //    ogrt.Soyad = "CAN";
            //    ogrt.OgretmenId = 1;

            //    ds = new Ders();
            //    ds.kredi = 5;
            //    ds.DersId = 1;
            //    ds.DersAd = "Programlama";
            //}
            //else if (id == 2) 
            //{
            //    ogr = new Models.Ogrenci { Ad = "Ahmet", Soyad = "Mehmet", Numara = 123 };
            //}

            ////var model = Tuple.Create(ogr, ogrt);

            //ViewData["school"] = ogr;
            //ViewBag.student = ogr;
            //ViewBag.ogretmen = ogrt;

            //OkulViewModels vm = new OkulViewModels();
            //vm.ogretmen = ogrt;
            //vm.ogrenci = ogr;
            //vm.ders = ds;
            return View();
        }

        public ViewResult OgrenciListe()
        {
            //var lst = new List<Models.Ogrenci> { 
            //new Models.Ogrenci { Ad = "Mert", Soyad = "Mehmet", Numara = 1 },
            //new Models.Ogrenci { Ad = "Selim", Soyad = "Okan", Numara = 2 }
            //};

            return View();
        }
    }
}


















//Controller->View veri taşıma
//ViewData:Bir koleksiyon yapısıdır. ViewData bir dictionary yapısıdır. Anahtar ve değer çiftlerinden oluşur.

//ViewBag: Arka planda ViewData koleksiyonunu kullanan,dynamic yapıda bir veri taşıma yapısıdır.

//ViewModel
