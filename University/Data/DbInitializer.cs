using System;
using System.Linq;
using University.Models;

namespace University.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            var ensureCreated = context.Database.EnsureCreated();
            Console.WriteLine($"ensureCreated = {ensureCreated}");

            // Look for any students.
            if (context.Students.Any())
            {
                return; // DB has been seeded
            }

            var students = new[]
            {
                new Student
                {
                    FirstMidName = "卡尔森", LastName = "阿列克斯",
                    EnrollmentDate = DateTime.Parse("2016-09-01")
                },
                new Student
                {
                    FirstMidName = "莫雷蒂斯", LastName = "阿洛索",
                    EnrollmentDate = DateTime.Parse("2018-09-01")
                },
                new Student
                {
                    FirstMidName = "阿特若", LastName = "安德",
                    EnrollmentDate = DateTime.Parse("2019-09-01")
                },
                new Student
                {
                    FirstMidName = "库里", LastName = "斯蒂芬",
                    EnrollmentDate = DateTime.Parse("2018-09-01")
                },
                new Student
                {
                    FirstMidName = "勒布朗", LastName = "詹姆斯",
                    EnrollmentDate = DateTime.Parse("2018-09-01")
                },
                new Student
                {
                    FirstMidName = "佩奇", LastName = "玖迪斯",
                    EnrollmentDate = DateTime.Parse("2017-09-01")
                },
                new Student
                {
                    FirstMidName = "洛瑞", LastName = "罗马",
                    EnrollmentDate = DateTime.Parse("2019-09-01")
                },
                new Student
                {
                    FirstMidName = "尼奥", LastName = "欧力文拖",
                    EnrollmentDate = DateTime.Parse("2011-09-01")
                }
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course {CourseID = 1050, Title = "Chemistry", Credits = 3},
                new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3},
                new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3},
                new Course {CourseID = 1045, Title = "Calculus", Credits = 4},
                new Course {CourseID = 3141, Title = "Trigonometry", Credits = 4},
                new Course {CourseID = 2021, Title = "Composition", Credits = 3},
                new Course {CourseID = 2042, Title = "Literature", Credits = 4}
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {StudentID = 1, CourseID = 1050, Grade = Grade.A},
                new Enrollment {StudentID = 1, CourseID = 4022, Grade = Grade.C},
                new Enrollment {StudentID = 1, CourseID = 4041, Grade = Grade.B},
                new Enrollment {StudentID = 2, CourseID = 1045, Grade = Grade.B},
                new Enrollment {StudentID = 2, CourseID = 3141, Grade = Grade.F},
                new Enrollment {StudentID = 2, CourseID = 2021, Grade = Grade.F},
                new Enrollment {StudentID = 3, CourseID = 1050},
                new Enrollment {StudentID = 4, CourseID = 1050},
                new Enrollment {StudentID = 4, CourseID = 4022, Grade = Grade.F},
                new Enrollment {StudentID = 5, CourseID = 4041, Grade = Grade.C},
                new Enrollment {StudentID = 6, CourseID = 1045},
                new Enrollment {StudentID = 7, CourseID = 3141, Grade = Grade.A},
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}