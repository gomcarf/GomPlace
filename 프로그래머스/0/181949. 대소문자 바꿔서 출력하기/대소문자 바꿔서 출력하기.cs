using System;

public class Example
{
    public static void Main()
    {
        string s;

        s = Console.ReadLine();
        
        
        foreach(char c in s)
        {
            if(char.IsUpper(c))
                Console.Write(char.ToLower(c));
            else
                Console.Write(char.ToUpper(c));
        }

    }
}