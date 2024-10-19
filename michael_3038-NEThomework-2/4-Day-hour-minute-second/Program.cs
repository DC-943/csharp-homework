namespace _4_Day_hour_minute_second
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalSeconds = 107653;
            int days = totalSeconds / (3600 * 24);
            int daysRemainder = totalSeconds% (3600 * 24);
            int hours = daysRemainder / 3600;
            int remainSeconds = daysRemainder % 3600;
            int minutes = remainSeconds / 60;
            int minutesRemainder = minutes % 60;
            int seconds = minutesRemainder;
            Console.WriteLine($"{totalSeconds} is {days} days, {hours} hours, {minutes} minutes, {seconds} seconds");
        }
    }
}
