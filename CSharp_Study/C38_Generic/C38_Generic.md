# C38_Generic

## Stack.cs

- 배열 기반의 제네릭 스택 자료구조를 C#으로 구현한 것.

```csharp
using System.Diagnostics;

class Stack<DataType>
{
    private DataType[] datas; //카멜 표기법
    private int top = -1;
    
    public const int DefaultSize = 5;
    public readonly int MaxSize;

    public Stack(int maxSize = DefaultSize)
    {
        MaxSize = maxSize;
        datas = new DataType[MaxSize];
    }

    public void Push(DataType data)
    {
        if (IsFull())
        {
            Console.WriteLine("스택이 꽉 참");

            return;
        }

        datas[++top] = data;
    }

    public DataType Pop()
    {
        if (IsEmpty())
        {
            //Console.WriteLine("스택이 비워져 있음.");
            //return default(DataType)!; //default는 초기값 반환

            Debug.Assert(false, "스택이 비워져 있음.");
        }

        return datas[top--];
    }

    public bool IsFull()
    {
        return top >= MaxSize - 1;
    }

    public bool IsEmpty()
    {
        return top < 0;
    }
}

```

### 클래스 선언

```csharp
class Stack<DataType>
```

- <DataType>은 제네릭 타입 매개변수
- `Stack<int>`, `Stack<string>`처럼 어떤 자료형이든 담을 수 있는 스택을 하나의 코드로 만들 수 있음.

### 필드

```csharp
private DataType[] datas;       // 실제 데이터를 저장하는 배열
private int top = -1;           // 가장 위 요소의 인덱스 (-1은 비어 있음)

public const int DefaultSize = 5;   // 기본 크기 (컴파일 타임 상수)
public readonly int MaxSize;        // 최대 크기 (생성자에서만 대입 가능)
```

- `top` : 스택의 맨 위 데이터가 있는 위치. 아무것도 없으면 -1
- `const` : 컴파일 시점에 값이 고정되고, `readonly`는 선언 시 또는 생성자에서 한 번만 값을 정할 수 있음.

### 생성자

```csharp
public Stack(int maxSize = DefaultSize)
{
    MaxSize = maxSize;
    datas = new DataType[MaxSize];
}
```

- 매개 변수를 생략하면 기본값 5로 배열을 만듦. `new Stack<int>()`는 크기 5, `new Stack<int>(10)`은 크기 10

### Push(삽입)

```csharp
public void Push(DataType data)
{
    if (IsFull()) { Console.WriteLine("스택이 꽉 참"); return; }
    datas[++top] = data;
}
```

- 가득 찼는지 먼저 확인하고, 아니라면 `top`을 먼저 1 증가시킨 뒤 그 위치에 데이터를 삽입.

### Pop(꺼내기)

```csharp
public DataType Pop()
{
    if (IsEmpty())
    {
        Debug.Assert(false, "스택이 비워져 있음.");
    }
    return datas[top--];
}
```

- `datas[top--]`는 현재 top위치의 값을 반환한 뒤 top을 1 감소(후위 감소)
- 주석 처리된 부분은 비어 있을 때 `default`(int는 0, 참조형은 null)를 반환하는 대안. 실제 코드는 `Debug.Assert`를 사용

### IsFull/IsEmpty

```csharp
public bool IsFull()  => top >= MaxSize - 1;  // 마지막 인덱스에 도달했는가
public bool IsEmpty() => top < 0;             // 아무것도 없는가
```

## Main.cs

- `Stack<DataType>`을 실제로 사용하는 예제로, `const`와 `readonly`의 차이, 제네릭 메서드, 스택 사용과 오버플로/언더플로 상황을 보여줌

```csharp
using System.Collections.Generic;
using System.Runtime.InteropServices;

class User
{
    public const int MaxSize = 10; //초기화 시점에 값이 정해지며, 변경 불가
    public readonly int MaxSize2;
    public readonly int MaxSize3;

    public User()
    {
        MaxSize2 = 20; //생성자에서 초기화 가능, 이후로는 변경 불가
    }

    public User(int maxSize3)
    {
        MaxSize3 = maxSize3; //생성자에서 초기화 가능, 이후로는 변경 불가
    }
}

class Program
{
    //private static void Swap(ref int a, ref int b)
    //{
    //    int temp = a;
    //    a = b;
    //    b = temp;
    //}

    //private static void Swap(ref string a, ref string b)
    //{
    //    string temp = a;
    //    a = b;
    //    b = temp;
    //}

    private static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    private static void Main(string[] args)
    {
        //List<int> list = new List<int>(); //<int> 부분이 제네릭 부분

        int a = 10, b = 20;
        Swap<int>(ref a, ref b);
        Console.WriteLine($"a : {a}, b : {b}");

        string c = "aaa", d = "bbb";
        Swap<string>(ref c, ref d);
        Console.WriteLine($"c : {c}, d : {d}");

        User user1 = new User();
        Console.WriteLine($"MaxSize : {User.MaxSize}, MaxSize2 : {user1.MaxSize2}, MaxSize3 : {user1.MaxSize3}");

        Console.Write("전체 크기 : ");
        string str = Console.ReadLine()!;

        int.TryParse(str, out int size);
        User user2 = new User(size);
        Console.WriteLine($"MaxSize : {User.MaxSize}, MaxSize2 : {user2.MaxSize2}, MaxSize3 : {user2.MaxSize3}");

        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < 5; i++)
            stack.Push(i);

        while (stack.IsEmpty() == false)
            Console.WriteLine(stack.Pop());

        int count = 20;
        Stack<float> stack2 = new Stack<float>(count);

        stack2.Push(3.14f); //PI
        stack2.Push(9.8f); //Gravity
        stack2.Push(1e-6f); //10^-6 => 0.000001
        stack2.Push(1e+2f); //10^2 => 100

        Random random = new Random();
        for (int i = 0; i < count; i++)
            stack2.Push(random.NextSingle());

        //while(stack2.IsEmpty() == false)
        //Console.WriteLine(stack2.Pop());

        for (int i = 0; i < count + 10; i++)
            Console.WriteLine(stack2.Pop());
    }
}
```

