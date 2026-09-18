class Player : Character
{
    private float attack;

    public float Attack
    {
        get => attack;
    }

    public Player(): base("None",0) //부모 클래스의 생성자 선택 호출
    {
        Console.WriteLine("Player 생성자");
    }

    public Player(string name, float hp, float attack)
        : base(name,hp)//부모의 Character(name,hp)생성자에서 name, hp 세팅하겠지
    {
        //this.name = name; //부모의 name이 private이면 에러발생        
        this.attack = attack;

        Console.WriteLine($"Player : {this.name} 생성자");
    }
}