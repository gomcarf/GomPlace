namespace C06_IF
{
    class Program
    {
        private static void Main(string[] args)
        {
            //int a = 4;

            Console.Write("정수 입력 : ");
            int a = int.Parse(Console.ReadLine()!);

            bool b = a > 5;
            if (b)
            {
                Console.WriteLine("a는 5보다 큼");
            }
            else if(a > 3)
            {
                Console.WriteLine("a는 3보다 큼");
            }
            else
            {
                Console.WriteLine("a는 3보다 작음");
            }

            Console.WriteLine("프로그램 종료");
        }//Main
    }
}