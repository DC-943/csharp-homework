using System.Numerics;
using System.Threading.Channels;

namespace _3_Placeholder
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            
            int weekDays = 7;
            Console.WriteLine("please enter the number of days ");
            string input = Console.ReadLine();

            int days = Convert.ToInt32(input);

            int weekCount = days/weekDays;
           
            int remainder = days%weekDays;
          

            Console.WriteLine($"This is {weekCount} week, {remainder} days");
        }
    }
}
