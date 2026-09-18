namespace C22_Reference
{
        class Program
    {
        private static void Multiply(int[] values)
        {
            for (int i = values.Length - 1; i >= 0; i--)
            {
                values[i] = values[i] * 10;
            }
        }

        private static void Test(ref int a)
        {
            a *= 10;
        }
        private static void Main(string[] args)
        {
            //값형식 : 정적할당
            //참조형식 : 동적할당(new)

            //int[] arr = new int[] { 1, 2, 3, 4, 5 };
            int[] arr = { 1, 2, 3, 4, 5 };
            Multiply(arr);

            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"arr[{i}] = {arr[i]}");
            }

            int r = new int(); //참조형식 x
            r = 1;
            Test(ref r);
            Console.WriteLine($"r = {r}");
        }//Main
    }
}