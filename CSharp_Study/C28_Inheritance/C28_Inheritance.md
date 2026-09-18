# [C28_Inheritance](../CsharpStudy_List.md)

## 상속성

- 기존 클래스(부모/상위 클래스)의 필드와 메서드를 새로운 클래스(자식/하위 클래스)가 물려받아 재사용하거나 확장하는 특징 ⇒ 부모의 것을 가지고 내 것을 추가해가는 것
    - 코드의 재사용성 향상 : 공통되는 데이터나 기능을 부모 클래스에 한 번만 작성해 두면, 여러 자식 클래스에서 코드를 중복해서 만들 필요 없이 그대로 가져다 쓸 수 있음.
    - 유지보수 용이 : 공통적인 로직에 수정이 필요할 때, 부모 클래스 한 곳만 수정하면 이를 상속받은 모든 자식 클래스에 자동으로 적용됨.
    - 확장성 확보 : 부모 클래스의 기능을 건드리지 않고도 자식 클래스에서 고유한 기능을 추가하거나 변경(오버라이딩)하여 확장 가능.
    - 계층 구조 형성 : 클래스 간의 관계(IS-A 관계)를 명확하게 정립하여 시스템을 체계적으로 구조화 가능.

| **개념** | **설명** |
| --- | --- |
| **부모 클래스 (Base / Super Class)** | 기능을 물려주는 상위 클래스 |
| **자식 클래스 (Derived / Sub Class)** | 기능을 물려받는 하위 클래스 |
| **IS-A 관계** | "~은 ~의 일종이다" 관계 (예: "전사(Warrior)는 캐릭터(Character)의 일종이다") |
| **오버라이딩 (Overriding)** | 부모에게 물려받은 메서드를 자식 클래스에서 자신에 맞게 재정의하는 것 |
| **`base` / `super`** | 자식 클래스에서 부모 클래스의 멤버나 생성자에 접근할 때 사용하는 키워드 |

```csharp
class Character //부모 클래스
{
	string name;
	float hp;
}

class Player : Character //상속 표시, Character의 자식 클래스
{
	float atk;
	void Attack();
}

void main()
{
	Player p;
	p.name = "player"; //캐릭터 클래스를 상속받아 플레이어 클래스 객체에 캐릭터 클래스 속성 대입
	p.hp = 100;
}
```

## Main

```csharp
namespace C28_Inheritance
{    
    class Program
    {
        private static void Main(string[] args)
        {
            //Character character = new Character();
            Player player = new Player("P", 100, 20);
            Console.WriteLine(player.Name); //Character
            Console.WriteLine(player.HP); //Character
            Console.WriteLine(player.Attack); //Player

            Console.WriteLine();

            Monster monster = new Monster("M", 100, 10);
            Console.WriteLine(monster.Name); //Character
            Console.WriteLine(monster.HP); //Character
            Console.WriteLine(monster.MP);//monster
        }//Main
    }
}
```

- `Player` 생성자 뒤에 `: base(”P”, 100)` 이 지정되어 있음 ⇒ 부모 클래스인 `Character(”P”, 100)` 생성자가 먼저 실행.
- 부모 객체 부분의 초기화가 끝나면 `Player` 생성자 본문이 실행.
- `player.Name`, `player.HP`는 `Character`로부터 상속받았기 때문에 자유롭게 읽을 수 있음
- `player.Attack`는 `Player` 클래스에서 추가한 자식 전용 프로퍼티

## Character 클래스

```csharp
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
```

### 1. `protected` 접근 제한자

```csharp
protected string name = ""; // 자식에게만 공개
```

- `private` 과의 차이 : `private` 은 해당 클래스 내부에서만 접근할 수 있지만, `protected`는 자기 자신 내부와 이 클래스를 상속받은 자식 클래스 내부에서도 접근을 허용
- 외부에서는 `name` 변수를 함부로 수정하지 못하게 막으면서, 자식클래스에서는 부모의 `name` 멤버 변수에 직접 접근해 활용할 수 있도록 작성된 접근 제한

### 2. 읽기 전용 프로퍼티

```csharp
public string Name => name; // get => name; 의 축약 표현
public float HP => hp;
```

- `set` 블록이 없이 `get`만 존재하는 읽기 전용 프로퍼티
- 외부에서는 `character.Name`이나 `character.HP` 형태로 값을 읽을 수만 있고, `character.HP = 200;` 처럼 외부에서 값을 직접 수정하는 것을 방지(캡슐화)

### 3. 생성자 오버로딩(Constructor Overloading) 및 부모 생성자의 특징

```csharp
//매개변수가 없는 기본 생성자
public Character()
{
    Console.WriteLine("Character 생성자");
}

//매개변수를 갖는 생성자
public Character(string name, float hp)
{
    this.name = name;
    this.hp = hp;

    Console.WriteLine($"Character : {name} 생성자");
}
```

- 동일한 이름의 생성자를 매개변수의 개수나 타입에 따라 여러 개 선언하는 생성자 오버로딩이 적용
- 상속 시 중요한 동작 규칙
    - 기본적으로 부모 클래스의 생성자가 먼저 실행된 후 자식 클래스의 생성자가 실행됨
    - 자식 클래스에서 명시적으로 부모 생성자를 지정하지 않으면 기본 생성자인 `Character()`가 자동으로 호출됨
    - `Character(string, float)`를 호출하고 싶다면 자식 클래스 생성자 뒤에 `: base(name, hp)`를 붙여줘야함.

## Player 클래스 : Character 상속

