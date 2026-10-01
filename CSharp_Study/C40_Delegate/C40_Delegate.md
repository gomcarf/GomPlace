# C40_Delegate

## Player 클래스

- delegate를 사용해 `Player`가 행동(공격, 스킬, 아이템)을 할 때 외부에서 등록한 함수를 대신 호출하는 구조를 보여줌.
- 델리게이트는 함수를 담는 변수라고 생각하면 됨

```csharp
using System;

class Player
{
    private int hp;
    private int attack;

    public override string ToString()
    {
        return $"Player HP: {hp}, Attack: {attack}";
    }

    public delegate void AttackDelegate(int number, int damage);
    
    public AttackDelegate OnAttack;
    public AttackDelegate OnSkill;
    public Action<int, int> OnItem;

    public Player(int hp, int attack)
    {
        this.hp = hp;
        this.attack = attack;
    }

    public void Attack(int number)
    {
        if(OnAttack != null)
            OnAttack.Invoke(number, attack);
    }

    public void Skill(int number)
    {
        //if (OnSkill != null)
            OnSkill?.Invoke(number, attack);
    }

    public void Item(int number)
    {
        if (OnItem != null)
            OnItem(number, attack);
    }
}
```

### 델리게이트 선언

```csharp
public delegate void AttackDelegate(int number, int damage);
```

- 반환값이 void이고 int 두 개를 받는 함수의 형태(시그니처)를 정의한 타입
- 이 형태에 맞는 함수라면 어떤 것이든 AttackDelegate 변수에 담을 수 있음
- Player 클래스 안에 선언했으므로 바깥에서는 Player.AttackDelegate로 접근

### 델리게이트 필드

```csharp
public AttackDelegate OnAttack;
public AttackDelegate OnSkill;
public Action<int, int> OnItem;
```

- `OnAttack`, `OnSkill`은 직접 선언한 `AttackDelegate` 타입
- `OnItem`은 .NET이 미리 제공하는 `Action<int, int>` 타입으로 `void(int, int)` 형태의 함수를 담음. 위의 `AttackDelegate`와 같은 형태이지만 별도로 선언할 필요 없음. 반환값이 있다면 `Func<>`를 씀.
- 실무에서는 델리게이트를 직접 선언하기보다 `Action`/`Func`를 쓰는 경우가 많음. 다만 두 타입은 시그니처가 같아도 서로 다른 타입이라 직접 대입할 수 없음.
- 초기값이 없으므로 아무것도 등록하지 않으면 null

### 생성자와 ToString

```csharp
public Player(int hp, int attack) { this.hp = hp; this.attack = attack; }
public override string ToString() => $"Player HP: {hp}, Attack: {attack}";
```

- `this.hp`는 매개변수 `hp`와 필드 `hp`의 이름이 같아서 필드를 구분하기 위해 사용. `ToString()`을 재정의했으므로 `Console.WriteLine(player)`처럼 출력할 수 있음.

### 세 가지 호출 방식

```csharp
public void Attack(int number)
{
    if (OnAttack != null)
        OnAttack.Invoke(number, attack);
}

public void Skill(int number)
{
    OnSkill?.Invoke(number, attack);
}

public void Item(int number)
{
    if (OnItem != null)
        OnItem(number, attack);
}
```

| 메서드 | 방식 | 설명 |
| --- | --- | --- |
| `Attack` | `if (!= null)` + `Invoke()` | 가장 풀어 쓴 형태 |
| `Skill` | `?.Invoke()` | null이면 아무것도 안 하는 null 조건 연산자. 위와 동일하지만 한 줄 |
| `Item` | `if (!= null)` + `OnItem(...)` | `Invoke`를 생략하고 함수처럼 바로 호출 |
- 결과는 모두 같음
- 등록된 함수가 없을 때 호출하면 `NullReferenceException`이 나므로 null 검사는 필수.
- 일반적으로 `?.Invoke()`가 가장 간결하고 많이 쓰임
- 멀티스레드 환경에서 검사 직후 null로 바뀌는 문제도 막아줌

