namespace C19_Function3
{
    class Program
    {
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private static void Main(string[] args)
        {
            int e = 10, f = 20;
            
            Console.WriteLine($"e = {e}, f = {f}");
            Swap(ref e, ref f);
            Console.WriteLine($"e = {e}, f = {f}");
        }//Main
    }
}