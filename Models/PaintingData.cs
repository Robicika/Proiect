using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class PaintingData
    {
        public IEnumerable<Painting> Paintings { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<PaintingCategorie> PaintingCategorii { get; set; }
    }
}
