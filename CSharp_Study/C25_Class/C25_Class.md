# [C25_Class](../CsharpStudy_List.md)

- 클래스 : 객체지향 프로그래밍에서 객체를 만들기 위한 설계도
    - 클래스는 크게 변수(데이터)와 메서드(코드)로 구성됨
    - 필드(Field / 속성) : 객체의 상태(State)를 나타냄. 클래스 내부에 선언된 변수
    - 메서드(Method / 기능) : 객체의 동작(Behavior)을 나타냄. 클래스 내부에서 정의된 함수
    - 생성자(Constructor) : 객체가 메모리에 생성될 때 초기화 작업을 담당하는 특별한 메서드

## 실제 객체 메모리 생성/사용

```csharp
namespace C25_Class
{
    class Program
    {            
        private static void Main(string[] args)
        {
            Character player = new Character();//생성자 : 클래스 이름과 같은 함수 \ 일반생성자가 선언되었기 때문에 기본 생성자 오류표시
            player.Name = "Player";
            player.Hp = 100;
            //player.Attack = 30;

            //player.Name = "Player2";
            //player.Hp = 80;

            Character monster = new Character(80); //초기 값을 설정해줄 때 생성자를 많이 이용함
            monster.Name = "Monster";
            monster.Hp = 50;

            Console.WriteLine($"Player Name: {player.Name}, Hp : {player.Hp}, Attack : {player.Attack}");

            string print = $"Player Name: {monster.Name}, Hp : {monster.Hp}, Attack : {monster.Attack}";
            Console.WriteLine(print);
            
            string print2 = monster.Print();
            Console.WriteLine(print2);

            string print3 = player.Print();
            Console.WriteLine(print3);

            Character Oak = new Character("Oak", 50, 10);
            Console.WriteLine(Oak.Print());
        }//Main
    }
}
/*
 디버깅
F9로 중단점 설정
F5로 실행해서 조사식에 확인 필요한 변수 입력 후 F5 누르면서 한단계씩 추척하기
 */

//클래스가 나오면 생성자가 반드시 나옴
```

### 1. 객체별 생성자와 속성 설정 방식

#### 1) player 객체 : 기본 생성자 + 프로퍼티 직접 지정

```csharp
Character player = new Character();//생성자 : 클래스 이름과 같은 함수 \ 일반생성자가 선언되었기 때문에 기본 생성자 오류표시
player.Name = "Player";
player.Hp = 100;
```

- 매개변수가 없는 `Character()` 기본 생성자 사용하여 빈 객체 생성
- 생성된 객체의 프로퍼티(`Name`, `Hp`)에 접근해 값을 하나씩 저장
- `player.Attack`은 별도로 저장하지 않았으니 기본값 20이 유지됨

#### 2) monster 객체 : 매개변수 1개 생성자 + 프로퍼티 추가 지정

```csharp
Character monster = new Character(80); 
monster.Name = "Monster";
monster.Hp = 50;
```

- 공격력을 전달 받는 `Character(float Inattack)` 생성자를 호출하여 생성과 동시에 공격력을 80으로 초기화
- 나머지 `Name`과 `Hp`는 생성 후 프로퍼티를 통해 각각 설정

//초기 값을 설정해줄 때 생성자를 많이 이용함

#### 3) Oak 객체 : 전체 매개변수 생성자(가장 간결한 방식)

```csharp
Character Oak = new Character("Oak", 50, 10);
```

- 모든 값을 인자로 받는 `Character(string, float, float)` 생성자를 활용
- 단 한줄로 객체 생성과 초기화를 한번에 완료.

### 2. 정보 출력 방식 비교

```csharp
// 방식 1
Console.WriteLine($"Player Name: {player.Name}, Hp : {player.Hp}, Attack : {player.Attack}");

// 방식 2
string print3 = player.Print();
Console.WriteLine(print3);
```

- 방식 1 : `Main` 함수에서 매법 프로퍼티를 일일이 가져와 문장을 만들어야 함 ⇒ 번거로움
- 방식 2 : 클래스가 가지고 있는 `Print()` 메서드를 호출하여 한 줄로 간단하게 출력 ⇒ 유지보수와 재사용성이 훨씬 뛰어남.

