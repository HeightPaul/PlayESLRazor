using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlayESLRazor.Data;
using PlayESLRazor.Models;

namespace PlayESLRazor.Pages.Tournaments
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public PaginatedList<Tournament> Tournament { get; set; }
        public string TitleSort { get; set; }
        public string FormatSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title" : "";
            FormatSort = sortOrder == "player_format" ? "title" : "player_format";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Tournament> tournamentIQ = from t in _context.Tournament
                                                  select t;
            if (!String.IsNullOrEmpty(searchString))
            {
                tournamentIQ = tournamentIQ.Where(t => t.Title.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title":
                    tournamentIQ = tournamentIQ.OrderByDescending(t => t.Title);
                    break;
                case "player_format":
                    tournamentIQ = tournamentIQ.OrderBy(t => t.PlayerFormat);
                    break;
                default:
                    tournamentIQ = tournamentIQ.OrderBy(t => t.Title);
                    break;
            }

            int pageSize = 3;
            Tournament = await PaginatedList<Tournament>.CreateAsync(
                tournamentIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
