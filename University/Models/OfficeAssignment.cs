using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class OfficeAssignment
    {
        //[Key] 特性用于在属性名不是 classnameID 或 ID 时将属性标识为主键 (PK)
        [Key] 
        public int InstructorID { get; set; }

        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        //导航属性将始终具有一个 Instructor 实体
        //因为:外键InstructorID 类型为 int，不可为 null 的值类型。
        //没有讲师则不可能存在办公室分配
        public Instructor Instructor { get; set; }
    }
}