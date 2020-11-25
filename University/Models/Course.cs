using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Course
    {
        /*
         * 特性指定 PK【主键】 由应用程序提供而不是由数据库生成
         
         * 默认情况下，EF Core 假定 PK 值由数据库生成。 数据库生成通常是最佳方法。
         * Course实体的 PK 由用户指定。
         * 例如，对于课程编号，数学系可以使用 1000 系列的编号，英语系可以使用 2000 系列的编号。
         */
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }
        
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        
        [Range(0, 5)]
        public int Credits { get; set; }

        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        //参与一门课程的学生数量不定，因此 Enrollments 导航属性是一个集合
        public ICollection<Enrollment> Enrollments { get; set; }
        
        //一门课程可能由多位讲师讲授，因此 CourseAssignments 导航属性是一个集合
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}