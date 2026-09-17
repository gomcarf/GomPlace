namespace C04_String
{
    class Program
    {
        private static void Main(string[] args)
        {
            char a = 'A';
            Console.WriteLine($"a = {a}");

            char b = '가';
            Console.WriteLine($"b = {b}");

            int c = (int)a;
            Console.WriteLine($"c = {c}");

            int d = (int)b;
            Console.WriteLine($"d = {d}");


            Console.Write("문자열 입력 : ");
            string? e = Console.ReadLine();
            Console.WriteLine($"입력한 문자열 : {e}");
        }//Main
    }
}