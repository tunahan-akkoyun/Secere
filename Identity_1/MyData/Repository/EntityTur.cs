using MyClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyData.Repository
{
    public class EntityTur : Ihelper<Tur>
    {
        private MyDbContext db;
        public EntityTur()
        {
                db = new MyDbContext();
        }
        public void Add(Tur table)
        {
         db.Add(table);
            db.SaveChanges();
        }

        public void delete(int Id)
        {
            var s = db.Turler.Find(Id);
           db.Turler.Remove(s);
            db.SaveChanges();
        }

        public void delete(string Id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int Id, Tur table)
        {
         
            db=new MyDbContext();
            db.Turler.Update(table);
            db.SaveChanges();

        }

        public void Edit(string Id, Tur table)
        {
            throw new NotImplementedException();
        }

        public Tur? Find(int Id)
        {
            return db.Turler.Where(s => s.TurId == Id).FirstOrDefault();
        }

        public Tur Find2(string Id)
        {
            throw new NotImplementedException();
        }

        public List<Tur> getAllData()
        {
            return db.Turler.ToList();
        }

        public List<Tur> getDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Tur> search(string searchItem)
        {
            throw new NotImplementedException();
        }
    }
}
