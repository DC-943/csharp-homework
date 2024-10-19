namespace _9_do_while
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter student name!");
            string input = Console.ReadLine();

            do
            {
              Console.WriteLine("please enter student name!");
              input = Console.ReadLine();

            } while (input != "q");

            //string.Compare(name, "q", true);

            Console.WriteLine("quit do while loop");
        }
    }
}
