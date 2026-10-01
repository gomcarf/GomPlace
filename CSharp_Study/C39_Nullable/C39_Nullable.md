# [C39_Nullable](../CsharpStudy_List.md)

- Nullable 타입(`int?`, `string?`), 널 병합 연산자(`??`), `is` 연산자와 상속 관계, null 비교 규칙을 보여주는 예제

```csharp
class Program
{
    class Character { }
    class Player : Character { }
    class Monster : Character {}

    private static void Main(string[] args)
    {
        //reference 타입 - Nullable

        //value type - Nullable(x)
        //int a = 0;
        //if(a != null)
        //{

        //}

        int? a = null; //Nullable Value type(Null 값이 들어갈 수 있음)
        if (a.HasValue)//a가 값을 가지고 있는지 판단해서 반환하는 프로퍼티
            Console.WriteLine("a값 있음");
        else
            Console.WriteLine($"a값 없음 : {a}");

        int? b = 10;
        if (b.HasValue)
            Console.WriteLine($"b값 있음 : {b}");
        else
            Console.WriteLine($"b값 없음 : {b}");

        int? c = 20;
        int d = c.Value; //c에 값이 있기 때문에 문제 없이 대입됨. 하지만 null일 경우를 대비하여 널 병합 연산자 사용 필수**꼭 기억해**
        Console.WriteLine($"d값 : {d}");

        int? e = null;
        int f = e ?? -1;//null이 아니면 그냥 값이 나오고, null이면 뒤의 숫자가 출력됨
        Console.WriteLine($"f값 : {f}");

        //reference type - string(//널 포용 연산자)        
        string? str = null; //Nullable reference type
        
        if(str != null)//is not null
            Console.WriteLine($"str값 있음 : {str}");
        else
            Console.WriteLine($"str값 없음 : {str}");

        //Console.Write("문자열 입력 : ");
        //string str3 = Console.ReadLine()!;//null 허용 연산자: null이어도 받아줘라
        //Console.WriteLine($"str3 : {str3}");

        int? g = null; //ref 타입
        int h = 10; //Value 타입
        g = h; //Value -> Reference : Boxing**(여러 처리를 하고 메모리 공간을 마련해줘야 하기 때문에 느린 연산)
        int i = g.Value; //Reference -> Value : Unboxing**(삭제하고 되돌리기만 하면 되지만 일반적인 대입 치고는 느린 연산)
        int j = (int)g; //Unboxing
        //일상 최적화 1: 박싱/언박싱을 최소화해야함(Nullable도 최소화로 사용하는 게 좋음)***

        int? k = null;
        //int l = (int)k++; //값이 할당되었을 때만 가능한 연산

        //is 연산자: 해당 자료형으로 변환이 가능하느냐(ref 타입)
        int? m = 0;
        Console.WriteLine($"m : {m is int}"); //결과: True
        Console.WriteLine($"m : {m is int?}"); //결과: True

        Player player = new Player();
        Console.WriteLine($"player : {player is Character}"); //결과: True

        Monster monster = new Monster();
        Console.WriteLine($"monster : {monster is Character}");//결과: True

        Character character = (Character)player;
        Console.WriteLine($"character -> Player : {character is Player}");//결과: True
        Console.WriteLine($"character -> Monster : {character is Monster}");//결과: False

        int? n = 10;
        int? o = null;
        Console.WriteLine($"n >= null : {n >= null}"); //false, 비교불가
        Console.WriteLine($"n == null : {n == null}"); //false
        Console.WriteLine($"n != null : {n != null}"); //true

        Console.WriteLine($"o >= null : {o >= null}"); //false, 비교불가
        Console.WriteLine($"o == null : {o == null}"); //True

        int? p = 10;
        Console.WriteLine(p is int); //True p는 int?이지만 값이 할당되어 있으므로 int로 변환 가능
        Console.WriteLine(p is int?); //true p는 int?이므로 int?로 변환 가능

        int? q = null;
        Console.WriteLine(q is int); //False q은 int?이지만 값이 할당되어 있지 않으므로 int로 변환 불가능
        Console.WriteLine(q is int?); //false q는 null이므로 int?로 변환 불가(null은 어떤 값 타입의 인스턴스도 아니기 때문)
    }
}
```

### 중첩 클래스

```csharp
class Character { }
class Player : Character { }
class Monster : Character { }
```

- `Player`와 `Monster`는 `Character`를 상속하며, `is` 연산자 테스트에 쓰임

### Nullable 값 타입(`int?`)

- `int`는 값 타입이라 원래 null을 가질 수 없음. `int?`는 `Nullable<int>`의 축약형으로, 값 + 값이 있는 지 여부(bool)를 함께 담는 구조체

