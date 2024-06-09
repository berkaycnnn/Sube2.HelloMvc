namespace Sube2.EntityApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var ogr = new Ogrenci { Ad = "Ahmet", Soyad = "Mehmet", Numara = "456" };
            //using (var ctx = new OkulDbContext())
            //{
            //    ctx.Ogrenciler.Add(ogr); ogrenciyi dbsete ekledik change tracking bakıyor ve yeni bir kayıt geldiğini anlıyor
            //    int sonuc = ctx.SaveChanges(); savechanges diyerek veritabanına insert attık
            //    Console.WriteLine(sonuc > 0 ? "Başarılı" : "Başarısız");
            //}
            // using niye kullandı


            //using (var ctx = new OkulDbContext())
            //{
            //    var ogr = ctx.Ogrenciler.Find(1);
            //    if (ogr != null)
            //    {
            //        ogr.Numara = "789"; burada update atınca da state i modified olur
            //        Console.WriteLine(ctx.SaveChanges() > 0 ? "Güncelleme Başarılı" : "Başarısız!");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Öğrenci Bulunamadı!");
            //    }
            //}


            //using (var ctx = new OkulDbContext())
            //{
            //    var ogr = ctx.Ogrenciler.Find(1);
            //    if (ogr!=null)
            //    {
            //        ctx.Ogrenciler.Remove(ogr); remove edersek state i deleted oluyor
            //        ctx.SaveChanges();
            //    }
            //}



            using (var ctx = new OkulDbContext())
            {
                var lst = ctx.Ogrenciler.ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine(item.Ad); //dbsette liste oluşturmuşuz ve foreachle ekrana yansıtmışız.
                }
            }
        }

        }
    }
