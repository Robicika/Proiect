using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Paintings
{
    public class CreateModel : PaintingCategoriesPageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public CreateModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["GalerieID"] = new SelectList(_context.Set<Galerie>(), "ID", "NumeGalerie");

            var painting = new Painting();
            painting.PaintingCategories = new List<PaintingCategorie>();
            PopulateAssignedCategoryData(_context, painting);
            return Page();
        }

        [BindProperty]
        public Painting Painting { get; set; }

        
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newPainting = new Painting();
            if (selectedCategories != null)
            {
                newPainting.PaintingCategories = new List<PaintingCategorie>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new PaintingCategorie
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newPainting.PaintingCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Painting>(
            newPainting,
            "Painting",
            i => i.Titlu, i => i.Autor,
            i => i.Pret, i => i.DataPublicarii, i => i.GalerieID))
            {
                _context.Painting.Add(newPainting);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newPainting);
            return Page();
        }

    }
}
