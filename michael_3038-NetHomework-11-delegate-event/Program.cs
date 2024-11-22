using System.Threading;
using System;

namespace michael_3038_delegate_event_NetHomework
{


    public delegate void CourseStarting();
    public delegate void HonourBonus();
    public delegate void EventHandler();
    public class TopOneStudent
    {
        public TopOneStudent(){}
        public void ReceiveBonus()
        {
            Console.WriteLine("Top one student receives his bonus");
        }
    }
    public class Course  //publisher
    {
        private string _courseName;
        //define an event

        public event EventHandler ScheduledTimeChanged;
        public Course(string courseName)
        {
            _courseName = courseName;
        }
        public void Update()
        {
             Console.WriteLine("Updating the course ........");
             Thread.Sleep(3000);
             ScheduledTimeChanged();
        }


    }
    public class Student
    {
        private string _stuName;

        private int _stuId;
       
        public Student(string stuName, int stuId){
            _stuName = stuName;
            _stuId = stuId;
        }
        public Student(string stuName, int stuId, Course course)
        {
            _stuName = stuName;
            _stuId = stuId;
        }

        public void start()
        {
            Console.WriteLine("The student ID: {0} with name {1} is starting the course", _stuId, _stuName);
        }
        public void JoinCourse( )
        {
            Console.WriteLine(" student ID: {0} with name {1} is joining the course", _stuId, _stuName);
        }
  
    }

    internal class Program
    {   
        static void Main(string[] args)
        {
            // one delegate
            TopOneStudent topOneStudent = new TopOneStudent();

            HonourBonus honourBonus = new HonourBonus(topOneStudent.ReceiveBonus);

            if (honourBonus != null)
            {
                honourBonus();
            }
            else
            {
                Console.WriteLine("The delegate honourBonus is empty");
            }
            Console.WriteLine();

            //multicast delegate
            Course csharpCourse = new Course("csharp");

            Student student1 = new Student("Jack Ma", 1, csharpCourse);
            Student student2 = new Student("Peter Dutton", 2, csharpCourse);
            Student student3 = new Student("Penny Wong", 3,csharpCourse);
            Student student4 = new Student("Donald Trump", 4, csharpCourse);
            Student student5 = new Student("Joe Biden", 5, csharpCourse);
            Student student6 = new Student("John Smith", 6, csharpCourse);

            CourseStarting courseStarting;

            courseStarting = student1.start;
            courseStarting += student2.start;
            courseStarting += student3.start;
            courseStarting = student4.start;
            courseStarting += student5.start;
            courseStarting += student6.start;

            if (courseStarting != null)
            {
                courseStarting();
            }
            else {
                Console.WriteLine("The delegate courseStarting is empty");
            }

            //events
            Student student7 = new Student("John Doe", 7, csharpCourse);
            Student student8 = new Student("Jane Doe", 8, csharpCourse);
            Student student9 = new Student("Jack Welsh", 9, csharpCourse);

            //some students joined the course
            csharpCourse.ScheduledTimeChanged += student1.JoinCourse;
            csharpCourse.ScheduledTimeChanged += student2.JoinCourse;
            csharpCourse.ScheduledTimeChanged += student3.JoinCourse;
            csharpCourse.ScheduledTimeChanged += student4.JoinCourse;
            csharpCourse.ScheduledTimeChanged += student5.JoinCourse;
            csharpCourse.ScheduledTimeChanged += student6.JoinCourse;
            Console.WriteLine();
            csharpCourse.Update();

            //some students quit
            csharpCourse.ScheduledTimeChanged -= student4.JoinCourse;
            csharpCourse.ScheduledTimeChanged -= student5.JoinCourse;
            csharpCourse.ScheduledTimeChanged -= student6.JoinCourse;
            Console.WriteLine();
            csharpCourse.Update();

            //new students joined the course
            csharpCourse.ScheduledTimeChanged += student7.JoinCourse;
            csharpCourse.ScheduledTimeChanged += student8.JoinCourse;
            csharpCourse.ScheduledTimeChanged += student9.JoinCourse;
            Console.WriteLine();
            csharpCourse.Update();


        }
    }
}
