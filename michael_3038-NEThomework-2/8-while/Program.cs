namespace _8_while
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int maxAttempts = 10;
            int attemptCount = 0;
            string response;
            Console.WriteLine("Did you get it yes means got it, no means did not get it");
            response = Console.ReadLine();
            Console.WriteLine();
            if (response == "yes")
            {
                Console.WriteLine("Great！You got it, class is dismissed");
            }
            while (response =="no")
            {
              
                attemptCount++;

                if (attemptCount >= maxAttempts)
                {
                    Console.WriteLine(" Already told you 10 times, we have to go");
                    break;
                }
                else
                {
                    Console.WriteLine("Please tell me one more time..");
                }

            } 


        }
    }
}
