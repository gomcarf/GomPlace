class Character
{
    private string name;

    public string Name
    {
        get => name;
        protected set => name = value;
    }

    private int power;
    public int Power
    {
        get => power;
        protected set => power = value;
    }

    public virtual void Attack() //재정의하기 위한 virtual
    {
        Console.WriteLine($"Charcater : {name}, Power : {power}");
    }
}
