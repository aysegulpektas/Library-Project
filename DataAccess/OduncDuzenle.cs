using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess
{
    public class OduncDuzenle
    {
        public void Ekle(Odunc odunc)
        {
            using (LibraryContext context = new LibraryContext())
            {
                var addedEntity = context.Entry(odunc);
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }
        public List<Odunc> Listele(Expression<Func<Odunc, bool>> filter = null)
        {
            using (LibraryContext context = new LibraryContext())
            {
                return filter == null ? context.Set<Odunc>().ToList() : context.Set<Odunc>().Where(filter).ToList();
            }
        }
        public List<OduncDetaylariDto> DetayListele(Expression<Func<OduncDetaylariDto, bool>> filter = null)
        {
            using (LibraryContext context = new LibraryContext())
            {
                var detaylar = from o in context.Oduncverilenler
                               join k in context.Kitaplar on o.KitapId equals k.Id
                               join u in context.Uyeler on o.UyeId equals u.Id
                               select new OduncDetaylariDto
                               {
                                   KitapAdi = k.KitapAdi,
                                   KitapBarkodNo = k.BarkodNo,
                                   UyeAdi = u.Ad,
                                   UyeSoyadi = u.Soyad,
                                   Id = o.Id,
                                   UyeTcNo = u.TcNo,
                                   OduncAlmaTarihi = o.OduncAlmaTarihi,
                                   GeriVermeTarihi = o.GeriVermeTarihi
                               };
                return filter == null ? detaylar.ToList() : detaylar.Where(filter).ToList();
            }
        }
        public void Sil(Odunc odunc)
        {
            using (LibraryContext context = new LibraryContext())
            {
                var deletedEntity = context.Entry(odunc);
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Guncelle(Odunc odunc)
        {
            using (LibraryContext context = new LibraryContext())
            {
                var updatedEntity = context.Entry(odunc);
                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public Odunc Getir(Expression<Func<Odunc, bool>> filter)
        {
            using (LibraryContext context = new LibraryContext())
            {
              
                return context.Set<Odunc>().SingleOrDefault(filter);
            }
        }
    }
}
