﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace michael_3038_NETHomework_3
{
    internal class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public double[] StuScore;
        public int[] StuID;
        public Student[] StuInfo;
        public int CourseHours { get; set; }

        List<(int stuID, double stuScore)> idScoreTupleList = new List<(int, double)>();

        public void PrintTopThreeStuInfo()
        {
           
            if (StuScore==null && StuID==null && StuInfo==null)
            {
                return;
            }
            for (int i = 0; i < StuID.Length; i++)
            {
                idScoreTupleList.Add((StuID[i], StuScore[i]));
            }
            IEnumerable<(int, double)> orderedIdScoreTupleList = idScoreTupleList.OrderByDescending(tuple=>tuple.stuScore).Take(3).ToList();

            foreach (var stu in orderedIdScoreTupleList)
            {
                Console.WriteLine($"In course {CourseName}, top three students info are:");
                Console.WriteLine($"{StuInfo[stu.Item1 - 1]} Score:{stu.Item2}");
               
            }   
        }

        public void BubbleSort(double[] stuScore)
        {
            for (int i = 0; i < stuScore.Length - 1; i++)
            {
                for (int j = 0; j < stuScore.Length - 1 - i; j++)
                {
                    if (stuScore[j] > stuScore[j + 1])
                    {
                        double temp = stuScore[j];
                        stuScore[j] = stuScore[j + 1];
                        stuScore[j + 1] = temp;
                    }
                }
            }
        }
        public override string ToString()
        {
            return $"CourseId: {CourseID}, CourseName: {CourseName}, CourseHours:{CourseHours}";
        }

       

    }
}