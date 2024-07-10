using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    public class Iliski
    {
        [Key]
        public int IliskiId { get; set; }

        [Required]
        [ForeignKey("Hayvan1")]
        public int Hayvan1Id { get; set; }

        [Required]
        [ForeignKey("Hayvan2")]
        public int Hayvan2Id { get; set; }

        [Required]
        public IliskiTur IliskiTuru { get; set; }

        // Navigation properties
        public virtual Hayvan Hayvan1 { get; set; }

        public virtual Hayvan Hayvan2 { get; set; }
    }

    public enum IliskiTur
    {
        Anne,
        Baba,
        Cocuk,
        Kardes,
        Diger
    }
}
