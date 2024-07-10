using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyData.Repository
{
    public interface Ihelper<Table> where Table : class
    {
        //read
        List<Table> getAllData();
        List<Table> getDataByUser(string UserId);
        List<Table> search(string searchItem);
        Table Find(int Id);
        Table Find2(string Id);



        //write

        void Add(Table table);
        void Edit(int Id, Table table);
        void delete(int Id);



        void Edit(string Id, Table table);
        void delete(string Id);
    }
}
