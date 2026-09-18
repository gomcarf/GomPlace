class Character
{
    protected string name = ""; //자식에게만 공개

    public string Name
    {
        get => name;
    }

    private float hp;

    public float HP
    {
        get => hp;
    }

    public Character()
    {
        Console.WriteLine("Character 생성자");
    }

    public Character(string name, float hp)
    {
        this.name = name;
        this.hp = hp;

        Console.WriteLine($"Character : {name} 생성자");
    }
}