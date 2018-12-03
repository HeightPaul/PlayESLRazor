using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlayESLRazor.Data;
using PlayESLRazor.Models;

namespace PlayESLRazor.Pages.CompTeams
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CompTeam CompTeam { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyCompTeam = new CompTeam();

            if (await TryUpdateModelAsync<CompTeam>(
                emptyCompTeam,
                "compTeam",   // Prefix for form value.
                cT => cT.Name,
                cT => cT.EnrollmentDate))
            {
                _context.CompTeam.Add(CompTeam);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return null;

            //if (!ModelState.IsValid) old code
            //{
            //    return Page();
            //}

            //_context.CompTeam.Add(CompTeam);
            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");
        }
    }
}