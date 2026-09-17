namespace C07_Logical
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("정수 입력 : ");
            int a = int.Parse(Console.ReadLine()!);

            if(a > 5 && a < 10)
            {
                Console.WriteLine($"{a}는 5보다 크고 10보다 작음");
            }

            Console.WriteLine("프로그램 종료");
        }//Main
    }
}