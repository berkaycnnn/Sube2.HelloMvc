using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sube2.HelloMvc.Models;
using Sube2.HelloMvc.Models.Relationships;

namespace Sube2.HelloMvc.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            using (var ctx = new OkulDbContext())
            {
                var lst = ctx.Ogrenciler.ToList();
                return View(lst);
            }
        }

        public IActionResult AddStudent() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Ogrenci ogr)
        { 
            if(ogr != null)
            {
                using (var ctx = new OkulDbContext()) 
                {
                    ctx.Ogrenciler.Add(ogr);
                    ctx.SaveChanges();
                }
                    
            }
            return RedirectToAction("Index");
        }
        public IActionResult EditStudent(int id) 
        {
            using (var ctx = new OkulDbContext())
            {
                var ogr = ctx.Ogrenciler.Find(id);
                return View(ogr);
            }
        }
        [HttpPost]
        public IActionResult EditStudent(Ogrenci ogr)
        {
            if (ogr != null)
            {
                using (var ctx = new OkulDbContext())
                {
                    ctx.Entry(ogr).State = EntityState.Modified; 
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");   
        }
        public IActionResult DeleteStudent(int id) 
        {

            using (var ctx = new OkulDbContext()) 
            {
                ctx.Ogrenciler.Remove(ctx.Ogrenciler.Find(id));
                ctx.SaveChanges();
            }   
            return RedirectToAction("Index");
        }
        
        public IActionResult OgrenciDersleri(int id)
        {
            using (var ctx = new OkulDbContext())
            {
                var ogrenci = ctx.Ogrenciler.Include(o => o.OgrenciDersler!).ThenInclude(od => od.Ders).FirstOrDefault(o => o.Ogrenciid == id);

                return View(ogrenci);
            }
        }

        [HttpGet]
        public IActionResult AddDersForOgrenci(int studentId)
        {
            using (var ctx = new OkulDbContext())
            {
                var dersler = ctx.Dersler.ToList();
                var ogrenciDersler = ctx.OgrenciDersler.Where(od => od.Ogrenciid == studentId).Select(od => od.Dersid).ToList();
                var AktifDersler = dersler.Where(d => !ogrenciDersler.Contains(d.Dersid)).ToList();

                ViewBag.StudentId = studentId;
                return View(AktifDersler);
            }
        }


        [HttpPost]
        public IActionResult AddDersForOgrenci(int studentId, List<int> dersIds)
        {
            using (var ctx = new OkulDbContext())
            {
                var mevcutDersId = ctx.OgrenciDersler.Where(od => od.Ogrenciid == studentId).Select(od => od.Dersid).ToList();
                var yeniDersId = dersIds.Except(mevcutDersId).ToList();

                foreach (var dersId in yeniDersId)
                {
                    var ogrenciDers = new OgrenciDers
                    {
                        Ogrenciid = studentId,
                        Dersid = dersId
                    };
                    ctx.OgrenciDersler.Add(ogrenciDers);
                }
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
    
