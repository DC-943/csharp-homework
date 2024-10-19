namespace _11_chengfakoujue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 9; i++)  // 外层循环控制行数
            {
                for (int j = 1; j <= i; j++)  // 内层循环控制列数
                {
                    Console.Write("{0} * {1} = {2}\t", j, i, i * j);  // 格式化输出
                }
                Console.WriteLine();  // 每打印完一行后换行
            }
        }
    }
}
