using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models.SchoolViewModel;

namespace University.Pages
{
    public class AboutModel : PageModel
    {
        private readonly SchoolContext _context;

        public AboutModel(SchoolContext context)
        {
            _context = context;
        }
        
        public IList<EnrollmentDateGroup> Students { get; set; }
        
        public string DateSort { get; set; }
        
        public async Task OnGetAsync(string sortOrder)
        {
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            IQueryable<EnrollmentDateGroup> dataIQuery =
                from student in _context.Students
                group student by student.EnrollmentDate
                into dateGroup
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                };

            switch (sortOrder)
            {
                case "Date":
                    dataIQuery = dataIQuery.OrderBy(d => d.EnrollmentDate);
                    break;
                case "date_desc":
                    dataIQuery = dataIQuery.OrderByDescending(s => s.EnrollmentDate);
                    break;
            }

            Students = await dataIQuery.AsNoTracking().ToListAsync();
        }
    }
}