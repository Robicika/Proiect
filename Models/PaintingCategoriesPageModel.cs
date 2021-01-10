using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect.Data;


namespace Proiect.Models
{
    public class PaintingCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(ProiectContext context,
        Painting painting)
        {
            var allCategorii = context.Categorie;
            var paintingCategorie = new HashSet<int>(
            painting.PaintingCategories.Select(c => c.PaintingID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategorii)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.NumeCategorie,
                    Assigned = paintingCategorie.Contains(cat.ID)
                });
            }
        }
        public void UpdatePaintingCategorie(ProiectContext context,
        string[] selectedCategories, Painting paintingToUpdate)
        {
            if (selectedCategories == null)
            {
                paintingToUpdate.PaintingCategories = new List<PaintingCategorie>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var paintingCategorii = new HashSet<int>
            (paintingToUpdate.PaintingCategories.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!paintingCategorii.Contains(cat.ID))
                    {
                        paintingToUpdate.PaintingCategories.Add(
                        new PaintingCategorie
                        {
                            PaintingID = paintingToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (paintingCategorii.Contains(cat.ID))
                    {
                        PaintingCategorie courseToRemove
                        = paintingToUpdate
                        .PaintingCategories
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    

    }
}
