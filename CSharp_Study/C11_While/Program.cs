namespace C11_While
{
    class Program
    {
        private static void Main(string[] args)
        {
            int a = 1;

            int b = ++a;
            Console.WriteLine($"a = {a}, b = {b}"); //a = 2, b = 2

            int c = a++;
            Console.WriteLine($"a = {a}, c = {c}"); //a = 3, c = 2

            int d = --a;
            Console.WriteLine($"a = {a}, d = {d}"); //a = 2, d = 2

            int e = a--;
            Console.WriteLine($"a = {a}, e = {e}"); //a = 1, e = 2


            int i = 0;
            while(i < 5)
            {
                Console.WriteLine($"i = {i}");

                i++;
            }


            i = 5;
            while (i < 5)
            {
                i++;
                Console.WriteLine($"while = {i}");
            }

            i = 5;
            do
            {
                i++;
                Console.WriteLine($"do-while = {i}");
            }
            while (i < 5);
        }//Main
    }
}