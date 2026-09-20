# [C32_Virtual](../CsharpStudy_List.md)

```csharp
/*Character Class*/
public virtual void Attack() //재정의하기 위한 virtual
{
    Console.WriteLine($"Charcater : {name}, Power : {power}");
}

/*Monster Class*/
public new void Attack() //new로 부모 가리기, 자동할당 > 그냥 부모 쪽으로 가버림  ///생략은 부모 함수 사용, 동적 할당
{
    Console.WriteLine($"Monster : {Name}, Power : {Power}");
}

/*Player Class*/
public override void Attack() //부모의 어택함수 재정의
{
    Console.WriteLine($"Player : {Name}, Power : {Power}");
}
```

```csharp
characters[0] = new Player("Player1", 100); //플레이어의 어택 함수 호출됨
characters[1] = new Monster("Oak", 50); //캐릭터의 어택 함수 호출됨
```

### 1. Character 클래스(부모)

```csharp
class Character
{
    public virtual void Attack()
    {
        Console.WriteLine($"Charcater : {name}, Power : {power}");
    }
}
```

- `virtual` 키워드 : 자식 클래스가 원한다면 이 메서드를 override 하여 자신만의 동작으로 바꿀 수 있도록 허용.

//가상 함수만 재정의가 가능함
//가상 함수를 재정의해서 사용하는 것 : 가상화, 동적 할당일때만 일어남

### 2. Monster 클래스(new-메서드 숨기기)

```csharp
class Monster : Character
{
    public new void Attack() //부모의 어택을 숨기는 어택
    {
        Console.WriteLine($"Monster : {Name}, Power : {Power}");
    }
}
```

- `new` 키워드 : 부모의 `virtual`을 이어받기 x, 부모의 `Attack()`과 이름만 같은 완전히 새로운 메서드
- 부모 타입으로 참조할 경우 부모의 `Attack()`이 호출, `Monster` 변수로 참조할 경우에만 `Monster`의 `Attack()`이 호출

### Player 클래스(override - 메서드 재정의)

```csharp
class Player : Character
{
    public override void Attack() //부모의 어택을 재정의하는 어택
    {
        Console.WriteLine($"Player : {Name}, Power : {Power}");
    }
}
```

- override 키워드 : 부모의 virtual Attack()을 완전히 덮어써서 객체의 진짜 타입(Player)에 맞게 동작