using System.Xml.Serialization;

namespace _14_countMaxNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your first number:");
            string input1 = Console.ReadLine();
            int number1 = Convert.ToInt32(input1);
            Console.WriteLine("Enter your second number:");
            string input2 = Console.ReadLine();
            int number2 = Convert.ToInt32(input2);
            GetMaxNumber(number1, number2);
            Console.WriteLine("Hello, World!");
        }

        static int GetMaxNumber(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}
