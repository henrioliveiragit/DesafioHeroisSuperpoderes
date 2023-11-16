using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioSuperHerois.Models
{
    public class Herois
    {
        [Key] 
        public int Id { get; set; } 
        [Column(TypeName = "varchar(120)")]
        public string Nome { get; set; }
        [Column(TypeName = "varchar(120)")]
        public string NomeHeroi { get; set; }
        public DateTime? DataNascimento { get; set; } 
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }

        public ICollection<HeroisSuperpoderes> HeroisSuperpoderes { get; set; }
    }
}
