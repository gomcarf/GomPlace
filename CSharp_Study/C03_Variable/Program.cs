using System;

namespace C03_Variable
{
    class Program
    {
        private static void Main(string[] args)
        {
            int a = 10; //4Byte => 2^32 -> 32bit, 부호 있음(Signed)
            int b = 20;
            int c = a + b;

            Console.WriteLine("a = " + a + ", b = " + b + ", c = " + c);
            Console.WriteLine($"a = {a}, b = {b}, c = {c}");//포맷 스트링(양식 문자열)



            float pi = 3.14f;
            Console.WriteLine("pi = " + pi);


            int f = (int)pi;
            Console.WriteLine("f = " + f);

            float i = (float)f;
            Console.WriteLine("i = " + i);
        }//Main
    }
}