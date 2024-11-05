using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace michael_3038_NETHomework_3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<(int stuID, string stuScore)> stuIdScoreList = new List<(int, string)>();
            //create a C# course
            CSharpCourse csharpCourse = new CSharpCourse("CSharp", 1, 48);
                  
            //static polymorphism function overload
            csharpCourse.PrintCourse("CSharp");
            csharpCourse.PrintCourse("CSharp",2);
            csharpCourse.PrintCourse("CSharp",3,52);

            //Create a professor object, a tutor object, an instructor object
            Faculty facultyA= new Professor();
            Faculty facultyB = new Instructor();
            Faculty facultyC = new Tutor();
            Console.WriteLine();

            facultyA.PlanLearningActivities();
            facultyA.Preparationlectures();

            facultyB.PlanLearningActivities();
            facultyB.Preparationlectures();
     
            facultyC.PlanLearningActivities();
            facultyC.Preparationlectures();
            Console.WriteLine();

            //create ten students
            Student[] student = new Student[10] {
            new Student(1, "stuA", 22, csharpCourse),
            new Student(2, "stuB", 23, csharpCourse),
            new Student(3, "stuC", 24, csharpCourse),
            new Student(4, "stuD", 23, csharpCourse),
            new Student(5, "stuE", 22, csharpCourse),
            new Student(6, "stuF", 21, csharpCourse),
            new Student(7, "stuG", 20, csharpCourse),
            new Student(8, "stuH", 22, csharpCourse),
            new Student(9, "stuI", 23, csharpCourse),
            new Student(10, "stuJ", 24,csharpCourse)
            };

            //instructor notify students, tutor rates grades, professor refer A for a job
            Instructor instructor = (Instructor)facultyB;
            instructor.Notification(student);
            Console.WriteLine();

            Tutor tutor = (Tutor)facultyC;
            stuIdScoreList=tutor.AssessStudentGrade(student);
            Console.WriteLine();
 
            Professor professor = (Professor)facultyA;
            professor.ReferJob(stuIdScoreList);
         
        }
    }
}
