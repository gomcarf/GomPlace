# C34_Abstract

## 추상화(abstract)

- 이름만 명시하고 몸체는 없음
    - 이름은 너희가 이걸로 쓰고 몸체는 알아서 정의해라
    - 대신 무조건 써야됨. 안쓰면 에러날게.
- 필요한 이유
    - 복잡성 감소 : 복잡한 세부 구현을 신경쓰지 않고, 객체가 제공하는 핵심 기능만 바라보고 코드를 작성
    - 코드 재사용성 및 유연성 증가 : 공통 개념을 추상화해 두면 새로운 세부 클래스를 만들 때 동일한 틀 안에서 빠르게 확장할 수 있음
    - 결합도 낮추기 : 구현체가 아닌 추상화된 개념에 의존하게 만들어, 코드 변경 시 여파를 최소

## Player 클래스

```csharp
abstract class Player //추상 클래스:추상메서드를 하나라도 포함하면 추상클래스
{
    protected string name;
    protected int hp;
    protected int mp;
    protected int power;

    public Player(string name, int hp, int mp, int power)
    {
        this.name = name;
        this.hp = hp;
        this.mp = mp;
        this.power = power;
    }

    public abstract void Attack(Monster monster); //추상 메서드 abstract 사용한 추상함수
    
    public void Print()
    {
        string str = "";
        str += $"===================================\n";
        str += $"이름 : {name}\n";
        str += $"HP : {hp}, MP : {mp}, Power : {power}\n";
        str += $"===================================\n";

        Console.WriteLine(str);
    }
}
```

#### 1. 추상 클래스 (`abstract class Player`)

- `abstract` 키워드가 붙은 클래스는 직접 객체(인스턴스)를 생성할 수 없음. (예 : `new Player(...)` 불가능)
- 자식 클래스(예 : `Warrior`, `Mage` 등)가 이 클래스를 상속받아 완성하도록 유도하는 역할

#### 2. 접근 제한자 (`protected`)

- `protected string name;` 등의 필드는 자기 자신과 상속받은 자식 클래스에서만 접근 가능하게 보호
- 외부에서 함부로 값을 바꾸는 것을 막으면서, 자식 클래스에서는 자유롭게 사용할 수 있도록 설정한 것

#### 3. 생성자 (`public Player(...)`)

- 플레이어가 생성될 때 이름, HP, MP, 공격력(power)을 받아와 내부 필드에 초기화
- 자식 클래스 생성자에서 `base(...)`를 통해 이 생성자를 호출하여 기본 정보들을 초기화

#### 4. 추상 메서드 (`public abstract void Attack(Monster monster);`)

- 본문(몸통 `{}`)이 없는 메서드
- "플레이어라면 공격(`Attack`) 기능이 반드시 있어야 하지만, 직업마다 공격 방식이 다르니 자식 클래스에서 직접 구현하라"는 강제성을 부여
- 자식 클래스에서는 `override` 키워드를 사용해 이 메서드를 구현해야 함.

#### 5. 일반 메서드 (`public void Print()`)

- 추상 클래스라고 해서 추상 메서드만 가질 수 있는 것은 아님. 모든 플레이어가 공통으로 사용하는 일반 메서드도 포함할 수 있음.
- 캐릭터의 현재 상태 정보(이름, HP, MP, 공격력)를 콘솔창에 출력해 주는 역할

## Warrior 클래스

```csharp
class Warrior : Player
{
    public Warrior(string name, int hp, int mp, int power)
        :base(name, hp, mp, power)
    {
        Console.WriteLine("전사 선택!");

        Print();
    }

    public override void Attack(Monster monster)
    {
        if(monster.HP < 1) //실행하지 않을 조건을 먼저 위에 써주고 뒤에 실행하는 내용을 써주는게 좋음 > 보호 구문(Guard Clause) 또는 Early Return 패턴
        {
            Console.WriteLine($"{monster.Name} 사망\n");

            return;
        }

        string str = "";
        str += $"{name}이 {monster.Name}을 검으로 공격\n";
        str += $"{monster.Name}의 HP가 {monster.HP} 남음\n";
        Console.WriteLine(str);
        
    }
}
```

#### 1. 상속과 생성자 연결 (`: base(...)`)

```csharp
public Warrior(string name, int hp, int mp, int power)
    : base(name, hp, mp, power)
```

- `Warrior` 객체를 생성할 때 전달받은 매개변수들을 `base(...)`를 통해 부모 클래스(`Player`)의 생성자로 전달.
- 부모 클래스의 생성자가 먼저 실행되어 `name`, `hp`, `mp`, `power` 필드가 초기화된 후, `Warrior` 생성자 내부 코드(`Console.WriteLine`, `Print()`)가 실행됨.

#### 2. 추상 메서드 오버라이딩 (`public override void Attack(...)`)

- 부모 클래스에서 몸통 없이 선언되었던 `abstract void Attack`을 `override` 키워드를 사용해 전사 전용 공격 로직으로 완성시킴.

## Mage 클래스

```csharp
class Mage : Player
{
    public Mage(string name, int hp, int mp, int power)
        : base(name, hp, mp, power)
    {
        Console.WriteLine("마법사 선택!");

        Print();
    }

    public override void Attack(Monster monster)
    {
        if (monster.HP < 1) //실행하지 않을 조건을 먼저 위에 써주고 뒤에 실행하는 내용을 써주는게 좋음
        {
            Console.WriteLine($"{monster.Name} 사망\n");

            return;
        }

        string str = "";
        str += $"{name}이 {monster.Name}을 파이어볼로 공격\n";
        str += $"{monster.Name}의 HP가 {monster.HP} 남음\n";
        Console.WriteLine(str);
    }
}
```

