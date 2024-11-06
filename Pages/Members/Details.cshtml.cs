using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hoos_Ana_Lab2V5.Data;
using Hoos_Ana_Lab2V5.Models;

namespace Hoos_Ana_Lab2V5.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly Hoos_Ana_Lab2V5.Data.Hoos_Ana_Lab2V5Context _context;

        public DetailsModel(Hoos_Ana_Lab2V5.Data.Hoos_Ana_Lab2V5Context context)
        {
            _context = context;
        }

        public Member Member { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.ID == id);
            if (member == null)
            {
                return NotFound();
            }
            else
            {
                Member = member;
            }
            return Page();
        }
    }
}
