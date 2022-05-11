using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess
{
    public class KitapDuzenle
    {
        public void Ekle(Kitap kitap)
        {
            using (LibraryContext context = new LibraryContext())
            {
                var addedEntity = context.Entry(kitap);
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }
        public List<Kitap> Listele(Expression<Func<Kitap, bool>> filter = null)
        {
            using (LibraryContext context = new LibraryContext())
            {
                return filter == null ? context.Set<Kitap>().ToList() : context.Set<Kitap>().Where(filter).ToList();
            }
        }
        public void Sil(Kitap kitap)
        {
            using (LibraryContext context = new LibraryContext())
            {
                var deletedEntity = context.Entry(kitap);
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Guncelle(Kitap kitap)
        {
            using (LibraryContext context = new LibraryContext())
            {
                var updatedEntity = context.Entry(kitap);
                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public Kitap Getir(Expression<Func<Kitap, bool>> filter)
        {
            using (LibraryContext context = new LibraryContext())
            {
                return context.Set<Kitap>().SingleOrDefault(filter);
            }
        }
    }
}