#### 1. 상속과 부모 생성자 호출 (`: base(...)`)

- `Warrior`와 마찬가지로 `Mage` 생성자 호출 시 `: base(name, hp, mp, power)`를 사용해 부모 클래스인 `Player`의 생성자를 먼저 실행.
- 클래스 내부에서 `Print()`를 호출하여 마법사가 생성됨과 동시에 기본 스탯 정보를 출력.

#### 2. 추상 메서드 오버라이딩과 다형성 (`override void Attack`)

- 같은 `Attack(Monster monster)` 메서드이지만, `Warrior`는 "검으로 공격"이었던 반면 `Mage`는 "파이어볼로 공격"으로 서로 다르게 동작.
- 이처럼 부모 클래스의 같은 메서드 호출 기능만으로 각 직업마다 전혀 다른 동작을 수행하게 만드는 성질을 객체지향 프로그래밍에서 다형성이라고 함.

#### 3. Early Return 패턴 유지

- `Warrior`에서 활용했던 `if (monster.HP < 1) return;` 방식을 동일하게 적용하여 예외 처리 규칙의 일관성을 유지.

## Monster 클래스

```csharp
class Monster
{
    private string name;
    public string Name => name;

    private int hp;
    public int HP => hp;

    public Monster(string name,int hp)
    {
        this.name = name;
        this.hp = hp; 
    }
}
```

#### 1. 캡슐화와 람다식 프로퍼티 (읽기 전용 정보 제공)

```csharp
private string name;
public string Name => name;

private int hp;
public int HP => hp;
```

- 필드 은닉 (`private`) : `name`과 `hp` 변수를 `private`으로 선언하여 외부에서 함부로 몬스터의 이름이나 체력을 직접 수정하지 못하도록 보호.
- 람다식 프로퍼티 (`=>`) : `public string Name => name;` 구문은 `get { return name; }`의 줄임 표현(람다 식 기반 읽기 전용 프로퍼티)
- 이 덕분에 외부(예 : `Warrior.Attack`)에서는 `monster.Name`이나 `monster.HP`로 값을 읽는 것(Read)만 가능, `monster.HP = 0;`처럼 값을 임의로 바꾸는 것(Write)은 불가능

#### 2. 생성자 (`public Monster(...)`)

- 몬스터 객체가 생성될 때 이름과 초기 체력을 받아 내부 필드에 안전하게 설정

## Main

```csharp
private static void Main(string[] args)
{
    Random random = new Random();
    
    Player player;

    Console.WriteLine("직업 선택(1:전사, 2:마법사) : ");
    string input = Console.ReadLine()!;
    int job;
    int.TryParse(input, out job);

    switch (job)
    {
        case 2: player = new Mage("Player", 100, 20, 10); break;

        case 1: //1번케이스에 break가 없으니 1번 케이스랑 디폴트랑 동일하게 실행됨
        default: player = new Warrior("Player", 100, 20, 10); break;
    }

    
    int count = random.Next(5, 10);

    Monster[] monsters = new Monster[count];
    for(int i = 0; i < monsters.Length; i++)
    {
        char rand = (char)random.Next(0xAC00, 0xD7A3 + 1);
        char rand2 = (char)random.Next(0xAC00, 0xD7A3 + 1);
        char rand3 = (char)random.Next(0xAC00, 0xD7A3 + 1);

        string str = $"{rand}{rand2}{rand3}";

        monsters[i] = new Monster(str, random.Next(30, 60 + 1));

        Console.WriteLine($"{i}번 몬스터, {monsters[i].Name}, HP: {monsters[i].HP}");
    }

    while (true)
    {
        Console.WriteLine("공격할 몬스터 번호 :");
        input = Console.ReadLine()!;

        int monster;
        int.TryParse(input, out monster);

        if (monster < 0 || monster >= monsters.Length)
            continue;

        player.Attack(monsters[monster]);
    }
}//Main
```

#### ① 직업 선택 및 객체 생성 (switch문과 다형성)

```csharp
switch (job)
{
    case 2: player = new Mage("Player", 100, 20, 10); break;

    case 1:
    default: player = new Warrior("Player", 100, 20, 10); break;
}
```

- 부모 타입 변수 활용 : `Player player;` 변수 하나 선언 후, 입력값에 따라 `Mage` 또는 `Warrior` 객체를 할당.
- Fall-through 이용 : 주석에 남겨주신 것처럼 `case 1:`에 `break;`가 없기 때문에 1번을 누르거나, 잘못된 번호(default)를 입력해도 기본값으로 `Warrior`가 생성되도록 처리.

#### ② 유니코드 범위(`0xAC00 ~ 0xD7A3`)를 이용한 한글 이름 난수 생성

```csharp
char rand = (char)random.Next(0xAC00, 0xD7A3 + 1);
```

- `0xAC00`는 한글 완성형 십육진수 유니코드의 시작인 '가', `0xD7A3`는 끝인 '힣'을 의미.
- 무작위로 한글 글자 3개를 뽑아 `str`로 묶어줌으로써 "가나다", "밠훽믗" 같은 임의의 한글 3글자 이름 몬스터를 자동으로 생성해 내는 재밌는 아이디어가 적용.

#### ③ 인덱스 예외 방지 (Early Continue)

```csharp
if (monster < 0 || monster >= monsters.Length)
    continue;
```

- 배열 크기를 벗어나는 번호를 입력했을 때 발생할 수 있는 `IndexOutOfRangeException` 에러를 사전에 방지.
- 유효하지 않은 입력인 경우 `continue`를 통해 아래 공격 로직을 실행하지 않고 곧바로 다시 숫자를 입력받도록 처리.