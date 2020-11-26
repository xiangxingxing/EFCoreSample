using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models.SchoolViewModel;

namespace University.Pages.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly SchoolContext _context;

        public IndexModel(SchoolContext context)
        {
            _context = context;
        }

        public InstructorIndexData InstructorData;
        public int InstructorID { get; set; }
        public int CourseID { get; set; }
        
        public async Task OnGetAsync(int? id, int? courseID)
        {
            InstructorData = new InstructorIndexData
            {
                Instructors = await _context.Instructors
                    .Include(i => i.OfficeAssignment)
                    .Include(i => i.CourseAssignments)
                    .ThenInclude(i => i.Course)
                    .ThenInclude(i => i.Department)
                    //.AsNoTracking() //对于跟踪的实体，仅可显式加载导航属性
                    .OrderBy(i => i.LastName)
                    .ToListAsync()
            };

            if (id != null)
            {
                InstructorID = id.Value;
                var instructor = InstructorData.Instructors.Single(i => i.ID == InstructorID);
                InstructorData.Courses = instructor.CourseAssignments.Select(s => s.Course);
            }

            if (courseID != null)
            {
                CourseID = courseID.Value;
                var selectedCourse = InstructorData.Courses.Single(x => x.CourseID == courseID);
                //LoadAsync():通过显式加载指定要加载的导航属性。 使用 Load 方法进行显式加载
                await _context.Entry(selectedCourse).Collection(x => x.Enrollments).LoadAsync();
                foreach (var enrollment in selectedCourse.Enrollments)
                {
                    await _context.Entry(enrollment).Reference(x => x.Student).LoadAsync();
                }
                
                InstructorData.Enrollments = selectedCourse.Enrollments;
            }
        }
    }
}