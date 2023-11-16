using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioSuperHerois.Models
{
    public class Superpoderes
    {
        [Key] 
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Superpoder { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string? Descricao { get; set; }

        public ICollection<HeroisSuperpoderes> HeroisSuperpoderes { get; set; }
    }
}
