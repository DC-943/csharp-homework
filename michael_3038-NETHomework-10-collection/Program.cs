
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace michael_3038_Collection_NETHomework_9
{
    internal class Program
    {
        class Student
        {
            public double score;
            public string name;
        }

        public static void Query(string[] queries)
        {

            Stack<char> undoStack = new Stack<char>();
            Stack<char> redoStack = new Stack<char>();

            foreach (var query in queries)
            {
                if (query.Contains("WRITE"))
                {
                    string[] subs = query.Split(' ');
                    char data = subs[1][0];
                    undoStack.Push(data);
                    continue;
                }
                switch (query)
                {
                    case "UNDO":
                        if (undoStack.Count > 0)
                        {
                            char undoChar = undoStack.Pop();
                            redoStack.Push(undoChar);
                        }
                        break;
                    case "REDO":
                        if (undoStack.Count > 0)
                        {

                            char redoChar = redoStack.Pop();

                            undoStack.Push(redoChar);
                        }
                        break;
                    case "READ":
                        if (undoStack.Count > 0)
                        {
                            Console.WriteLine(new string(undoStack.Reverse().ToArray()));
                        }
                        break;
                    default:
                        break;
                }

            }
        }

        static void Main(string[] args)
        {

            #region 1.print out the unique scores for each course, no duplicated scores printed out

            int[] csharpScore = [70, 80, 80, 90, 90, 95, 95, 96, 96, 99];
            int[] htmlScore = [75, 81, 81, 94, 94, 96, 96, 98, 98, 99];
            int[] reactScore = [85, 88, 88, 64, 64, 76, 76, 99, 99, 100];

            HashSet<int> csharpScoreHashSet = new HashSet<int>();
            HashSet<int> htmlScoreHashSet = new HashSet<int>();
            HashSet<int> reactScoreHashSet = new HashSet<int>();

            for (int i = 0; i < csharpScore.Length; i++)
            {
                csharpScoreHashSet.Add(csharpScore[i]);
            }
            for (int i = 0; i < htmlScore.Length; i++)
            {
                htmlScoreHashSet.Add(htmlScore[i]);
            }
            for (int i = 0; i < reactScore.Length; i++)
            {
                reactScoreHashSet.Add(reactScore[i]);
            }
            Console.Write("C# course, scores are: ");
            foreach (int s in csharpScoreHashSet)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
            Console.Write("HTML course, scores are: ");
            foreach (int s in htmlScoreHashSet)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
            Console.Write("React course, scores are: ");
            foreach (int s in reactScoreHashSet)
            {
                Console.Write(s + " ");
            }
            #endregion

            #region 2.select one collection type from HashTable/Dictionary/SortedList to store the scores for each course
            string[] StuName = ["John Smith", "John Doe", "Sarah Davis", "William Taylor", "Emma Wilson", "James Anderson"];
            string[] courseName = ["C#", "HTML", "React"];

            string[] csharpKey = new string[6];
            string[] htmlKey = new string[6];
            string[] reactKey = new string[6];

            int[] csharpScore1 = [70, 70, 90, 95, 96, 99];
            int[] htmlScore1 = [75, 81, 94, 96, 98, 99];
            int[] reactScore1 = [85, 88, 64, 76, 99, 100];

            Hashtable csharpTable = new Hashtable();
            Hashtable htmlTable = new Hashtable();
            Hashtable reactTable = new Hashtable();

            for (int i = 0; i < StuName.Length; i++)
            {
                csharpKey[i] = StuName[i] + " " + courseName[0];
                htmlKey[i] = StuName[i] + " " + courseName[1];
                reactKey[i] = StuName[i] + " " + courseName[2];
            }
            // same key cannot be added into hashTable, but same scores can be added
            Console.WriteLine("\n");
            for (int i = 0; i < StuName.Length; i++)
            {
                csharpTable.Add($"{csharpKey[i]}", csharpScore1[i]);
                htmlTable.Add($"{htmlKey[i]}", htmlScore1[i]);
                reactTable.Add($"{reactKey[i]}", reactScore1[i]);
            }

            Console.WriteLine();
            foreach (var s in csharpTable.Keys)
            {
                Console.WriteLine($"Key: {s}");
                Console.WriteLine($"Value: {csharpTable[s]}");
            }

            Console.WriteLine();
            foreach (var s in htmlTable.Keys)
            {
                Console.WriteLine($"Key: {s}");
                Console.WriteLine($"Value: {htmlTable[s]}");
            }

            Console.WriteLine();
            foreach (var s in reactTable.Keys)
            {
                Console.WriteLine($"Key: {s}");
                Console.WriteLine($"Value: {reactTable[s]}");
            }

            #endregion

            #region 3.Please use Lookup to represents a collection of keys each mapped to one or more values

            Console.WriteLine();

            List<Student> packages = new List<Student> { new Student {score = 80, name = "James Hush" },
                                                 new Student {score = 80, name = "Luck Linton" },
                                                 new Student {score = 80, name = "Jack Matt" },
                                                 new Student {score = 80, name = "Mike Lu" },
                                                 new Student {score = 80, name = "Jimmy Hugh" },
                                                 new Student {score = 90, name = "Penny Wong" },
                                                 new Student {score = 90, name = "Jack Ma" },
                                                 new Student {score = 90, name = "Donald Trump" },
                                                 new Student {score = 70, name = "Joe Biden" },
                                                 new Student {score = 70, name = "Kamala Harris"},
                                                 new Student {score = 70, name = "Peter Dutton"},
            };

            // Create a Lookup to organize the students. Use the student's score as the key value.
            // Select student names in the Lookup.
            Lookup<double, string> lookup = (Lookup<double, string>)packages.ToLookup(p => p.score,
                                                            p => p.name);

            // Iterate through each IGrouping in the Lookup and output the contents.
            foreach (IGrouping<double, string> studentGroup in lookup)
            {
                Console.WriteLine();
                Console.Write(studentGroup.Key + ":" + " ");
                foreach (string str in studentGroup)
                {
                    Console.Write($"{str}" + "," + " ");
                }
            }
            Console.WriteLine();
            #endregion

            #region 4.Implement Undo and Redo features
            Console.WriteLine();
            string[] Q = { "WRITE A", "WRITE B", "WRITE C", "UNDO", "READ", "REDO", "READ" };
            Console.WriteLine("Output for Q:");
            Query(Q);
            #endregion


        }



    }
}
