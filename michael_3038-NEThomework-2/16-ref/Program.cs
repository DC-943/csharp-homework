namespace _16_ref
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
            Console.WriteLine("before swap {0} and {1}", number1, number2);
            SwapValue(ref number1, ref number2);
            Console.WriteLine("after swap {0} and {1}", number1, number2);
        }
        static void SwapValue(ref int a, ref int b)
        {
            int temp = 0;
            temp = a;
            a = b;
            b = temp;
        }
    }
}
