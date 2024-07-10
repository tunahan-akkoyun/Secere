using MyClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyData.Repository
{
	public class EntityUser : Ihelper<User>
	{
		private MyDbContext db;
        public EntityUser()
        {
			db = new MyDbContext();	
        }
        public void Add(User table)
		{
			db.User.Add(table);	
			db.SaveChanges();
		}

		public void delete(int Id)
		{
			var s = db.User.Find(Id);
			db.User.Remove(s);
			db.SaveChanges();
		}

		public void delete(string Id)
		{
			throw new NotImplementedException();
		}

		public void Edit(int Id, User table)
		{
			db=new MyDbContext();
			db.User.Update(table);
			db.SaveChanges();
		}

		public void Edit(string Id, User table)
		{
			throw new NotImplementedException();
		}

		public User Find(int Id)
		{
            throw new NotImplementedException();
        }

		public User Find2(string Id)
		{
            return db.User.Where(p => p.Id == Id).FirstOrDefault();
        }

		public List<User> getAllData()
		{
			return db.User.ToList();
		}

		public List<User> getDataByUser(string UserId)
		{
			throw new NotImplementedException();
		}

		public List<User> search(string searchItem)
		{
			throw new NotImplementedException();
		}
	}
}
