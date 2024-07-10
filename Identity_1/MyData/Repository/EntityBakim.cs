using MyClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyData.Repository
{
    public class EntityBakim : Ihelper<Bakim>
    {
        private MyDbContext db;

        public EntityBakim()
        {
            db = new MyDbContext();
        }
        public void Add(Bakim table)
        {
            db.Bakimlar.Add(table);
            db.SaveChanges();
        }

        public void delete(int Id)
        {
            var s = db.Bakimlar.Find(Id);
            db.Bakimlar.Remove(s);
            db.SaveChanges();
        }

        public void delete(string Id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int Id, Bakim table)
        {
            db = new MyDbContext();
            db.Bakimlar.Update(table);
            db.SaveChanges();
        }

        public void Edit(string Id, Bakim table)
        {
            throw new NotImplementedException();
        }

        public Bakim Find(int Id)
        {
            return db.Bakimlar.Where(s => s.BakimID == Id).FirstOrDefault();
        }

        public Bakim Find2(string Id)
        {
            throw new NotImplementedException();
        }

        public List<Bakim> getAllData()
        {
            return db.Bakimlar.ToList();
        }

        public List<Bakim> getDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Bakim> search(string searchItem)
        {
            throw new NotImplementedException();
        }
    }
}
