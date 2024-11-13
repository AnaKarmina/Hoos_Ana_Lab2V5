using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hoos_Ana_Lab2V5.Data;
using Hoos_Ana_Lab2V5.Models;
using Hoos_Ana_Lab2V5.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;


namespace Hoos_Ana_Lab2V5.Pages.Categories
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Hoos_Ana_Lab2V5.Data.Hoos_Ana_Lab2V5Context _context;

        public IndexModel(Hoos_Ana_Lab2V5.Data.Hoos_Ana_Lab2V5Context context)
        {
            _context = context;

        }

        public IList<Category> Category { get; set; } = default!;
        public CategoriesIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        
        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData= new CategoriesIndexData();
            CategoryData.Categories = await _context.Category
                .Include(i => i.BookCategories)
                .ThenInclude(i => i.Book)
                .ThenInclude (c => c.Author)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();

            if(id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories.Where(i => i.ID == id.Value).Single();
                CategoryData.Books = category.BookCategories.Select(bc => bc.Book);

            }
        }
    }
}
