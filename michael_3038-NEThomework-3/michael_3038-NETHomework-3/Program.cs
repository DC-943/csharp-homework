using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace michael_3038_NETHomework_3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region 3.1
            Course[] course = new Course[3] {
            new CSharpCourse("CSharp", 1, 48),
            new HTMLCourse("HTML", 2, 48),
            new ReactCourse("React", 3, 48)
            };

            Teacher[] teacher = new Teacher[3] {
            new Teacher(1,"A"),
            new Teacher(2, "B"),
            new Teacher(3, "C")
            };

            Student[] student = new Student[10] {
            new Student(1, "a", 22, course[0]),
            new Student(2, "b", 23, course[0]),
            new Student(3, "c", 24, course[0]),
            new Student(4, "d", 23, course[1]),
            new Student(5, "e", 24, course[1]),
            new Student(6, "f", 25, course[2]),
            new Student(7, "g", 21, course[2]),
            new Student(8, "h", 23, course[2]),
            new Student(9, "i", 22, course[2]),
            new Student(10, "j", 25, course[2])
            };
            #endregion

            #region 3.2  
            teacher[0].CourseInfo = [course[0]];
            teacher[1].CourseInfo = [course[1]];
            teacher[2].CourseInfo = [course[2]];

            teacher[0].StuInfo = [student[0], student[1], student[2]];
            teacher[1].StuInfo = [student[3], student[4]];
            teacher[2].StuInfo = [student[5], student[6], student[7], student[8], student[9]];

            course[0].StuID = [1, 2, 3];
            course[1].StuID = [4, 5];
            course[2].StuID = [6, 7, 8, 9, 10];

            course[0].StuInfo = student;
            course[1].StuInfo = student;
            course[2].StuInfo = student;

            course[0].StuScore = [60.6, 95.5, 80.8];
            course[1].StuScore = [77, 79];
            course[2].StuScore = [88, 77, 66, 65, 60];


            #endregion

            #region 3.3
            teacher[0].PrintInfo();
            Console.WriteLine();
            teacher[1].PrintInfo();
            Console.WriteLine();
            teacher[2].PrintInfo();
            Console.WriteLine();
            #endregion

            #region 3.4
            course[0].PrintTopThreeStuInfo();
            Console.WriteLine();
            course[1].PrintTopThreeStuInfo();
            Console.WriteLine();
            course[2].PrintTopThreeStuInfo();
            Console.WriteLine();
            #endregion



        }
    }
}