```csharp
int? a = null;
if (a.HasValue) ...   // 값이 있으면 true
```

- `a`는 null이라 "a값 없음"이 출력. null을 문자열 보간하면 빈 문자열이 되므로 `a값 없음 :` 으로 나옴
- `b`는 10이라 `b값 있음 : 10`이 출력

### `.Value`와 `??`

```csharp
int? c = 20;
int d = c.Value;      // 값이 있으니 OK
```

- `.Value`는 값이 없으면 `InvalidOperationException`을 던짐. 그래서 주석처럼 null 가능성이 있다면 `??`를 쓰는 것이 안전

```csharp
int? e = null;
int f = e ?? -1;      // e가 null이면 -1 → f = -1
```

- `GetValueOrDefault()`도 비슷한 역할을 합니다(null이면 0 또는 지정한 기본값)

### Nullable 참조 타입 (`string?`)

```csharp
string? str = null;
if (str != null) ...
```

- `string`은 원래 참조 타입이라 항상 null이 가능
- C# 8의 `string?`는 이 변수는 null일 수 있다는 컴파일러용 표시일 뿐, 런타임에 달라지는 것은 없음. null 가능성이 있는 곳에서 검사를 빼먹으면 컴파일러가 경고를 띄워 줌
- `int?`는 실제로 다른 타입(`Nullable<int>`)이고, `string?`는 같은 `string`에 붙는 주석 같은 것

#### 박싱/언박싱 부분

```csharp
int? g = null; //ref 타입
int h = 10;
g = h;          // "Value -> Reference: Boxing"
int i = g.Value; // "Unboxing"
int j = (int)g;  // "Unboxing"
```

- `int?`는 참조 타입이 아니라 값 타입(struct). 힙 할당 없이 변수 안에 값이 그대로 들어감.
- `g = h;`는 박싱이 아니라 암시적 변환(int를 `int?`로 감싸기)입니다. 싸고 빠른 연산.
- `g.Value`는 구조체 안의 필드를 읽는 것이고, `(int)g`는 명시적 변환. 둘 다 언박싱이 아니며, g가 null이면 `InvalidOperationException`이 발생.
- 박싱은 값 타입을 `object`나 인터페이스로 바꿀 때 일어남

```csharp
object o = h;        // 박싱 (힙에 복사본 생성)
int x = (int)o;      // 언박싱
```

- 박싱/언박싱을 줄여야 한다는 최적화 원칙. 다만 `Nullable`을 쓴다고 박싱이 생기는 것은 아니며, `List<object>`나 `ArrayList`에 값 타입을 넣는 경우에 주로 문제가 됨. (`int?`를 `object`에 넣을 때는 값이 있으면 int로 박싱되고, null이면 그냥 null 참조가 됨.)

#### 주석 처리된 `k++`

```csharp
int? k = null;
//int l = (int)k++;
```

- `k++` 자체는 컴파일도 되고 예외도 없음. Nullable에서는 연산자가 null을 만나면 결과도 null이 됨(lifted operator). 예외가 나는 곳은 `(int)` 캐스트인데, null을 int로 바꾸려 해서 `InvalidOperationException`이 발생함.

### `is` 연산자

#### 상속 관계

```csharp
Player player = new Player();
player is Character      // True  (Player는 Character의 자식)
monster is Character     // True

Character character = (Character)player;   // 업캐스팅
character is Player      // True  (변수 타입은 Character지만 실제 객체가 Player)
character is Monster     // False
```

- `is`가 변수의 선언 타입이 아니라 실제 객체의 타입을 검사

#### Nullable과 `is`

| 변수 | `is int` | `is int?` |
| --- | --- | --- |
| `m = 0` | True | True |
| `p = 10` | True | True |
| `q = null` | **False** | **False** |
- `x is int?`는 사실상 null이 아니다와 같은 의미. null은 어떤 타입의 인스턴스도 아니므로 `int?`로 검사해도 False.

### null  비교

```csharp
int? n = 10;
int? o = null;
n >= null   // False
n == null   // False
n != null   // True
o >= null   // False
o == null   // True
```

- Nullable의 대소 비교(`<`, `>`, `<=`, `>=`)는 한쪽이라도 null이면 항상 false
- `==`와 `!=`만 null 여부를 의미있게 비교. 그래서 `o >= null`이 `o`가 null이러도 false

### 정리

- `int?`는 값 타입 구조체이고, `string?`는 컴파일러 힌트.
- null 가능성이 있을 때는 `.Value`보다 `??`나 `HasValue` 검사 사용.
- 박싱은 `object`로 변환할 때 발생하며, `int` → `int?` 대입은 박싱이 아님.
- `is`는 실제 객체의 타입을 검사