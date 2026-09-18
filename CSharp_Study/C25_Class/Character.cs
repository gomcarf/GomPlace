using System.Threading;

class Character
{//초록 밑줄: 경고. 실행은 되지만 이렇게 두면 위험해~~ 그래서 ""로 기본값 설정해주기
    private string name = "";//클래스 멤버 변수는 기본적으로 private
    public string Name //클래스에서는 절대 변수에 직접 대입하지 않고 이런식으로 셋팅해서 대입해줌
    {
        get { return name; } //값을 가져오기
        set { name = value; } //값을 저장
    }

    private float hp;
    public float Hp
    {
        get => hp; //get의 람다                                                                                                                                                                                                  
        set { hp = value; }
    }

    private float attack = 20; //기본값
    public float Attack
    {
        get { return attack; }
        set { attack = value; }
    }

    public Character()
    {
        Console.WriteLine("기본 생성자");
    }

    public Character(float Inattack) //생성자는 return 불가하기 때문에 리턴 타입 없음
    {//이 함수의 attack은 클래스 멤버 변수가 아니라 생성자 내의 지역ㅂ 변수를 의미
        attack = Inattack;
        Console.WriteLine("생성자");
    }//일반생성자가 선언되면 기본생성자 사라짐, 오류가 뜨니까 위해 기본 생성자 하나 만들어준다잉
    //생성자 안에 아무것도 없는 상태: 기본생성자. 없어도 실행 잘만됨(c#내부적으로 선언)

    public Character(string InName, float InHp, float InAttack)
    {
        name = InName;
        hp = InHp;
        attack = InAttack;
        Console.WriteLine("생성자2");
    }

    public string Print()
    {
        return $"Name : {Name}, Hp : {Hp}, Attack : {Attack}";
    }
}