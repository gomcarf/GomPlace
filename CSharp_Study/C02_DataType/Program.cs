using System;

namespace C02_DataType
{
    class Program
    {
        private static void Main(string[] args)
        {
            byte a = 10; //0 ~ 255
            Console.WriteLine("a = " + a);
            
            unchecked
            {
                byte b = (byte)257; //Overflow
                Console.WriteLine("b = " + b);

                byte c = (byte)-1; //Underflow
                Console.WriteLine("c = " + c);
            }

             
            sbyte d = -10; //-128 ~ +127
            Console.WriteLine("d = " + d);

            unchecked
            {
                sbyte e = (sbyte)129; //Overflow
                Console.WriteLine("e = " + e);

                sbyte f = (sbyte)-129; //Underflow
                Console.WriteLine("f = " + f);
            }
        }//Main
    }
}