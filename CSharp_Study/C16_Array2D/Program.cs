namespace C16_Array2D
{
    class Program
    {
        private static void Main(string[] args)
        {
            int[,] a = new int[2, 3]
            {
                {1, 2, 3},
                {4, 5, 6},
            };

            for(int row = 0; row < a.GetLength(0); row++) //GetLength(0) - 행 갯수
            {
                for (int col = 0; col < a.GetLength(1); col++) //GetLength(1) - 열 갯수
                    Console.Write($"a[{row},{col}]={a[row, col]}  ");

                Console.WriteLine();
            }

            Console.WriteLine();


            int[][] arr = new int[3][];
            arr[0] = new int[2] { 1, 2 };
            arr[1] = new int[4] { 3, 4, 5, 6 };
            arr[2] = new int[3] { 7, 8, 9 };

            for(int row = 0; row < arr.Length; row++)
            {
                for(int col = 0; col < arr[row].Length; col++)
                {
                    Console.Write($"arr[{row}][{col}]={arr[row][col]}  ");
                }

                Console.WriteLine();
            }
        }//Main
    }
}