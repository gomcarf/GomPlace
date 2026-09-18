namespace C23_Factorial
{
    class Program
    {       
        private static int Factorial(int x)
        {
            int result = 0;
            Console.WriteLine($"시작 : x = {x}");

            if (x == 1)
                result = 1;
            else
                result = x * Factorial(x - 1);

            Console.WriteLine($"완료 : x = {x}, result = {result}");

                return result;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine($"최종 값 : {Factorial(4)}");
        }//Main
    }
}
/* 재귀 함수 : 본인 함수 내에서 본인 함수를 호출하는 것
 * 스택 : LIFO (Last In First Out)
 * F(2)
 * 2 * F(2-1)
 *     F(1)
 *     return  result = 1;
 */