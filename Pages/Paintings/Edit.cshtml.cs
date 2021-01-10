using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Paintings
{
    public class EditModel : PaintingCategoriesPageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public EditModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Painting Painting { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Painting = await _context.Painting
 .Include(b => b.Galerie)
 .Include(b => b.PaintingCategories).ThenInclude(b => b.Categorie)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);

            if (Painting == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Painting);

            ViewData["GalerieID"] = new SelectList(_context.Set<Galerie>(), "ID", "NumeGalerie");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var paintingToUpdate = await _context.Painting
            .Include(i => i.Galerie)
            .Include(i => i.PaintingCategories)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (paintingToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Painting>(
            paintingToUpdate,
            "Painting",
            i => i.Titlu, i => i.Autor,
            i => i.Pret, i => i.DataPublicarii, i => i.Galerie))
            {
                UpdatePaintingCategorie(_context, selectedCategories, paintingToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            
            UpdatePaintingCategorie(_context, selectedCategories, paintingToUpdate);
            PopulateAssignedCategoryData(_context, paintingToUpdate);
            return Page();
        }
    }
}

