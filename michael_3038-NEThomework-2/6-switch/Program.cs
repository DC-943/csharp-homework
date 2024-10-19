namespace _6_switch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter Lisi level:");
            string level = Console.ReadLine();
            int baseSalary = 5000;
            int newSalary;

            switch (level) {
                case "A":
                    newSalary = baseSalary + 500;
                    Console.WriteLine($"Salary is {newSalary}");
                    break;
                case "B":
                    newSalary = baseSalary + 200;
                    Console.WriteLine($"Salary is {newSalary}");
                    break;
                case "C":
                    newSalary = baseSalary;
                    Console.WriteLine($"Salary is {newSalary}");
                    break;
                case "D":
                    newSalary = baseSalary - 200;
                    Console.WriteLine($"Salary is {newSalary}");
                    break;
                case "E":
                    newSalary = baseSalary - 500;
                    Console.WriteLine($"Salary is {newSalary}");
                    break;
                default:
                    newSalary = baseSalary;
                    Console.WriteLine($"Salary is {newSalary}");
                    break;
            }
            
        }
    }
}
