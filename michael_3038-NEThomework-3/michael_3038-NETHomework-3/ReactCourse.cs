using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace michael_3038_NETHomework_3
{
    internal class ReactCourse:Course
    {
        public ReactCourse(string coursename, int courseid, int coursehours)
        {
            this.CourseName = coursename;
            this.CourseID = courseid;
            this.CourseHours = coursehours;
        }
    }
}
