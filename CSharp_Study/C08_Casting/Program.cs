namespace C08_Casting
{
    class Program
    {
        private static void Main(string[] args)
        {
            uint a = 4294967295; //4바이트 정수, 부호 없음(0 ~ 4,294,967,295)
            int b = (int)a;  //4바이트 정수, 부호 있음(-2,147,483,648 ~ 2,147,483,647)

            byte c = 10; //1바이트 정수, 부호없음(0 ~ 255)
            int d = c; //암시적 형변환
            int e = (int)c; //명시적 형변환

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(e);


            float pi = 3.14159268f;
            Console.WriteLine(pi);

            double f = pi;
            Console.WriteLine(f);

            float g = (float)f; //명시적 형변환
            Console.WriteLine(g);
        }//Main
    }
}