```csharp
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
```

### 1. 상속과 확정( `: Character`)

```csharp
class Player : Character
```

- `Player` 클래스는 `Character` 클래스의 모든 프로퍼티(`Name`, `HP`)와 `protected` 필드를 물려 받음
- 자식 클래스만의 전용 필드인 `private float attack;`과 읽기 전용 프로퍼티 `Attack`을 추가하여 기능을 확장

### 2. 부모 생성자의 명시적 호출( `: base(…)` )

- 자식 클래스 객체가 생성될 때는 반드시 부모 클래스의 생성자가 먼저 실행되어야 함.

#### 1. 기본 생성자 처리

```csharp
public Player(): base("None",0) //부모 클래스의 생성자 선택 호출
{
    Console.WriteLine("Player 생성자");
}
```

- `Player()` 매개변수 없는 생성자 호출 시 `: base(”None”, 0)`을 통해 부모의 `Character(string name, float hp)` 생성자를 명시적으로 실행
- 부모 쪽에서 `name = “None”`, `hp=0`으로 초기화된 후 `Player` 내부 로직이 실행됨.

#### 2. 매개변수가 있는 생성자 처리

```csharp
public Player(string name, float hp, float attack)
        : base(name,hp)//부모의 Character(name,hp)생성자에서 name, hp 세팅하겠지
{
    //this.name = name; //부모의 name이 private이면 에러발생        
    this.attack = attack;

    Console.WriteLine($"Player : {this.name} 생성자");
}
```

- 외부에서 전달받은 `name`과 `hp`를 부모 생성자 `: base(name, hp)`로 그대로 전달해 초기화를 부모 클래스에 위임
- `Player` 클래스는 자신의 전용 데이터인 `attack` 변수 초기화만 전담하므로 역할 분담이 깔끔하게 이루어짐

#### 3. `protected` 필드 직접 접근

```csharp
Console.WriteLine($"Player : {this.name} 생성자");
```

- 부모의 `name` 필드가 `private`이면 자식 클래스인 `Player` 내부에서 `this.name`으로 접근할 수 없음
- `name`을 `protected`로 선언했기 때문에, 자식 클래스 내부에서 부모의 `name` 변수에 직접 접근해 콘솔에 출력 가능.

## Monster 클래스 :  Character 상속

```csharp
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
```

### 1. 클래스 상속과 필드 추가(`:Character`)

```csharp
class Monster : Character
```

- `Monster` 클래스는 `Character` 부모 클래스로부터 `Name`, `HP` 프로퍼티와 `protected` 필드인 `name`을 상속 받음
- 몬스터만의 독자적인 속성인 `private float mp;` 필드와 이를 읽을 수 있는 `MP` 프로퍼티를 새롭게 추가함

### 2. 기본 생성자 호출 동작의 차이(`Monster()`)

```csharp
public Monster()
{
    Console.WriteLine("Monster 생성자");
}
```

- `: base(…)`가 명시되어 있지 않음
- 자식 클래스 생성자에 `: base(…)`를 따로 적어주지 않으면, C# 컴파일러가 부모 클래스의 매개변수가 없는 기본 생성자(`Character()`)를 자동으로 먼저 호출
- `new Monster()` 를 실행하면 부모의 `Character()`가 실행되어 “`Character 생성자`” 가 먼저 출력된 뒤, “`Monster 생성자`”가 출력됨

### 3. 매개변수가 있는 생성자(`Monster(string, float, float)`)

```csharp
public Monster(string name, float hp, float mp)
        : base(name,hp)
{
    this.mp = mp;
    Console.WriteLine($"Monster : {this.name} 생성자");
}
```

- 외부에서 받은 `name`과 `hp`는 부모 생성자인 `: base(name, hp)`로 전달하여 부모 클래스 쪽에서 초기화하도록 넘겨줌
- `Monster` 클래스 본인은 자식 전용 필드인 `this.mp` 만 초기화하므로 책임이 명확히 분리됨
- 부모의 `name` 필드가 `protected`로 선언되어 있으므로, 자식 클래스 내에서 `this.name`으로 직접 접근해 출력 문자열에 활용하고 있음

## 상속 관계에 따른 멤버 변수 접근 가능 여부

```csharp
class character
{
	int a;
}

class player : character
{
	int b;
}

class Monster : character
{
	int c;
}

character.a=10;
character.b=10; //불가능
player.a=10;
player.b=20;
player.c=30; // 불가능
monster.a=10;
monster.b=20; //불가능
monster.c=30;
```

- `character` (부모 객체)
    - `character.a = 10;` (가능) : 자신이 가지고 있는 변수 `a`에 접근
    - `character.b = 10;` (불가능) : 자식 클래스(`player`)에만 존재하는 변수 `b`는 알지 못함
- `player` (자식 객체)
    - `player.a = 10;` (가능) : 부모(`character`)로부터 상속받은 변수 `a`에 접근
    - `player.b = 20;` (가능) : 자신이 가지고 있는 변수 `b`에 접근
    - `player.c = 30;` (불가능) : 형제 관계인 `Monster` 클래스의 변수 `c`에는 접근 불가
- `monster` (자식 객체)
    - `monster.a = 10;` (가능) : 부모(`character`)로부터 상속받은 변수 `a`에 접근
    - `monster.b = 20;` (불가능) : 형제 관계인 `player` 클래스의 변수 `b`에는 접근 불가
    - `monster.c = 30;` (가능) : 자신이 가지고 있는 변수 `c`에 접근