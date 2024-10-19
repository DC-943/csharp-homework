namespace _15_out_method
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string username = "admin";
            string password = "123456";


            Console.Write("Please enter username: ");
            string usernameInput = Console.ReadLine();
            string passwordInput = Console.ReadLine();

            Console.Write("Please enter password ");
            string passwordInput = Console.ReadLine();

            string result;
            string message;

            ValidateLogin(usernameInput, passwordInput, username, password, out result, out message);


            Console.WriteLine($"{result} and {message}");

        }

        // 方法：验证用户名和密码
        static void ValidateLogin(string username, string password, string usernameInput, string passwordInput, out string loginResult, out string message)
        {
            if (usernameInput == username && passwordInput == password)
            {
                loginResult = "Log in successful";
                message = "Welcome to the website!";

            }
            else if (passwordInput != password)
            {
                loginResult = "Log in failed";
                message = "wrong password";
            }
            else
            {
                loginResult = "Log in failed";
                message = "wrong user name";
            }

        }


    }
}
