class Monster
{
    private int number;
    public int Number => number;

    private static int count;

    public Monster()
    {
        Console.WriteLine($"Monster 생성자 : {number}");

        number = ++count;
    }

    public void Print()
    {
        Console.WriteLine($"Monster : {number}, {count}");
    }

    public static void PrintCount()
    {
        //Console.WriteLine($"Monster Static : {number}, {count}"); //static 함수는 static 변수나 함수만 참조 가능**
        Console.WriteLine($"Monster Static : {count}");

        //Print(); //스태틱 함수가 아니므로 접근 불가
        PrintStatic();
    }

    public static void PrintStatic()
    {
        Console.WriteLine("static은 static 영역만 접근 가능");
    }
}
class Program
{
    private static void Main(string[] args)
    {
        Monster[] monsters = new Monster[5];

        for(int i =0; i< monsters.Length; i++)
        {
            monsters[i] = new Monster();
            Console.WriteLine($"Monster {monsters[i].Number} 생성");
        }

        foreach(Monster monster in monsters)
        {
            monster.Print();
        }

        Monster.PrintCount();

    }//Main
}