class Character
{
    private string name = "";
    public string Name => name;

    private float hp;
    public float HP => hp;

    public Character(string name, float hp)
    {
        this.name = name;
        this.hp = hp;
    }
}

class Player : Character //기본 생성자가 없으면 클래스 이름에 오류표시
{
    private float attack;
    public float Attack => attack;

    public Player(string name, float hp, float attack)
        : base(name,hp)
    {
        this.attack = attack;
    }
}

class Monster : Character
{
    private float mp;
    public float MP => mp;
    public Monster(string name, float hp, float mp)
        :base(name, hp)
    {
        this.mp = mp;
    }
}