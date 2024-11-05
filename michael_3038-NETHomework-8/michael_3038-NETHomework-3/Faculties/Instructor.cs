using michael_3038_NETHomework_3.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace michael_3038_NETHomework_3
{
    internal class Instructor : Faculty, INotify
    {
        public override void PlanLearningActivities()
        {
          Console.WriteLine("The instructor is planning learning activities");
        }
        public override void Preparationlectures()
        {
          Console.WriteLine("The instructor is preparing lectures");
        }
        public override void DefineLearningObjectives(string courseObjective)
        {
          Console.WriteLine($"The instructor is defining an objective:{courseObjective}");
        }
        public void Notification(Student[] student)
        {
          Console.WriteLine("The instructor is notifying students for classes \n");
            for (int i = 0; i <student.Length; i++)
            {
                Console.WriteLine($"student {student[i].StuName} is attending the class");
            }
        }
    }
}
