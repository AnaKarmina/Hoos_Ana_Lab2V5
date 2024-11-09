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
    public class DetailsModel : PageModel
    {
        private readonly Hoos_Ana_Lab2V5.Data.Hoos_Ana_Lab2V5Context _context;

        public DetailsModel(Hoos_Ana_Lab2V5.Data.Hoos_Ana_Lab2V5Context context)
        {
            _context = context;
        }

        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Borrowing = await _context.Borrowing
            .Include(b => b.Member)
            .Include(b => b.Book)
            .ThenInclude(b => b.Author)
            .FirstOrDefaultAsync(m => m.ID == id);

           // var borrowing = await _context.Borrowing.FirstOrDefaultAsync(m => m.ID == id);
            if (Borrowing == null)
            {
                return NotFound();
            }
            //else
            //{
            //    Borrowing = borrowing;
            //}
            return Page();
        }
    }
}
