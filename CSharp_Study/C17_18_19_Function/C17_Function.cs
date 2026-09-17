namespace C17_Function
{
    class Program
    {
        private static void Print(int a, int b)
        {
            Console.WriteLine($"a = {a}, b = {b}");
        }

        private static void Swap(int x, int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        private static void Main(string[] args)
        {
            Print(10, 20);
            Print(20, 20);
            Print(50, 60);
            Print(100, 1);


            int c = 10, d = 20;
            Console.WriteLine($"c = {c}, d = {d}");

            int temp = c;
            c = d;
            d = temp;
            Console.WriteLine($"c = {c}, d = {d}");


            c = 30; d = 40;
            Console.WriteLine($"c = {c}, d = {d}");
            Swap(c, d);
            Console.WriteLine($"c = {c}, d = {d}");

        }//Main
    }
}