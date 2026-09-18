using System.Threading;

class Character
{
    private string name = "";
    public string Name
    {
        get { return name; } 
        set { name = value; }
    }

    private float hp;
    public float Hp
    {
        get => hp;                                                                                                                                                                                              
        set { hp = value; }
    }

    private float attack = 20;
    public float Attack
    {
        get { return attack; }
        set { attack = value; }
    }

    public Character()
    {
        Console.WriteLine("기본 생성자");
    }

    public Character(float attack)
    {
        this.attack = attack;
        Console.WriteLine("생성자");
    }

    public Character(string name, float hp, float attack)
    {
        this.name = name;
        this.hp = hp;
        this.attack = attack;
        Console.WriteLine("생성자2");
    }

    public string Print()
    {
        return $"Name : {Name}, Hp : {Hp}, Attack : {Attack}";
    }
}