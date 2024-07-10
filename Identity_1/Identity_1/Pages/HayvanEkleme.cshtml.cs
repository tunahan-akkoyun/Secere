using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyData.Repository;
using MyClass;


namespace Identity_1.Pages
{
    public class HayvanEklemeModel : PageModel
    {
        private readonly Ihelper<MyClass.Tur> tur;
        private readonly Ihelper<MyClass.Cins> cins;

        public List<MyClass.Cins> MyList { get; set; }
        public List<MyClass.Tur> MyListTur { get; set; }
        public int ÝdTur { get; set; }
        public HayvanEklemeModel(Ihelper<MyClass.Tur> tur, Ihelper<MyClass.Cins> cins)
        {
            MyList = new List<MyClass.Cins>();
            MyListTur = new List<MyClass.Tur>();
            this.tur = tur;
            this.cins = cins;
        }
        public void OnGet(int id)
        {
            foreach (var item in cins.getAllData())
            {
                if (item.TurId == id)
                {
                    MyList.Add(item);
                }
            }
            ÝdTur = id;
        }
    }
}
