using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class Galerie
    {
        public int ID { get; set; }
        public string NumeGalerie { get; set; }
        public ICollection<Painting> Paintings { get; set; }
    }
}
