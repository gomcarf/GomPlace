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

    private Print print; //바로 new를 쓰지 않고 생성자에서 new로 초기화
    //선언부에는 일반적으로 new를 사용하진 않음
    public Character(string name, float hp, float attack)
    {
        this.name = name;
        this.hp = hp;
        this.attack = attack;
        //Console.WriteLine("생성자2");

        print = new Print(this); //캐릭터 객체 전체를 전달
    }

    public void PrintString()
    {
        string str = print.Execute();
        Console.WriteLine(str);
    }
}