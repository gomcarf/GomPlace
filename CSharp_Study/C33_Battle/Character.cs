class Character
{
    public string Name { get; protected set; }

    public int Hp { get; set; }

    public int Power { get; protected set; }
    
    public virtual void Attack(Character character) //이 함수는 가상화(virtual) 됨. 자식 클래스에서 **필요하면**  오버라이딩해서 사용해라
    {
        string str = "";
        str += $"{Name}이 {character.Name}을 공격\n";

        if (character.Hp > 0)
            str += $"{character.Name}의 체력이 {character.Hp}만큼 남음\n";
        else
            str += $"{character.Name} 사망!!";
        Console.WriteLine(str);
    }
}

class Monster : Character
{
    public Monster(string name, int hp, int power)
    {
        Name = name;
        Hp = hp;
        Power = power;
    }

    //부모의 어택 함수 그냥 사용, 동적할당
    public override void Attack(Character character)
    {
        character.Hp -= Power;
        string str = $"{Name}이 {character.Name}을 {Power} 만큼 공격\n";
        Console.WriteLine(str);
        base.Attack(character);
    }
}

class Player : Character
{
    public int Up { get; private set; } //자기자신에서만 세팅

    public Player(string name, int hp, int power, int up)
    {
        Name = name;
        Hp = hp;
        Power = power;
        Up = up;
    }

    public override void Attack(Character character)
    {
        character.Hp -= Power + Up;
        string str = $"{Name}이 {character.Name}을 {Power}+{Up}만큼 공격\n";
        Console.WriteLine(str);
        base.Attack(character);
    }

}