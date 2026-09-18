class Monster : Character
{
    private float mp;
    public float MP //=>mp; 로 쓸수도 있음(get만 쓸때)
    {
        get => mp;
    }

    public Monster()
    {
        Console.WriteLine("Monster 생성자");
    }

    public Monster(string name, float hp, float mp)
        : base(name,hp)
    {
        this.mp = mp;

        Console.WriteLine($"Monster : {this.name} 생성자");
    }
}