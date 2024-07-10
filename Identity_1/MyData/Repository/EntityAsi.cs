using MyClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyData.Repository
{
    public class EntityAsi : Ihelper<Asi>
    {
        private MyDbContext db;

        public EntityAsi()
        {
            db = new MyDbContext();
        }
        public void Add(Asi table)
        {
            db.Asilar.Add(table);
            db.SaveChanges();
        }

        public void delete(int Id)
        {
            var s = db.Asilar.Find(Id);
            db.Asilar.Remove(s);
            db.SaveChanges();
        }

        public void delete(string Id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int Id, Asi table)
        {
            db = new MyDbContext();
            db.Asilar.Update(table);
            db.SaveChanges();
        }

        public void Edit(string Id, Asi table)
        {
            throw new NotImplementedException();
        }

        public Asi Find(int Id)
        {
            return db.Asilar.Where(s => s.AsiID == Id).FirstOrDefault();
        }

        public Asi Find2(string Id)
        {
            throw new NotImplementedException();
        }

        public List<Asi> getAllData()
        {
            return db.Asilar.ToList();
        }

        public List<Asi> getDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Asi> search(string searchItem)
        {
            throw new NotImplementedException();
        }
    }
}
