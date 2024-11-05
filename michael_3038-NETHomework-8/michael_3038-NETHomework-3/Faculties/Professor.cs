using michael_3038_NETHomework_3.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace michael_3038_NETHomework_3
{
    internal class Professor : Faculty, IRefer
    {
       private List<(int stuID, string stuScore)> _stuIdScoreList = new List<(int, string)>();
        public override void PlanLearningActivities()
        {
            Console.WriteLine("The professor is planning learning activities");
        }
        public override void Preparationlectures()
        {
            Console.WriteLine("The professor is preparing lectures");
        }
        public override void DefineLearningObjectives(string courseObjective)
        {
            Console.WriteLine($"The professor is defining learning an objective:{courseObjective}");
        }
        public void ReferJob(List<(int, string)> stuIdScoreList)
        {
            _stuIdScoreList = stuIdScoreList;
            Console.WriteLine("The professor only refers jobs for Grade A students with IDs as follows: \n");
            var stuIdGradeAList = _stuIdScoreList.Where(touple => touple.stuScore == "A").Select(touple => touple.stuID).ToList();
            foreach (var stuId in stuIdGradeAList)
            {
                Console.WriteLine($"Student ID: {stuId}");
            }

        }


    }
}
