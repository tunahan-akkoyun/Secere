using MyClass;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Identity_1.ModelV
{
    public class Hayvan
    {

        [Key]
        public int HayvanId { get; set; }
        public string? Isim { get; set; }
        public int? UserId { get; set; }
        public int? Yas { get; set; }
        public string? Cinsiyet { get; set; }
        public int? TurId { get; set; }
        public int? CinsId { get; set; }
        //public string userId { get; set; }

        public DateTime? DogumTarihi { get; set; }

        public DateTime? OlumTarihi { get; set; }


        public string? Resim1 { get; set; }
        public string? Resim2 { get; set; }
        public string? Resim3 { get; set; }


        public virtual ICollection<Asi> Asilar { get; set; }
        public virtual ICollection<Bakim> Bakimlar { get; set; }

        // Navigation Properties
        [ForeignKey("TurId")]
        public virtual Tur Tur { get; set; }
        [ForeignKey("CinsId")]
        public virtual Cins Cins { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }


    }
}
