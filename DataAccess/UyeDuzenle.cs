using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess
{
    public class UyeDuzenle
    {
        public void Ekle(Uye uye)
        {
            using (LibraryContext context = new LibraryContext())
            {
                var addedEntity = context.Entry(uye);
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }
        public List<Uye> Listele(Expression<Func<Uye, bool>> filter = null)
        {
            using (LibraryContext context = new LibraryContext())
            {
                return filter == null ? context.Set<Uye>().ToList() : context.Set<Uye>().Where(filter).ToList();
            }
        }
        public void Sil(Uye uye)
        {
            using (LibraryContext context = new LibraryContext())
            {
                var deletedEntity = context.Entry(uye);
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Guncelle(Uye uye)
        {
            using (LibraryContext context = new LibraryContext())
            {
                var updatedEntity = context.Entry(uye);
                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public Uye Getir(Expression<Func<Uye, bool>> filter)
        {
            using (LibraryContext context = new LibraryContext())
            {
                return context.Set<Uye>().FirstOrDefault(filter);
            }
        }
    }
}
