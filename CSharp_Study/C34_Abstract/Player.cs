using System.Reflection.Metadata.Ecma335;

abstract class Player //추상 클래스:추상메서드를 하나라도 포함하면 추상클래스
{
    protected string name;
    protected int hp;
    protected int mp;
    protected int power;

    public Player(string name, int hp, int mp, int power)
    {
        this.name = name;
        this.hp = hp;
        this.mp = mp;
        this.power = power;
    }

    public abstract void Attack(Monster monster); //추상 메서드 abstract 사용한 추상함수
    
    public void Print()
    {
        string str = "";
        str += $"===================================\n";
        str += $"이름 : {name}\n";
        str += $"HP : {hp}, MP : {mp}, Power : {power}\n";
        str += $"===================================\n";

        Console.WriteLine(str);
    }

}

class Warrior : Player
{
    public Warrior(string name, int hp, int mp, int power)
        :base(name, hp, mp, power)
    {
        Console.WriteLine("전사 선택!");

        Print();
    }

    public override void Attack(Monster monster)
    {
        if(monster.HP < 1) //실행하지 않을 조건을 먼저 위에 써주고 뒤에 실행하는 내용을 써주는게 좋음
        {
            Console.WriteLine($"{monster.Name} 사망\n");

            return;
        }

        string str = "";
        str += $"{name}이 {monster.Name}을 검으로 공격\n";
        str += $"{monster.Name}의 HP가 {monster.HP} 남음\n";
        Console.WriteLine(str);
        
    }
}

class Mage : Player
{
    public Mage(string name, int hp, int mp, int power)
        : base(name, hp, mp, power)
    {
        Console.WriteLine("마법사 선택!");

        Print();
    }

    public override void Attack(Monster monster)
    {
        if (monster.HP < 1) //실행하지 않을 조건을 먼저 위에 써주고 뒤에 실행하는 내용을 써주는게 좋음
        {
            Console.WriteLine($"{monster.Name} 사망\n");

            return;
        }

        string str = "";
        str += $"{name}이 {monster.Name}을 파이어볼로 공격\n";
        str += $"{monster.Name}의 HP가 {monster.HP} 남음\n";
        Console.WriteLine(str);



    }
}

class Monster
{
    private string name;
    public string Name => name;

    private int hp;
    public int HP => hp;

    public Monster(string name,int hp)
    {
        this.name = name;
        this.hp = hp; 
    }
}