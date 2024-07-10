using MyClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyData.Repository
{
    public class EntityCins : Ihelper<Cins>
    {
        private MyDbContext db;

        public EntityCins()
        {
                db= new MyDbContext();
        }
        public void Add(Cins table)
        {
           db.Cinsler.Add(table);
            db.SaveChanges();
        }

        public void delete(int Id)
        {
           var s=db.Cinsler.Find(Id);
            db.Cinsler.Remove(s);
            db.SaveChanges();
        }

        public void delete(string Id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int Id, Cins table)
        {
            db=new MyDbContext();
            db.Cinsler.Update(table);
            db.SaveChanges();
        }

        public void Edit(string Id, Cins table)
        {
            throw new NotImplementedException();
        }

        public Cins Find(int Id)
        {
            return db.Cinsler.Where(s => s.CinsId == Id).FirstOrDefault();
        }

        public Cins Find2(string Id)
        {
            throw new NotImplementedException();
        }

        public List<Cins> getAllData()
        {
           return db.Cinsler.ToList();
        }

        public List<Cins> getDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Cins> search(string searchItem)
        {
            throw new NotImplementedException();
        }
    }
}
