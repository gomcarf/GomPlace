namespace C10_For
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("정수 입력 : ");
            int count = int.Parse(Console.ReadLine()!);

            int sum = 0; //지역 변수
            for (int i = 1; i <= count; i += 2)
            {
                if (i > 10)
                    break;

                if (i == 5)
                    continue;

                //sum = sum + i;
                sum += i;

                Console.WriteLine(i);
            }
            Console.WriteLine($"합계 : {sum}");


            int k = 0;
            for(; ; )
            {
                k++;

                if (k > 100)
                    break;

                Console.WriteLine($"k = {k}");
            }
        }//Main
    }
}