## 프로퍼티(Property)와 생성자 오버로딩(Constructor Overloading)

```csharp
using System.Threading;

class Character
{
    private string name = "";
    public string Name 
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
    public float Attack //프로퍼티
    {
        get { return attack; }
        set { attack = value; }
    }

    public Character() 
    {
        Console.WriteLine("기본 생성자");
    }

    public Character(float Inattack) 
    {//이 함수의 attack은 클래스 멤버 변수가 아니라 생성자 내의 지역ㅂ 변수를 의미
        attack = Inattack;
        Console.WriteLine("생성자");
    }

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
```

### 1. 필드와 프로퍼티 (정보 은닉 & 캡슐화)

```csharp
private string name = "";
public string Name 
{
    get { return name; } //값을 읽기
    set { name = value; } //값을 쓸수 있도록 제어
}

private float hp;
public float Hp
{
    get => hp; //get의 람다
    set { hp = value; }
}

private float attack = 20; //기본값
public float Attack //프로퍼티
{
    get { return attack; }
    set { attack = value; }
}
```

- 클래스의 멤버 변수(필드)를 `private`로 숨겨서 직접 접근하지 못하게 막고 프로퍼티(Property)를 제공하여 값을 읽거나(`get`) 쓸 수 있도록(`set`) 제어
    - Name 프로퍼티 : 기본 형태의 프로퍼티. `value`는 외부에서 넘겨준 전달인자 값을 의미
    - Hp 프로퍼티 : `get= > hp;` 처럼 람다 표기법을 사용해 `get { return hp; }` 를 짧게 줄여 쓴 형태
    - Attack 프로퍼티 : 초기값 20을 가진 `attack` 변수를 다룸

초록 밑줄 : 경고. 실행은 되지만 이렇게 두면 위험해~~ 그래서 ""로 기본값 설정해주기
최신 C#에선 `public string Name { get; set; }`과 같은 자동 구현 프로퍼티를 사용하면 `private string name;` 변수 선언 자체를 생략할 수 있어 코드가 훨씬 깔끔해짐

- 클래스에서는 절대 변수에 직접 대입하지 않고 이런식으로 셋팅해서 대입해줌

### 2.  생성자 오버로딩 (Constructor Overloading)

```csharp
public Character() 
{
    Console.WriteLine("기본 생성자");
}

public Character(float Inattack) 
{//이 함수의 attack은 클래스 멤버 변수가 아니라 생성자 내의 지역 변수를 의미
    attack = Inattack;
    Console.WriteLine("생성자");
}

public Character(string InName, float InHp, float InAttack)
{
    name = InName;
    hp = InHp;
    attack = InAttack;
    Console.WriteLine("생성자2");
}
```

- 생성자 : 클래스 이름과 같은 함수 (이 코드에선 일반 생성자가 선언되었기 때문에 기본 생성자 오류표시)
- Character() : 매개 변수가 없는 기본 생성자. 아무 값도 주지 않고 객체를 만들 때 호출
- Character(float InAttack) : 공격력 값 하나만 받아서 초기화.

//이 함수의 attack은 클래스 멤버 변수가 아니라 생성자 내의 지역 변수를 의미

- Character(string InName, float InHp, float InAttack) : 이름, 체력, 공격력을 한 번에 받아서 초기화하는 전체 생성자

//일반생성자가 선언되면 기본생성자 사라짐, 오류가 뜨니까 위해 기본 생성자 하나 만들어준다잉
//생성자 안에 아무것도 없는 상태: 기본생성자. 없어도 실행 잘만됨(c#내부적으로 선언)
//생성자는 return 불가하기 때문에 리턴 타입 없음
//생성자도 private이 될 때가 있음. 생성자가 private이면 메인에서 호출 불가

### 3. `Print()` 메서드

```csharp
public string Print()
{
    return $"Name : {Name}, Hp : {Hp}, Attack : {Attack}";
}
```

- 객체의 현재 정보를 문자열 형태로 가공하여 반환해 주는 메서드
- 필드 변수(`name`, `hp`, `attack`) 대신 프로퍼티(`Name`, `Hp`, `Attack`)를 통해 값을 읽어오도록 작성되어 있음