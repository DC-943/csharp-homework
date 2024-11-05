using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace michael_3038_NETHomework_3
{
    internal class Teacher
    {
        public int TeacherID;
        public string TeacherName;
        public Course[]  CourseInfo;
        public Student[] StuInfo;

        public Teacher(int teacherID, string name)
        {
            TeacherID = teacherID;
            TeacherName = name;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Teacher {TeacherName} teaches: ");
            foreach (Course course in CourseInfo)
            {
                Console.WriteLine(course);
            }
            Console.WriteLine("The students enrolled in this course are:");
            foreach (Student stu in StuInfo)
            {
                Console.WriteLine(stu);
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            return $"Course information is: {CourseInfo}, Student Information is: {StuInfo}";
        }


    }
}
