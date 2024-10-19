using System.Xml.Serialization;

namespace _7_LeapYear
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter year:");
            string yearInput = Console.ReadLine();
            int year = Convert.ToInt32(yearInput);

            Console.WriteLine("Please enter month:");
            string monthInput = Console.ReadLine();
            int month = Convert.ToInt32(monthInput);

            if (month >= 1 && month <= 12)
            {
                int day = 0;
                switch (month)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        day = 31;
                        break;
                    case 2:
                        if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
                        {
                            day = 29;
                        }
                        else
                        {
                            day = 28;
                        }
                        break;
                    default:
                        day = 30;
                        break;

                }
                if (day == 29)
                    Console.WriteLine("This is a run year");
                else
                    Console.WriteLine("This is not a run year");
                Console.WriteLine("{0} year {1} month {2} days", year, month, day);


            }
            else
            {
                Console.WriteLine("input wrong days");
            }



        }
    }
}
