using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace michael_3038_NETHomework_3
{
    internal abstract class Faculty
    {
        public List<string> Activities;

        public List<string> Lectures;

        public abstract void PlanLearningActivities();

        public abstract void Preparationlectures();

        public virtual void DefineLearningObjectives(string course)
        {

        }

    }
}