### User 클래스 : const vs readonly

```csharp
public const int MaxSize = 10;
public readonly int MaxSize2;
public readonly int MaxSize3;
```

|  | `const` | `readonly` |
| --- | --- | --- |
| 값 결정 시점 | 컴파일 타임 | 런타임 (선언 시 또는 생성자) |
| 접근 방식 | 암묵적으로 static → `User.MaxSize` | 인스턴스 멤버 → `user1.MaxSize2` |
| 사용 가능한 값 | 컴파일 타임 상수만 | 런타임에 계산한 값도 가능 |
- 생성자가 두 개인데, 각각 한 필드만 초기화
    - `User()` → `MaxSize2 = 20`, `MaxSize3`는 기본값 0
    - `User(int maxSize3)` → `MaxSize3 = 입력값`, `MaxSize2`는 기본값 0
- 초기화하지 않은 `readonly`필드는 해당 타입의 기본값이 됨.

### 제네릭 메서드 Swap

```csharp
private static void Swap<T>(ref T a, ref T b)
{
    T temp = a;
    a = b;
    b = temp;
}
```

- `<T>`로 어떤 타입이든 교환 가능
- `ref`는 값의 복사본이 아니라 원본 변수의 참조를 넘기므로, 함수 안에서 바꾼 결과가 호출한 쪽 변수에 반영됨. `ref`가 없으면 교환이 영향 X.
- 호출 시 `Swap<int>(ref a, ref b)`처럼 타입을 명시했지만, 컴파일러가 추론할 수 있어서 `Swap(ref a, ref b)`로 써도 됨.

### Main 흐름

#### (1) Swap 테스트

```csharp
a : 20, b : 10
c : bbb, d : aaa
```

#### (2) User 테스트

```csharp
User user1 = new User();
// MaxSize : 10, MaxSize2 : 20, MaxSize3 : 0

string str = Console.ReadLine()!;
int.TryParse(str, out int size);
User user2 = new User(size);
```

- `!`는 null이 아님을 컴파일러에 알리는 null 허용 연산자
- `TryParse`는 변환에 실패해도 예외 없이 `false`를 반환하고, 이때 `size`는 0이 됨. 반환값을 확인하지 않으니 "abc"를 입력하면 `MaxSize3`는 0이 됨
- `out int size`는 변수 선언과 out 전달을 한 줄에서 해줌.
- user2는 `MaxSize2`가 **0**, `MaxSize3`가 입력값

#### (3) Stack<int> 테스트

```csharp
Stack<int> stack = new Stack<int>();   // 기본 크기 5
for (int i = 0; i < 5; i++) stack.Push(i);
while (stack.IsEmpty() == false) Console.WriteLine(stack.Pop());
```

- 0~4를 넣고 `IsEmpty()`로 확인하며 꺼내므로 LIFO 순서로 4, 3, 2, 1, 0이 출력됨. 크기가 딱 5라 가득 차지만 넘치지는 않음.

#### (4) Stack<float> 테스트

```csharp
Stack<float> stack2 = new Stack<float>(20);
```

- 먼저 4개를 넣음 : `3.14f`, `9.8f`, `1e-6f`(0.000001), `1e+2f`(100). `f` 접미사는 float 리터럴이라는 뜻이고, `1e-6f`는 지수 표기법
- 이어서 `random.NextSingle()`(0 이상 1 미만의 난수, .NET 6 이상)을 20번 Push
    - 이미 4개가 들어 있어 남은 칸은 16개뿐이므로, 17번째부터 "스택이 꽉 참"이 4번 출력되고 그 값들은 버려짐
- 이제 스택에는 20개가 있는데 `count + 10 = 30`번 Pop
    - 20번째까지는 정상적으로 출력됨. 먼저 난수 16개가 역순으로 나오고, 이어서 100, 0.000001, 9.8, 3.14가 나옴
    - 21번째 Pop에서 빈 스택에 접근하게 되어 `Debug.Assert(false, ...)`가 실패