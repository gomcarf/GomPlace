namespace C05_ReadLine
{
    class Program
    {
        private static void Main(string[] args)
        {
            string a = "1234";
            string b = "4321";
            string c = a + b;
            Console.WriteLine($"{a} + {b} = {c}");

            int d = int.Parse(a);
            int e = int.Parse(b);
            int f = d + e;
            Console.WriteLine($"{d} + {e} = {f}");

            string g = "3.14";
            float h = float.Parse(g);
            Console.WriteLine($"g = {g}");


            Console.Write("정수 입력 : ");
            string? input = Console.ReadLine();
            int val = int.Parse(input);
            Console.WriteLine($"val = {val}");
        }//Main
    }
}