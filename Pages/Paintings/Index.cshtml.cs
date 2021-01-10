using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Paintings
{
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public IndexModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<Painting> Painting { get; set; }

        public PaintingData PaintingD { get; set; }
        public int PaintingID { get; set; }
        public int CategorieID { get; set; }
        public async Task OnGetAsync(int? id, int? categorieID)
        {
            PaintingD = new PaintingData();

            PaintingD.Paintings = await _context.Painting
            .Include(b => b.Galerie)
            .Include(b => b.PaintingCategories)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Titlu)
            .ToListAsync();
            if (id != null)
            {
                PaintingID = id.Value;
                Painting painting = PaintingD.Paintings
                .Where(i => i.ID == id.Value).Single();
                PaintingD.Categorii = painting.PaintingCategories.Select(s => s.Categorie);
            }
        }

    }
}
