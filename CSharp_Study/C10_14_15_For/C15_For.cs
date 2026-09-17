namespace C15_For3
{
    class Program
    {
        private static void Main(string[] args)
        {
            for(int i = 2; i <= 9; i++)
            {
                for(int j = 1; j <= 9; j++)
                {
                    int k = i * j;

                    Console.Write($"{i:00}*{j:00}={k:00}  ");
                }

                Console.WriteLine();
            }//for(i)
        }//Main
    }
}