### 사용 예시

```csharp
Player player = new Player(100, 10);

player.OnAttack += (number, damage) => Console.WriteLine($"{number}번 몬스터를 {damage} 데미지로 공격");
player.OnAttack += (number, damage) => Console.WriteLine("공격 효과음 재생");

player.Attack(1);
player.Skill(2);   // 등록된 게 없으므로 아무 일도 없음
```

- `+=`로 함수를 여러 개 등록할 수 있고(멀티캐스트), 호출하면 등록한 순서대로 모두 실행
- `=`로 등록을 해제
- `Player`는 누가 구독했는지 몰라도 되고, 알림만 보냄. 그래서 UI, 사운드, 이펙트 같은 기능을 `Player` 코드 수정 없이 연결 가능

### 개선 포인트

#### `event` 키워드

- 필드가 `public`이면 외부에서 이런 일이 가능

```csharp
player.OnAttack = null;                 // 다른 구독자까지 전부 지워짐
player.OnAttack.Invoke(1, 9999);        // Player 밖에서 마음대로 호출
```

- `event`를 붙이면 바깥에서는 `+=`, `-=`만 가능하고, 호출은 `Player` 내부에서만 가능

```csharp
public event AttackDelegate? OnAttack;
```

#### Nullable 경고

- 프로젝트에서 nullable 참조 타입이 켜져 있다(<Nullable>enable</Nullable>) 초기화되지 않은 필드에 경고가 뜸. null일 수 있다는 것을 명시

```csharp
public AttackDelegate? OnAttack;
public Action<int, int>? OnItem;
```

### 정리

- 델리게이트는 함수를 변수처럼 저장하고 전달하는 타입이며, `Action`/`Func`는 미리 만들어진 델리게이트.
- 호출 전에 null 검사가 필요하고, `?.Invoke()`가 가장 간결.
- `+=`로 여러 함수를 등록할 수 있고, 외부에서 함부로 덮어쓰지 못하게 하려면 `event`를 사용함.

## Main

- 일반 메서드를 델리게이트에 `+=`로 등록하고, 콘솔 입력에 따라 `Player`가 행동할 때 등록된 함수들이 자동으로 호출되는 흐름을 보여줌

```csharp
class Program
{
    private static void PlayerAttack(int number, int damage)
    {
        Console.WriteLine($"Player Attack : {number}, {damage}");
    }

    private static void PlayerAttack2(int number, int damage)
    {
        Console.WriteLine($"Player Attack2 : {number}, {damage}");
    }

    private static void SkillAttack(int number, int damage)
    {
        Console.WriteLine($"Skill Attack : {number}, {damage}");
    }

    private static void ItemAttack(int number, int damage)
    {
        Console.WriteLine($"Item Attack : {number}, {damage}");
    }

    private static void Main(string[] args)
    {
        Player player = new Player(100, 10);
        player.OnAttack += PlayerAttack;
        player.OnAttack += PlayerAttack2;

        player.OnSkill += SkillAttack;

        player.OnItem += ItemAttack;
        player.OnItem += PlayerAttack;

        while (true)
        {
            Console.Write("입력 : ");
            string input = Console.ReadLine()!;

            int command;
            int.TryParse(input, out command);

            if (command == 1)
            {
                player.Attack(1);
            }
            else if (command == 2)
            {
                player.Skill(1);
            }
            else if (command == 3)
            {
                player.Item(1);
            }
            else if(command == 4)
            {
                if(player.OnSkill != null)
                    player.OnSkill -= SkillAttack;
            }
            else
                break;
        }
    }
}
```

### 핸들러 메서드

```csharp
private static void PlayerAttack(int number, int damage)
private static void PlayerAttack2(int number, int damage)
private static void SkillAttack(int number, int damage)
private static void ItemAttack(int number, int damage)
```

- `void (int, int)` 형태로, `AttackDelegate`와 `Action<int, int>`의 시그니처와 일치함. 그래서 델리게이트에 등록 가능. 내용은 각자 이름과 받은 값을 출력하는 것.

### 함수 등록

