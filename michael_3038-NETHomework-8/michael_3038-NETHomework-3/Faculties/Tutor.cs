using michael_3038_NETHomework_3.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace michael_3038_NETHomework_3
{
    internal class Tutor : Faculty, IAssess
    {
        public override void PlanLearningActivities()
        {
            Console.WriteLine("The tutor is planning learning activities");
        }
        public override void Preparationlectures()
        {
            Console.WriteLine("The tutor is preparing lectures");
        }
        public override void DefineLearningObjectives(string courseObjective)
        {
            Console.WriteLine($"The tutor is defining learning an objective {courseObjective}");
        }
        public List<(int, string)> AssessStudentGrade(Student[] student)
        {

            Random rnd = new();
            string[] grades = ["A", "B","C","D","B", "C","A","D","B","A"];
            List<(int stuID, string stuScore)> stuIdScoreTupleList = new List<(int, string)>();
            Console.WriteLine("The tutor is assessing grades for students \n");

            for (int i = 0; i <student.Length; i++)
            {
                int gradeIndex = rnd.Next(grades.Length);
                Console.WriteLine($"Student name: {student[i].StuName}, ID: {student[i].StuID}, a grade is assessed as: {grades[gradeIndex]}");
                stuIdScoreTupleList.Add((student[i].StuID, grades[gradeIndex]));
            }

            return stuIdScoreTupleList;
        }

    }
}
