using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioSuperHerois.Models
{
    public class HeroisSuperpoderes
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("HeroiId")]
        public int HeroiId { get; set; }
        public virtual Herois Herois { get; set; }

        [ForeignKey("SuperpoderId")]
        public int SuperpoderId { get; set; }
        public virtual Superpoderes Superpoderes { get; set; }

        

    }
}
