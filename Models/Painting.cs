using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect.Models
{
    public class Painting
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]

        [Display(Name = "Titlu Pictura")]
        public string Titlu { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele autorului trebuie sa fie de forma 'Nume Prenume'"), Required, StringLength(50, MinimumLength = 3)]



        public string Autor { get; set; }

        [Range(1, 30000)]

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataPublicarii { get; set; }

        public int GalerieID { get; set; }
        public Galerie Galerie { get; set; }
        public ICollection<PaintingCategorie> PaintingCategories { get; set; }

    }
}
