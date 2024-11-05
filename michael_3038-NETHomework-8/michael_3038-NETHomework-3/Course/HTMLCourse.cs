using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace michael_3038_NETHomework_3
{
    internal class HTMLCourse : Course
    {
        private string _courseName;
        private int _courseId;
        private int _courseHours;
        public HTMLCourse(string courseName, int courseId, int courseHours)
        {
            _courseName = courseName;
            _courseId = courseId;
            _courseHours = courseHours;
        }
    }
}
