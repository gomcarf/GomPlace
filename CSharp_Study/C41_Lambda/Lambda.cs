using System;
using System.Reflection.Metadata.Ecma335;

public struct Monster
{
    private string name;
    public string Name => name;

    private int hp;
    public int HP => hp;

    private int mp;

    public Monster(string name, int hp, int mp)
    {
        this.name = name;
        this.hp = hp;
        this.mp = mp;
    }

    public override string ToString()
    {
        return $"Monster : {name}, HP : {hp}, MP : {mp}";
    }
}

class Lambda
{
    public void Test(int a, string b)
    {
        Console.WriteLine($"Test : {a}, {b}");
    }

    public void Case1()
    {
        Action<int, string> action;
        action = Test;
        action(10, "Unity");


        void Test2(int a, string b)
        {
            Console.WriteLine($"Test2 : {a}, {b}"); //클로저
        }
        action = Test2;
        action(20, "C#");


        action = (int a, string b) => //람다문(익명 메서드)
        {
            Console.WriteLine($"Test3 : {a}, {b}"); //클로저
        };
        action(30, "C++");

        action = (a, b) => Console.WriteLine($"Test3 : {a}, {b}"); //람다식
        action(40, "Python");
    }


    //public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
    //public delegate string Func<int, string);
    //public delegate int MyDelegate(int a, string b);

    private int number;
    public int Number => number;
    //{
    //    get{ return number; }
    //}


    public void Case2()
    {
        Action<string> action = (str) => Console.WriteLine($"Case2 : {str}"); //람다식(중괄호가 없으면, return 없음)
        action("Unity"); //그냥 실행

        Func<int, string, string> func;
        func = (a, b) => $"Case2 : {a}, {b}"; //람다식(return 포함)

        string result = func(10, "Unity"); //func의 return을 받아와서 출력
        Console.WriteLine(result);
    }

    int Square(int x)//클로저(함수 내부에 선언하는 함수)
    {
        return x * x;
    }

    public void Case3()
    {
        int Square2(int x)//클로저(함수 내부에 선언하는 함수)
        {
            return x * x;
        }

        int a = 10;
        int b = Square(a);//Call by Value(a랑 x랑 메모리 공간 다름)
        int c = Square2(a); //Call by Value

        Console.WriteLine($"Case3 - Square : {b}, Square2 : {c}");
        Console.WriteLine($"Case3 - a : {a}");

        int d = 20;
        int Square3(int x)
        {
            return d + x; //d: Reference
        }
        Func<int, int> func = Square3;
        int e = func(10);
        Console.WriteLine($"Case3 - Square3 : {e}");

    }

    public void Case4()
    {
        Func<string> func = () => "Hello Lambda"; 
        string result = func();
        Console.WriteLine($"Case4 : {result}");

        Func<string> func2 = () =>
        {
            return "Hello Lambda2"; //람다문에는 return을 붙여줘야 함.
        };
        string result2 = func2();
        Console.WriteLine($"Case4 : {result2}");
    }

    public void Case5()
    {
        //Action : return이 없음
        //Func : return이 있음(TResult : 타입은 편한대로)
        //Predicate : return이 bool로 고정, 파라미터는 하나 사용 가능 / find할 때 많이 사용
        
        Predicate<string> predicate = (str) => str.Length > 5; //결과가 bool타입이니 조건문이 들어감
        bool result = predicate("Hello Lambda");
        Console.WriteLine($"Case5 : {result}");

        //Comparison : return이 int, 파라미터는 2개 가능. / 비교할 때 많이 사용(정렬)
        Comparison<int> comparison = (x, y) => x.CompareTo(y); // x<y : -1  x=y : 0  x>y : 1
    }

    public void Case6()
    {
        Random random = new Random(1000);

        List<int> numbers = new List<int>();
        for (int i = 0; i < 100; i++)
            numbers.Add(random.Next(1, 100));

        Console.WriteLine("-------------------------------------------------------------------------------");

        int count = 0;
        foreach (int number in numbers)
        {
            Console.Write($"{number:00}\t");

            count++;
            if(count >= 10)
            {
                count = 0;
                Console.WriteLine();
            }    
        }

        Console.WriteLine("-------------------------------------------------------------------------------");
        numbers.ForEach((number) =>
        {
            Console.Write($"{number:00}\t");

            count++;
            if (count >= 10)
            {
                count = 0;
                Console.WriteLine();
            }
        });
        Console.WriteLine("-------------------------------------------------------------------------------");

        int found = numbers.Find((x) => x > 50);
        Console.WriteLine($"Case6 - Find : {found}");

        Console.Write($"Case6 - FindAll : ");
        List<int> founds = numbers.FindAll((x) => x < 10);
        founds.ForEach((x) => Console.Write($"{x:00} "));

        Console.WriteLine();
        Console.Write($"Case6 - Distinct : ");
        founds.Distinct().ToList().ForEach((x) => Console.Write($"{x:00} ")); //중복을 제거해서 선형 자료형으로 반환 > IEnumerable > List로 변환 > foreach로 출력

        List<int> osc = new List<int>();
        osc.AddRange(numbers);

        osc.Sort();
        Console.WriteLine();
        Console.WriteLine("-------------------------------------------------------------------------------");
        osc.ForEach((number) =>
        {
            Console.Write($"{number:00}\t");

            count++;
            if (count >= 10)
            {
                count = 0;
                Console.WriteLine();
            }
        });
        Console.WriteLine("-------------------------------------------------------------------------------");

        List<int> desc = new List<int>();
        desc.AddRange(numbers);

        desc.Sort((x, y) => y.CompareTo(x));
        Console.WriteLine("-------------------------------------------------------------------------------");
        desc.ForEach((number) =>
        {
            Console.Write($"{number:00}\t");

            count++;
            if (count >= 10)
            {
                count = 0;
                Console.WriteLine();
            }
        });
        Console.WriteLine("-------------------------------------------------------------------------------");
    }

    public void Case7()
    {
        Monster[] monsters = new Monster[5];
        monsters[0] = new Monster("슬라임", 100, 10);
        monsters[1] = new Monster("고블린", 90, 20);
        monsters[2] = new Monster("오크", 120, 1);
        monsters[3] = new Monster("트롤", 200, 9);
        monsters[4] = new Monster("드래곤", 300, 50);

        List<Monster> monsterList = monsters.ToList();
        monsterList.Sort((x,y) => x.Name.CompareTo(y.Name));
        monsterList.ForEach((monster) => Console.WriteLine(monster));
        Console.WriteLine();
        monsterList = monsters.ToList();
        monsterList.Sort((x, y) => y.HP.CompareTo(x.HP));
        monsterList.ForEach((monster) => Console.WriteLine(monster));

    }
}
