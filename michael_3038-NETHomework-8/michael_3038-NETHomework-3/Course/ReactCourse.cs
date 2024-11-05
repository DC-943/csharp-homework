using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace michael_3038_NETHomework_3
{
    internal class ReactCourse : Course
    {   
        private string _courseName;
        private int _courseId;
        private int _courseHours;
        public ReactCourse(string coursename, int courseId, int courseHours)
        {
            _courseName = coursename;
            _courseId = courseId;
            _courseHours = courseHours;
        }

    }
}
