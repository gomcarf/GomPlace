# [C37_Static](../CsharpStudy_List.md)

## 인스턴스 vs 정적(Static)

- 인스턴스 멤버(`number`, `Print()` 등)
    - `new Monster()` 객체를 만들 때마다 각 객체(메모리)마다 개별적으로 생성
    - 몬스터 A의 `number`와 몬스터 B의 `number`는 서로 다른 값을 가짐
- 정적 멤버(`count`, `PrintCount()` 등)
    - 객체를 몇 개 만들든 상관없이 프로그램 전체에서 딱 1개만 존재하며 모든 몬스터가 공유
    - 데이터 영역(Static Area) 메모리에 할당됨.

## Monster 클래스

```csharp
class Monster
{
    private int number;
    public int Number => number;

    private static int count;

    public Monster()
    {
        Console.WriteLine($"Monster 생성자 : {number}");

        number = ++count;
    }

    public void Print()
    {
        Console.WriteLine($"Monster : {number}, {count}");
    }

    public static void PrintCount()
    {
        //Console.WriteLine($"Monster Static : {number}, {count}"); //static 함수는 static 변수나 함수만 참조 가능**
        Console.WriteLine($"Monster Static : {count}");

        //Print(); //스태틱 함수가 아니므로 접근 불가
        PrintStatic();
    }

    public static void PrintStatic()
    {
        Console.WriteLine("static은 static 영역만 접근 가능");
    }
}
```

### 1. 고유 번호 부여와 자동 카운팅

```csharp
private int number; //인스턴스 변수(개별 몬스터의 고유 번호)
public int Number => number;

private static int count;//정적 변수(생성된 총 몬스터 수, 공유됨)

public Monster()
{
    Console.WriteLine($"Monster 생성자 : {number}");//초기값 0 출력
    number = ++count;//전체 카운트를 1 증가시키고 내 번호로 지정
}
```

- `Monster m1 = new Monster();` 호출 시
    - `count`가 1이 되고, `m1.number`는 1
- `Monster m2 = new Monster();` 호출 시
    - `count`가 2가 되고, `m2.number`는 2
- 생성자 출력 : C#에서 `int` 타입의 기본값은 `0`이므로, 생성자 실행 직후 `Console.WriteLine`에는 `number`가 지정되기 전 값인 `0`이 출력

### 2. 접근 권한과 영역 규칙

#### 1) 일반 메서드(`Print`)

```csharp
public void Print()
{
    Console.WriteLine($"Monster : {number}, {count}");
}
```

- 인스턴스 메서드는 자신의 개별 데이터(`number`)와 공유 데이터(`count`) 둘 다 자유롭게 접근 가능

#### 2) 정적 메서드(`PrintCount`, `PrintStatic`)

```csharp
public static void PrintCount()
{
    // Console.WriteLine($"Monster Static : {number}, {count}"); // 에러!
    Console.WriteLine($"Monster Static : {count}");

    // Print(); // 에러!
    PrintStatic();
}
```

- `PrintCount()`는 객체를 생성하지 않고도 `Monster.PrintCount()` 형태로 호출할 수 있는 `static` 메서드
- 따라서 호출되는 시점에 **"**어떤 몬스터 객체의 `number`나 `Print()`를 뜻하는지" 알 수 없기 때문에 정적 메서드 내부에서는 인스턴스 멤버(`number`, `Print()`)에 접근 불가.
- 오직 `static`이 붙은 변수(`count`)나 메서드(`PrintStatic()`)만 참조 가능

## Main 함수

```csharp
private static void Main(string[] args)
{
    Monster[] monsters = new Monster[5];

    for(int i =0; i< monsters.Length; i++)
    {
        monsters[i] = new Monster();
        Console.WriteLine($"Monster {monsters[i].Number} 생성");
    }

    foreach(Monster monster in monsters)
    {
        monster.Print();
    }

    Monster.PrintCount();

}//Main
```

### 1. 코드 실행 흐름 및 상세 설명

#### 1) `Monster[] monsters = new Monster[5];`

- `Monster` 객체를 참조할 수 있는 공간 5개짜리 배열을 생성
- 이 시점에서는 배열의 빈 공간만 만들어진 상태이며, `Monster` 객체가 실제로 생성된 것은 아님. (모든 요소는 `null` 상태)

#### 2) `for`문(객체 생성 및 고유 번호 할당)

```csharp
for(int i = 0; i < monsters.Length; i++)
{
    monsters[i] = new Monster();
    Console.WriteLine($"Monster {monsters[i].Number} 생성");
}
```

- `new Monster()`가 호출될 때마다 생성자가 실행
- 생성자 내부 동작
    1. `number = ++count;`에 의해 static 변수인 `count`가 1씩 증가
    2. 증가한 `count` 값이 각 몬스터 객체의 고유 인스턴스 변수인 `number`에 저장
- 이 과정을 5번 반복하면서 1번부터 5번까지의 몬스터가 차례대로 생성되고, `Number` 프로퍼티를 통해 부여된 고유 번호를 출력

#### 3) `foreach`문(개별 객체 정보 출력)

```csharp
foreach(Monster monster in monsters)
{
    monster.Print();
}
```

- 배열에 저장된 5개의 `Monster` 객체를 하나씩 순회하며 인스턴스 메서드인 `Print()`를 호출
- `Print()` 내부에서는 각 몬스터의 개별 고유 번호(`number`)와 현재 총 몬스터 수(`count`)를 함께 출력
- 5개의 몬스터 모두 완성이 끝난 상태이므로, 공유 데이터인 `count`는 5개 모두 동일하게 `5`로 출력

#### 4) Monster.PrintCount(); (클래스 차원의 총개수 출력)

- 개별 인스턴스(`monsters[i]`)를 거치지 않고, `Monster` 클래스 이름을 직접 사용하여 정적 메서드를 호출
- 객체 생성 없이 클래스 차원에서 전체 몬스터 수(`count = 5`)를 출력하고 `PrintStatic()`을 호출

## 출력

```
Monster 생성자 : 0
Monster 1 생성
Monster 생성자 : 0
Monster 2 생성
Monster 생성자 : 0
Monster 3 생성
Monster 생성자 : 0
Monster 4 생성
Monster 생성자 : 0
Monster 5 생성
Monster : 1, 5
Monster : 2, 5
Monster : 3, 5
Monster : 4, 5
Monster : 5, 5
Monster Static : 5
static은 static 영역만 접근 가능
```