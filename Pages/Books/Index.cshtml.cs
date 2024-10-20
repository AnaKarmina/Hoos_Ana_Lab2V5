using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hoos_Ana_Lab2V5.Data;
using Hoos_Ana_Lab2V5.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hoos_Ana_Lab2V5.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Hoos_Ana_Lab2V5.Data.Hoos_Ana_Lab2V5Context _context;

        public IndexModel(Hoos_Ana_Lab2V5.Data.Hoos_Ana_Lab2V5Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;
        public SelectList AuthorsList { get; set; }
        public async Task OnGetAsync()
        {
           

            Book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .ToListAsync();
            
        }
    }
}
