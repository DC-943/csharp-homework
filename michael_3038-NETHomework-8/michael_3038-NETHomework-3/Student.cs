using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace michael_3038_NETHomework_3
{
    internal class Student
    {
        public int StuID { get; set;}
        public string StuName { get; set;}
        public int StuAge { get; set;}
        public Course[] CourseInfo;

        public Student(int stuID, string stuName, int stuAge, params Course[] courseID)
        {
            StuID = stuID;
            StuName = stuName;
            StuAge = stuAge;
            CourseInfo = courseID;
            
        }
        public override string ToString()
        {
            return $"Student ID: {StuID}, Student Name: {StuName}, Student Age: {StuAge}";
        }



    }
}
