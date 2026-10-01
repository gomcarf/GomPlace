using System.Collections.Generic;
using System.Runtime.InteropServices;

class User
{
    public const int MaxSize = 10; //초기화 시점에 값이 정해지며, 변경 불가
    public readonly int MaxSize2;
    public readonly int MaxSize3;

    public User()
    {
        MaxSize2 = 20; //생성자에서 초기화 가능, 이후로는 변경 불가
    }

    public User(int maxSize3)
    {
        MaxSize3 = maxSize3; //생성자에서 초기화 가능, 이후로는 변경 불가
    }
}

class Program
{
    //private static void Swap(ref int a, ref int b)
    //{
    //    int temp = a;
    //    a = b;
    //    b = temp;
    //}

    //private static void Swap(ref string a, ref string b)
    //{
    //    string temp = a;
    //    a = b;
    //    b = temp;
    //}

    private static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    private static void Main(string[] args)
    {
        //List<int> list = new List<int>(); //<int> 부분이 제네릭 부분

        int a = 10, b = 20;
        Swap<int>(ref a, ref b);
        Console.WriteLine($"a : {a}, b : {b}");

        string c = "aaa", d = "bbb";
        Swap<string>(ref c, ref d);
        Console.WriteLine($"c : {c}, d : {d}");


        User user1 = new User();
        Console.WriteLine($"MaxSize : {User.MaxSize}, MaxSize2 : {user1.MaxSize2}, MaxSize3 : {user1.MaxSize3}");

        Console.Write("전체 크기 : ");
        string str = Console.ReadLine()!;

        int.TryParse(str, out int size);
        User user2 = new User(size);
        Console.WriteLine($"MaxSize : {User.MaxSize}, MaxSize2 : {user2.MaxSize2}, MaxSize3 : {user2.MaxSize3}");


        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < 5; i++)
            stack.Push(i);

        while (stack.IsEmpty() == false)
            Console.WriteLine(stack.Pop());


        int count = 20;
        Stack<float> stack2 = new Stack<float>(count);

        stack2.Push(3.14f); //PI
        stack2.Push(9.8f); //Gravity
        stack2.Push(1e-6f); //10^-6 => 0.000001
        stack2.Push(1e+2f); //10^2 => 100

        Random random = new Random();
        for (int i = 0; i < count; i++)
            stack2.Push(random.NextSingle());

        //while(stack2.IsEmpty() == false)
        //Console.WriteLine(stack2.Pop());

        for (int i = 0; i < count + 10; i++)
            Console.WriteLine(stack2.Pop());
    }
}