using MyClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyData.Repository
{
    public class EntityIliski : Ihelper<Iliski>
    {
        private MyDbContext db;
        public EntityIliski()
        {
            db = new MyDbContext();
        }
        public void Add(Iliski table)
        {
            db.Add(table);
            db.SaveChanges();
        }

        public void delete(int Id)
        {
            var s = db.Iliskiler.Find(Id);
            db.Iliskiler.Remove(s);
            db.SaveChanges();
        }

        public void delete(string Id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int Id, Iliski table)
        {
            db = new MyDbContext();
            db.Iliskiler.Update(table);
            db.SaveChanges();
        }

        public void Edit(string Id, Iliski table)
        {
            throw new NotImplementedException();
        }

        public Iliski? Find(int Id)
        {
            return db.Iliskiler.Where(s => s.IliskiId == Id).FirstOrDefault();
        }

        public Iliski Find2(string Id)
        {
            throw new NotImplementedException();
        }

        public List<Iliski> getAllData()
        {
            return db.Iliskiler.ToList();
        }

        public List<Iliski> getDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Iliski> search(string searchItem)
        {
            throw new NotImplementedException();
        }
    }
}
