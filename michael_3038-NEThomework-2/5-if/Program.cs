using System.Diagnostics.CodeAnalysis;

namespace _5_if
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = "admin";
            int password = 88888;            
            Console.WriteLine("please enter username:");
            string usernameInput = Console.ReadLine();
            if (usernameInput != username)
            {
                Console.WriteLine("usename does not exist!");
            }
            Console.WriteLine("please enter password:");
            string passwordInput = Console.ReadLine();
            int passwordEnter = Convert.ToInt32(passwordInput);

            if (usernameInput == username && passwordEnter != password)
            {
                Console.WriteLine("wrong password");

            }
         

            if (usernameInput == username && passwordEnter == password)
            {
               Console.WriteLine("log in successfully");
            }
        
                        


        }
    }
}
