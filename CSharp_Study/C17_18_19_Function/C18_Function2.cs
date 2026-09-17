namespace C18_Function2
{
    class Program
    {
        private static int Add(int a, int b)
        {
            int c = a + b;

            return c;
        }

        private static void Main(string[] args)
        {
            int e = 10, f = 20;
            int g = Add(e, f);

            Console.WriteLine($"g = {g}");
        }//Main
    }
}