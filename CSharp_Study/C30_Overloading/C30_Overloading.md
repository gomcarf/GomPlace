# C30_Overloading

## 다형성(Polymorphism)

- 오버로딩(중복) - 같은 클래스 내 같은 이름의 함수가 2개 이상 (함수 이름, 파라미터의 타입과 개수가 같아야 같은 함수로 인식)
- 오버라이딩 - 상속에서 일어나는 다형성

```csharp
/* 오버라이딩이 아닌 경우*/
Class Character
{
	void Attack(){ " 기본 공격 " } //virtual
}

//자식 클래스 어택함수가 부모 클래스 어택을 가림 //override 라고 명시하면 오류 사라짐
Class Player : Character
{
	void Attack(){ "플레이어 공격" }  
}
```

## 오버로딩(Overloading)

- 같은 클래스 내에서 이름은 같지만 매개변수의 타입, 개수, 순서를 다르게 하여 메서드를 여러개 정의하는 것
- 특징
    - 메서드 이름은 반드시 같아야 함
    - 매개변수(Parameter)의 타입이나 개수가 달라야 함(리턴 타입만 다른 것은 오버로딩 불가)
    - 컴파일 시점에 어떤 메서드가 호출될지 결정되므로 정적 다형성이라고도

```csharp
class Player
{
    private int hp;

    public Player(int hp)
    {
        this.hp = hp;
    }

    public void Print()
    {
        Console.WriteLine($"Print - this.hp : {hp}");
    }

    public void Print(int hp)
    {
        Console.WriteLine($"Print - this.hp : {this.hp}, hp : {hp}");
    }

    public enum EAttackType //enum : 열거형 타입
    {
        None, Melee, Range, Wide, 
    }

    public void Print(EAttackType type)
    {
        Console.WriteLine($"Print - {type}, {(int)type}");

        Console.WriteLine();

        EAttackType[] types = Enum.GetValues<EAttackType>(); //GetValues: 열거형 값들을 가져오는 함수
        foreach(EAttackType t in types)
            Console.WriteLine($"{t}, {(int)t}");

        Console.WriteLine();
    }

    public void Print(int hp, int multiply)
    {
        Console.WriteLine($"Print - this.hp : {this.hp}, hp : {hp*multiply}");
    }
}
```

### 1. 멤버 변수 및 생성

```csharp
private int hp;

public Player(int hp)
{
    this.hp = hp;
}
```

- `private int hp;` : 플레이어의 체력을 저장하는 변수
- `Player(int hp)` : 체력을 전달받아 Player객체를 생성하는 생성자

### 2. 매개변수가 없는 `Print()`

```csharp
public void Print()
{
    Console.WriteLine($"Print - this.hp : {hp}");
}
```

- 아무 인자도 받지 않고 호출되면 플레이어가 가지고 있는 기본 hp 값을 출력

### 3. 정수 매개변수 하나를 받는 `Print(int hp)`

```csharp
public void Print(int hp)
{
    Console.WriteLine($"Print - this.hp : {this.hp}, hp : {hp}");
}
```

- 전달받은 hp값과 클래스의 hp값을 함께 출력
- `this` 역할 : 메서드 내부의 매개변수 `hp`와 클래스 멤버 변수 `this.hp`가 이름이 겹치므로 `this`를 붙여 클래스의 필드임을 명시

### 4. 열거형(Enum) 매개변수를 받는 `Print(EAttackType type)`

```csharp
public enum EAttackType //enum : 열거형 타입
{
    None, Melee, Range, Wide, 
}

public void Print(EAttackType type)
{
    Console.WriteLine($"Print - {type}, {(int)type}");

    Console.WriteLine();

    EAttackType[] types = Enum.GetValues<EAttackType>(); //GetValues: 열거형 값들을 가져오는 함수
    foreach(EAttackType t in types)
        Console.WriteLine($"{t}, {(int)t}");

    Console.WriteLine();
}
```

- EAttackType 열거형 : 공격 유형을 나타내며, 각 요소는 순서대로 None(0), Melee(1), Range(2), Wide(3)의 정수 값을 자동으로 가짐

### 5. 정수 매개변수 두 개를 받는 Print(int hp, int multiply)

```csharp
public void Print(int hp, int multiply)
{
    Console.WriteLine($"Print - this.hp : {this.hp}, hp : {hp*multiply}");
}
```

- 전달받은 `hp`에 `multiply`를 곱한 결과값과 클래스 내부의 `this.hp`를 출력

### Main

```csharp
namespace C30_Overloading
{
    class Program
    {
        private static void Main(string[] args)
        {
            Player player = new Player(100);
            player.Print(); //1. 기본 Print
            player.Print(50); //2. hp만 전달
            player.Print(Player.EAttackType.Range); //3.Enum 전달
            player.Print(30, 5); //4. hp와 multiply 전달
        }//Main
    }
}
```

- 출력 결과

```
Print - this.hp : 100
Print - this.hp : 100, hp : 50
Print - Range, 1

None, 0
Melee, 1
Range, 2
Wide, 3

Print - this.hp : 100, hp : 150
```