```csharp
Player player = new Player(100, 10);
player.OnAttack += PlayerAttack;
player.OnAttack += PlayerAttack2;

player.OnSkill += SkillAttack;

player.OnItem += ItemAttack;
player.OnItem += PlayerAttack;
```

| 델리게이트 | 등록된 함수 (순서대로) |
| --- | --- |
| `OnAttack` | `PlayerAttack` → `PlayerAttack2` |
| `OnSkill` | `SkillAttack` |
| `OnItem` | `ItemAttack` → `PlayerAttack` |
- 처음 `+=`를 할 때 델리게이트가 null이면 새로 만들어지고, 이후 `+=`는 목록에 추가
- `OnItem`에는 이름이 `Attack`인 `PlayerAttack`이 등록되어 있음. 시그니처만 맞으면 용도와 상관없이 어떤 함수든 등록할 수 있기 때문.

### 입력 루프

```csharp
while (true)
{
    Console.Write("입력 : ");
    string input = Console.ReadLine()!;

    int command;
    int.TryParse(input, out command);
    ...
}
```

- 무한 루프에서 입력을 받아 숫자로 변환
- `TryParse`가 실패하면 `command`는 0이 되므로, 숫자가 아닌 입력은 맨 아래 `else`로 가서 종료

### 명령별 동작

#### `player.Attack(1)`

- `OnAttack`에 등록된 함수가 등록한 순서대로 실행됨

```csharp
Player Attack : 1, 10
Player Attack2 : 1, 10
```

- 10은 Player 생성 시 넘긴 attack 값

#### player.Skill(1)

```csharp
Item Attack : 1, 10
Player Attack : 1, 10
```

- `ItemAttack` → `PlayerAttack` 순으로 호출됨

#### 스킬 핸들러 해제

```csharp
if (player.OnSkill != null)
    player.OnSkill -= SkillAttack;
```

- `=`로 `SkillAttack`을 목록에서 제외. 하나뿐이었으므로 빼면 델리게이트가 null이 됨
- 외부에서 `player.OnSkill`에 직접 접근할 수 있는 것은 필드가 `public`이고 `event`가 아니기 때문
- 여기서 null 검사는 사실 필요 없음. null인 델리게이트에 `=`를 해도 예외 없이 그냥 null로 남음. 같은 함수를 이미 해제한 뒤 다시 4번을 눌러도 안전함.

#### 그 외 입력

- 0, 5 이상, 문자 등은 `break`로 루프를 빠져나가 프로그램이 종료

### 실행 예시

```csharp
입력 : 1
Player Attack : 1, 10
Player Attack2 : 1, 10
입력 : 2
Skill Attack : 1, 10
입력 : 4
입력 : 2
입력 : 3
Item Attack : 1, 10
Player Attack : 1, 10
입력 : q
```

### 짚어볼 점

- 구독자를 모르는 구조 : `Player`는 누가 등록했는지 모른 채 `Invoke`만 하고, 연결은 `Main`에서 함. 이것이 델리게이트(옵저버 패턴)의 장점.
- 같은 함수 중복 등록 : `player.OnAttack += PlayerAttack;`를 두 번 하면 두 번 호출됨. `=`는 가장 나중에 등록된 하나만 제거.
- `event` 사용 시 4번 코드 : `Player`에서 `event`로 바꾸면 `player.OnSkill != null`처럼 외부에서 null을 검사하는 코드는 컴파일 오류. `+=`와 `=`는 그대로 쓸 수 있으므로 null 검사만 빼면 됨.
- 번호 `1`의 의미 : `Attack(1)`의 `1`은 단순한 인자일 뿐이고, 명령 번호(1, 2, 3)와는 별개.

### 정리

- 일반 메서드를 `+=`로 델리게이트에 등록하면, `Player`가 `Invoke`할 때 등록 순서대로 실행
- `=`로 등록을 해제하며, 모두 해제하면 델리게이트는 null이 됨
- 이 구조 덕분에 `Player`는 UI, 사운드, 이펙트 등을 몰라도 알림만 보내면 됨