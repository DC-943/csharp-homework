namespace _14_array_and_method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 4, 3, 9, 6, 8, 11 };


            Console.WriteLine(GetSum(nums));


        }

        static int GetSum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum = sum + array[i];
            }

            return sum;
        
        }
    }
}
