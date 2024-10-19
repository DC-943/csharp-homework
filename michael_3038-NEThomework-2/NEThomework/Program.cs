using Microsoft.VisualBasic.FileIO;
using System.Numerics;

namespace NEThomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Jack Ma";
            string gender = "male";
            int age = 18;
            int areaNumber = 010;
            //phone number should be string 
            string telephoneNumber = "12345";
            Console.WriteLine($"My name is {name}, I am {age} years old, I am {gender}, my phone is {areaNumber} - {telephoneNumber}");
        }
    }
}
