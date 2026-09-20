# [C31_Overriding](../CsharpStudy_List.md)

## 오버라이딩(Overriding)

- 상속 관계(부모-자식 클래스)에서 부모 클래스로부터 물려받은 메서드의 내부 동작(구현부)을 자식 클래스에서 재정의하여 사용하는 것
- 특징
    - 메서드의 이름, 매개변수, 리턴 타입이 부모 클래스와 완전히 동일
    - 자식클래스 객체에서 해당 메서드를  호출하면 부모의 메서드가 아닌 재정의된 자식의 메서드가 우선 호출
    - 실행 시점에 객체 타입에 따라 어떤 메서드가 호출될지 결정되므로 동적 다형성이라고 함

```csharp
class Character
{
    public virtual void Attack()
    {
        Console.WriteLine("기본 공격");
    }
}

class Monster : Character
{
    public new void Attack() //부모의 어택을 숨기는 어택
    {
        Console.WriteLine("몬스터 공격");
    }
}

class Player : Character
{
    public override void Attack() //부모의 어택을 재정의하는 어택
    {
        //base.Attack();

        Console.WriteLine("플레이어 공격");
    }
}
```

### 1. Character 클래스(부모)

```csharp
class Character
{
    public virtual void Attack()
    {
        Console.WriteLine("기본 공격");
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
        Console.WriteLine("몬스터 공격");
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
        //base.Attack();

        Console.WriteLine("플레이어 공격");
    }
}
```

- override 키워드 : 부모의 virtual Attack()을 완전히 덮어써서 객체의 진짜 타입(Player)에 맞게 동작

### new 와 override 차이

```csharp
Character c1 = new Monster(); // 부모 타입 변수로 Monster 참조
Character c2 = new Player();  // 부모 타입 변수로 Player 참조

c1.Attack(); // 출력: "기본 공격"  (new는 부모 타입을 따라감)
c2.Attack(); // 출력: "플레이어 공격" (override는 실제 객체 타입을 따라감)
```

# 할당 방식과 메모리의 관계

소스(cs) → 인터프리터:한줄씩 번역(컴파일러:통으로 번역:c++) //자동할당 → 실행파일(exe) : 동적할당 → 프로세스 → pcb

### 할당방식

1. 자동 : 스택 내에 저장, **컴파일 시점**에 (프로세스 내의) 메모리 주소가 결정됨 , 값형식, 크기가  변하지 않음
2. 정적
3. 동적 : `new` 키워드, 참조형식, 힙 영역에 저장, **런타임 시점**에 메모리 주소가 결정됨, 크기 가변