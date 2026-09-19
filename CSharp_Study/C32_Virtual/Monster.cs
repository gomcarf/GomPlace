class Monster : Character
{
    public Monster(string name, int power)
    {
        Name = name;
        Power = power;
    }

    public override void Attack() //new로 부모 가리기, 자동할당 > 그냥 부모 쪽으로 가버림  ///생략은 부모 함수 사용, 동적 할당
    {
        Console.WriteLine($"Monster : {Name}, Power : {Power}");
    }

}

class Player : Character
{
    public Player(string name, int power)
    {
        Name = name;
        Power = power;
    }

    public override void Attack() //부모의 어택함수 재정의
    {
        Console.WriteLine($"Player : {Name}, Power : {Power}");
    }
}