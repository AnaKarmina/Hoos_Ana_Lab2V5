﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hoos_Ana_Lab2V5.Data;
using Hoos_Ana_Lab2V5.Models;

namespace Hoos_Ana_Lab2V5.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Hoos_Ana_Lab2V5.Data.Hoos_Ana_Lab2V5Context _context;

        public CreateModel(Hoos_Ana_Lab2V5.Data.Hoos_Ana_Lab2V5Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}