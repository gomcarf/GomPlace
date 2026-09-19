class Player
{
    private int hp;

    public Player(int hp)
    {
        this.hp = hp;
    }

    public void Print()
    {
        Console.WriteLine($"Print - this.hp : {hp}");
    }

    public void Print(int hp)
    {
        Console.WriteLine($"Print - this.hp : {this.hp}, hp : {hp}");
    }

    public enum EAttackType
    {
        None, Melee, Range, Wide, 
    }

    public void Print(EAttackType type)
    {
        Console.WriteLine($"Print - {type}, {(int)type}");

        Console.WriteLine();

        EAttackType[] types = Enum.GetValues<EAttackType>(); //열거형 값들을 가져오는 함수
        foreach(EAttackType t in types)
            Console.WriteLine($"{t}, {(int)t}");

        Console.WriteLine();
    }

    public void Print(int hp, int multiply)
    {
        Console.WriteLine($"Print - this.hp : {this.hp}, hp : {hp*multiply}");
    }
}