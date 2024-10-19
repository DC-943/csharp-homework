
using System;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

//reference link1:https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.contains?view=net-8.0
//reference link2:https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.contains?view=net-8.0
//test data: 5  zhangsan 50 math, wangwu 40 English, lisi 30 music, zhangsan 35 math, Jack  20 PE


namespace NEThomework_michael_3038
{
    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }

        public Student(string stuName, int stuAge, string stuCourse)
        {
            Name = stuName;
            Age = stuAge;
            Course = stuCourse;
            Console.WriteLine($"create student, the name is: {Name}, the age is: {Age}, the course is: {Course}");
        }

        public int CompareTo(Student comparePart)
        {
            if (comparePart == null)
            {
                return 1;
            }
            else {
                return this.Age.CompareTo(comparePart.Age);
                }   
        }

        public int SortByAgeAscending(int age1, int age2)
        {
            return age1.CompareTo(age2);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Course:{Course}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the student number: ");

            int stuNum = int.Parse(Console.ReadLine());

            List<Student> stuList = new List<Student>();

            for (int i = 0; i < stuNum; i++)
            {
               string stuName = Console.ReadLine();
               if (stuName.Length < 2 || stuName.Length > 10)
               {
                   Console.WriteLine("please enter a valid name over 5 characters or less than 10 characters");
                   break;
               }
               int stuAge = int.Parse(Console.ReadLine());
               if (stuAge < 18 || stuAge > 60)
               {
                  Console.WriteLine("please enter a valid age between 18 and 60");
                  break;
               }
               string stuCourse = Console.ReadLine();
               Student student = new Student(stuName, stuAge, stuCourse);
               stuList.Add(student);
            }

            Console.WriteLine("################## before sorting ##################");

            foreach (Student stu in stuList)
            {
                Console.WriteLine($"before sort get student {stu}");
            }
            stuList.Sort();

            Console.WriteLine("################## after sorting ##################");

            foreach (Student stu in stuList)
            {
                Console.WriteLine($"after sort get student {stu}");
            }

            Console.WriteLine("Please enter the student name to search:  ");

            string stuNameSearch = Console.ReadLine();

            int nameCount = 0;

            foreach (Student stu in stuList)
            {
                Console.WriteLine($"Verify s1 {stu.Name} and s2 {stuNameSearch}");
                var result = stu.Name.Contains(stuNameSearch);
                Console.WriteLine($"Verify s1 = s2 {result}");

                if (result)
                {
                    nameCount++;
                    if (nameCount >= 2)
                    {
                        Console.WriteLine($"There is one student with same name: {stu.Name} {stu.Age} {stu.Course} ");
                    }
                }
                 
            }
            if(nameCount!=2)
            {
              Console.WriteLine("Not Exist");
            }


        }
    }
}
