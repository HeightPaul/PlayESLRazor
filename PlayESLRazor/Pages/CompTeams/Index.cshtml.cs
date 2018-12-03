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

namespace PlayESLRazor.Pages.CompTeams
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public PaginatedList<CompTeam> CompTeam { get; set; }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<CompTeam> compTeamIQ = from cT in _context.CompTeam
                                            select cT;
            if (!String.IsNullOrEmpty(searchString))
            {
                compTeamIQ = compTeamIQ.Where(c => c.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    compTeamIQ = compTeamIQ.OrderByDescending(c => c.Name);
                    break;
                case "Date":
                    compTeamIQ = compTeamIQ.OrderBy(c => c.EnrollmentDate);
                    break;
                case "date_desc":
                    compTeamIQ = compTeamIQ.OrderByDescending(c => c.EnrollmentDate);
                    break;
                default:
                    compTeamIQ = compTeamIQ.OrderBy(c => c.Name);
                    break;
            }

            int pageSize = 3;
            CompTeam = await PaginatedList<CompTeam>.CreateAsync(
                compTeamIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
