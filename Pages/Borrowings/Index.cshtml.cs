using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hoos_Ana_Lab2V5.Data;
using Hoos_Ana_Lab2V5.Models;

namespace Hoos_Ana_Lab2V5.Pages.Borrowings
{
    public class IndexModel : PageModel
    {
        private readonly Hoos_Ana_Lab2V5.Data.Hoos_Ana_Lab2V5Context _context;

        public IndexModel(Hoos_Ana_Lab2V5.Data.Hoos_Ana_Lab2V5Context context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                .ThenInclude(b => b.Author)
                .Include(b => b.Member).ToListAsync();
        }
    }
}
