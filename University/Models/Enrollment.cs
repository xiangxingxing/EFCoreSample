using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    /*
     * 一份注册记录:面向一名学生所注册的一门课程
     */
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        /*
         * Student 和 Course 实体之间存在多对多关系。 Enrollment 实体充当数据库中“具有有效负载”的多对多联接表
         */
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}