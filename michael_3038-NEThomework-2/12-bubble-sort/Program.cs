namespace _12_bubble_sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 4, 3, 9, 6, 8, 11 };

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = 0; j < nums.Length - 1 - i; j++)
                {
                    if (nums[j] > nums[j + 1]) 
                    {
                       
                        int temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                    }
                }
            }

          
            Console.WriteLine("after bubble sorting：");
            foreach (int num in nums)
            {
                Console.Write(num + " ");
            }


        
        }
    }
}
