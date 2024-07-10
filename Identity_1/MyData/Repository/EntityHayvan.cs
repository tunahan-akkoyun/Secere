using Microsoft.EntityFrameworkCore;
using MyClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyData.Repository
{
    public class EntityHayvan : Ihelper<Hayvan>
    {
        private MyDbContext _db;
        public EntityHayvan()
        {
            _db = new MyDbContext();
        }
        public void Add(Hayvan table)
        {
            _db.Hayvanlar.Add(table);
            _db.SaveChanges();
        }

        public void delete(int Id)
        {
            var hayvan = _db.Hayvanlar.Find(Id);
            if (hayvan != null)
            {
                _db.Hayvanlar.Remove(hayvan);
            }
            _db.SaveChanges();
        }

        public void delete(string Id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int Id, Hayvan table)
        {
            var existingHayvan = _db.Hayvanlar.Find(Id);

            if (existingHayvan != null)
            {
                existingHayvan.Isim = table.Isim;
                existingHayvan.Yas = table.Yas;

                _db.Entry(existingHayvan).State = EntityState.Modified;
                _db.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Belirtilen Id'ye sahip hayvan bulunamadı.");
            }
        }

        public void Edit(string Id, Hayvan table)
        {
            throw new NotImplementedException();
        }

        public Hayvan Find(int Id)
        {
            return _db.Hayvanlar.Find(Id);
        }

        public Hayvan Find2(string Id)
        {
            throw new NotImplementedException();
        }

        public List<Hayvan> getAllData()
        {
            return _db.Hayvanlar.Where(h => h != null).ToList();
        }

        public List<Hayvan> getDataByUser(string UserId)
        {
            throw new NotImplementedException();
            //int kullaniciId;
            //if (!int.TryParse(UserId, out kullaniciId))
            //{
            //    throw new ArgumentException("Geçersiz kullanıcı kimlik numarası.");
            //}

            //return _db.Hayvanlar
            //    .Where(h => h.SahipId == kullaniciId)
            //    .ToList();
        }

        public List<Hayvan> search(string searchItem)
        {
            string searchLower = searchItem.ToLower();

            return _db.Hayvanlar
                .Where(h =>
                    h.Isim.ToLower().Contains(searchLower) ||
                    h.TurId.ToString().Contains(searchItem) ||
                    h.CinsId.ToString().Contains(searchItem)
                )
                .ToList();
        }
    }
}
