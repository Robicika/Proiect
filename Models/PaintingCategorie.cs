using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class PaintingCategorie
    {
        public int ID { get; set; }
        public int PaintingID { get; set; }
        public Painting Painting { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
