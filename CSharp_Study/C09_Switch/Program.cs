namespace C09_Switch
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("비교할 정수 : ");
            int a = int.Parse(Console.ReadLine()!);

            Console.Write("첫번째 정수 : ");
            int b = int.Parse(Console.ReadLine()!);

            Console.Write("두번째 정수 : ");
            int c = int.Parse(Console.ReadLine()!);

            int d = (a > 5) ? b : c;
            Console.WriteLine($"d = {d}");


            if (a == 5)
                Console.WriteLine("a == 5");
            else if (a == 6)
                Console.WriteLine("a == 6");
            else if (a == 7)
                Console.WriteLine("a == 7");
            else if (a == 8)
                Console.WriteLine("a == 8");
            else
                Console.WriteLine("맞는 조건 없음");

            switch(a)
            {
                case 5: Console.WriteLine("a == 5"); break;
                case 6: Console.WriteLine("a == 6"); break;
                case 7: Console.WriteLine("a == 7"); break;
                case 8: Console.WriteLine("a == 8"); break;
                default: Console.WriteLine("맞는 조건 없음"); break;
            }
        }//Main
    }
}