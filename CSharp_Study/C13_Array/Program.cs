namespace C13_Array
{
    class Program
    {
        private static void Main(string[] args)
        {
            int[] arr = new int[5];

            arr[0] = 11;
            arr[1] = 50;
            arr[2] = 20;
            arr[3] = 15;
            arr[4] = 5;

            for (int i = 0; i < 5; i++)
                Console.WriteLine($"arr[{i}] = {arr[i]}");

            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine($"arr[{i}] = {arr[i]}");


            Random random = new Random();

            for(int i = 0; i < 10; i++)
            {
                int rand = random.Next(1, 10);

                Console.WriteLine($"{i}번째 난수 : {rand}");
            }


            byte[] rands = new byte[10];
            random.NextBytes(rands);

            for (int i = 0; i < rands.Length; i++)
                Console.WriteLine($"배열 {i}번째 난수 : {rands[i]}");


            int[] arr2 = new int[] { 20, 5, 10, 30, 20 };
            for (int i = 0; i < arr2.Length; i++)
                Console.WriteLine($"arr2[{i}] = {arr2[i]}");
        }//Main
    }
}