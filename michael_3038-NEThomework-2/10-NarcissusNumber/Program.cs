namespace _10_NarcissusNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hundred = 0;
            int ten = 0;
            int individual = 0;

            for (int i = 100; i <= 999; i++)
            {
                hundred = i / 100;
                ten = i % 100 / 10;
                individual = i % 100 % 10;
                if (hundred * hundred * hundred + ten * ten * ten + individual * individual * individual == i)
                {
                    Console.WriteLine(i+" is a narcissus number");
                }
            }
            Console.ReadKey();
        }
    }
}
