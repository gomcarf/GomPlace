# C41_Lambda

## Lambda 클래스

- 람다식과 델리게이트(`Action`, `Func`, `Predicate`, `Comparison`)를 다양한 방식으로 쓰는 예제

```csharp
using System;
using System.Reflection.Metadata.Ecma335;

public struct Monster
{
    private string name;
    public string Name => name;

    private int hp;
    public int HP => hp;

    private int mp;

    public Monster(string name, int hp, int mp)
    {
        this.name = name;
        this.hp = hp;
        this.mp = mp;
    }

    public override string ToString()
    {
        return $"Monster : {name}, HP : {hp}, MP : {mp}";
    }
}

class Lambda
{
    public void Test(int a, string b)
    {
        Console.WriteLine($"Test : {a}, {b}");
    }

    public void Case1()
    {
        Action<int, string> action;
        action = Test;
        action(10, "Unity");

        void Test2(int a, string b)
        {
            Console.WriteLine($"Test2 : {a}, {b}"); //클로저
        }
        action = Test2;
        action(20, "C#");

        action = (int a, string b) => //람다문(익명 메서드)
        {
            Console.WriteLine($"Test3 : {a}, {b}"); //클로저
        };
        action(30, "C++");

        action = (a, b) => Console.WriteLine($"Test3 : {a}, {b}"); //람다식
        action(40, "Python");
    }

    //public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
    //public delegate string Func<int, string);
    //public delegate int MyDelegate(int a, string b);

    private int number;
    public int Number => number;
    //{
    //    get{ return number; }
    //}

    public void Case2()
    {
        Action<string> action = (str) => Console.WriteLine($"Case2 : {str}"); //람다식(중괄호가 없으면, return 없음)
        action("Unity"); //그냥 실행

        Func<int, string, string> func;
        func = (a, b) => $"Case2 : {a}, {b}"; //람다식(return 포함)

        string result = func(10, "Unity"); //func의 return을 받아와서 출력
        Console.WriteLine(result);
    }

    int Square(int x)//클로저(함수 내부에 선언하는 함수)
    {
        return x * x;
    }

    public void Case3()
    {
        int Square2(int x)//클로저(함수 내부에 선언하는 함수)
        {
            return x * x;
        }

        int a = 10;
        int b = Square(a);//Call by Value(a랑 x랑 메모리 공간 다름)
        int c = Square2(a); //Call by Value

        Console.WriteLine($"Case3 - Square : {b}, Square2 : {c}");
        Console.WriteLine($"Case3 - a : {a}");

        int d = 20;
        int Square3(int x)
        {
            return d + x; //d: Reference
        }
        Func<int, int> func = Square3;
        int e = func(10);
        Console.WriteLine($"Case3 - Square3 : {e}");

    }

    public void Case4()
    {
        Func<string> func = () => "Hello Lambda"; 
        string result = func();
        Console.WriteLine($"Case4 : {result}");

        Func<string> func2 = () =>
        {
            return "Hello Lambda2"; //람다문에는 return을 붙여줘야 함.
        };
        string result2 = func2();
        Console.WriteLine($"Case4 : {result2}");
    }

    public void Case5()
    {
        //Action : return이 없음
        //Func : return이 있음(TResult : 타입은 편한대로)
        //Predicate : return이 bool로 고정, 파라미터는 하나 사용 가능 / find할 때 많이 사용
        
        Predicate<string> predicate = (str) => str.Length > 5; //결과가 bool타입이니 조건문이 들어감
        bool result = predicate("Hello Lambda");
        Console.WriteLine($"Case5 : {result}");

        //Comparison : return이 int, 파라미터는 2개 가능. / 비교할 때 많이 사용(정렬)
        Comparison<int> comparison = (x, y) => x.CompareTo(y); // x<y : -1  x=y : 0  x>y : 1
    }

    public void Case6()
    {
        Random random = new Random(1000);

        List<int> numbers = new List<int>();
        for (int i = 0; i < 100; i++)
            numbers.Add(random.Next(1, 100));

        Console.WriteLine("-------------------------------------------------------------------------------");

        int count = 0;
        foreach (int number in numbers)
        {
            Console.Write($"{number:00}\t");

            count++;
            if(count >= 10)
            {
                count = 0;
                Console.WriteLine();
            }    
        }

        Console.WriteLine("-------------------------------------------------------------------------------");
        numbers.ForEach((number) =>
        {
            Console.Write($"{number:00}\t");

            count++;
            if (count >= 10)
            {
                count = 0;
                Console.WriteLine();
            }
        });
        Console.WriteLine("-------------------------------------------------------------------------------");

        int found = numbers.Find((x) => x > 50);
        Console.WriteLine($"Case6 - Find : {found}");

        Console.Write($"Case6 - FindAll : ");
        List<int> founds = numbers.FindAll((x) => x < 10);
        founds.ForEach((x) => Console.Write($"{x:00} "));

        Console.WriteLine();
        Console.Write($"Case6 - Distinct : ");
        founds.Distinct().ToList().ForEach((x) => Console.Write($"{x:00} ")); //중복을 제거해서 선형 자료형으로 반환 > IEnumerable > List로 변환 > foreach로 출력

        List<int> osc = new List<int>();
        osc.AddRange(numbers);

        osc.Sort();
        Console.WriteLine();
        Console.WriteLine("-------------------------------------------------------------------------------");
        osc.ForEach((number) =>
        {
            Console.Write($"{number:00}\t");

            count++;
            if (count >= 10)
            {
                count = 0;
                Console.WriteLine();
            }
        });
        Console.WriteLine("-------------------------------------------------------------------------------");

        List<int> desc = new List<int>();
        desc.AddRange(numbers);

        desc.Sort((x, y) => y.CompareTo(x));
        Console.WriteLine("-------------------------------------------------------------------------------");
        desc.ForEach((number) =>
        {
            Console.Write($"{number:00}\t");

            count++;
            if (count >= 10)
            {
                count = 0;
                Console.WriteLine();
            }
        });
        Console.WriteLine("-------------------------------------------------------------------------------");
    }

    public void Case7()
    {
        Monster[] monsters = new Monster[5];
        monsters[0] = new Monster("슬라임", 100, 10);
        monsters[1] = new Monster("고블린", 90, 20);
        monsters[2] = new Monster("오크", 120, 1);
        monsters[3] = new Monster("트롤", 200, 9);
        monsters[4] = new Monster("드래곤", 300, 50);

        List<Monster> monsterList = monsters.ToList();
        monsterList.Sort((x,y) => x.Name.CompareTo(y.Name));
        monsterList.ForEach((monster) => Console.WriteLine(monster));
        Console.WriteLine();
        monsterList = monsters.ToList();
        monsterList.Sort((x, y) => y.HP.CompareTo(x.HP));
        monsterList.ForEach((monster) => Console.WriteLine(monster));

    }
}

```

### Monster 구조체

```csharp
public struct Monster
{
    private string name;
    public string Name => name;
    private int hp;
    public int HP => hp;
    private int mp;
    ...
}
```

- `struct`는 값 타입이라 대입하면 복사본이 만들어짐
- `Name`, `HP`는 `=>`로 필드 값을 돌려주는 읽기 전용 프로퍼티. 생성한 뒤에는 바깥에서 바꿀 수 없음. `mp`는 프로퍼티가 없어서 `ToString()`으로만 확인할 수 있음.
- `using System.Reflection.Metadata.Ecma335;`는 쓰이지 않는 using이라 지워도 됨.

### Case1 : 함수를 델리게이트에 담는 방법

- `Action<int, string>`은 `void (int, string)` 형태의 함수를 담는 타입

```csharp
action = Test;                       // ① 일반 메서드
action = Test2;                      // ② 로컬 함수
action = (int a, string b) => { ... };   // ③ 람다문
action = (a, b) => Console.WriteLine(...); // ④ 람다식
```

| 방식 | 설명 |
| --- | --- |
| ① 메서드 그룹 | 클래스에 정의된 `Test`를 그대로 대입 |
| ② 로컬 함수 | 메서드 안에 선언한 함수 |
| ③ 람다문 | `{ }` 블록을 쓰는 이름 없는 함수. 여러 줄 가능 |
| ④ 람다식 | `{ }` 없이 식 하나만. 매개변수 타입은 `Action<int, string>`에서 추론되어 생략 가능 |

```csharp
[출력]
Test : 10, Unity
Test2 : 20, C#
Test3 : 30, C++
Test3 : 40, Python
```

- 클로저는 함수가 자기 바깥의 변수를 붙잡아 쓰는 것

### Case2 : Action과 Func

```csharp
Action<string> action = (str) => Console.WriteLine($"Case2 : {str}");
Func<int, string, string> func = (a, b) => $"Case2 : {a}, {b}";
```

- `Action<...>`은 반환값이 없고, `Func<...>`는 마지막 타입 인자가 반환 타입. `Func<int, string, string>`은 `string (int, string)`.
- 람다식 `(a, b) => $"..."`는 식의 결과가 곧 반환값이라 `return`이 필요 없음

```csharp
[출력]
Case2 : Unity
Case2 : 10, Unity
```

- `Number` 프로퍼티와 주석 처리된 델리게이트 선언은 설명용. `Number`는 `get { return number; }`를 줄여 쓴 형태. 이 필드에는 값을 대입하는 곳이 없어서 컴파일러 경고가 날 수 있음.

### Case3 : 로컬 함수와 진짜 클로저

```csharp
int Square(int x) { return x * x; }       // 클래스 메서드
int Square2(int x) { return x * x; }      // 로컬 함수 (Case3 안에 선언)

int a = 10;
int b = Square(a);
int c = Square2(a);
```

- `x`는 `a`의 복사본을 받음(값에 의한 전달). 함수 안에서 `x`를 바꿔도 `a`는 그대로
- 출력은 `Case3 - Square : 100, Square2 : 100`, `Case3 - a : 10`

```csharp
int d = 20;
int Square3(int x) { return d + x; }
Func<int, int> func = Square3;
int e = func(10);    // 30
```

- `Square3`가 바깥 변수 `d`를 직접 사용하므로 이것이 클로저. 컴파일러는 `d`를 별도 객체에 보관하고, 함수가 그 변수를 계속 참조하게 만듦.
- 값이 복사되는 것이 아니라 변수 자체를 공유. `func(10)` 호출 전에 `d = 100`으로 바꾸면 결과는 110이 됨.
- 주석의 "d: Reference"는 이런 의미로 이해하면 됨. 단, `d`가 참조 타입이라는 뜻은 아님.
- 출력은 `Case3 - Square3 : 30`

### Case4 : 매개변수 없는 람다와 return

```csharp
Func<string> func = () => "Hello Lambda";      // 식 람다: return 불필요
Func<string> func2 = () => { return "Hello Lambda2"; };  // 문 람다: return 필요
```

- 매개변수가 없으면 `()`를 씀
- `{ }`를 쓰는 블록 람다는 반환값이 있다면 `return`을 반드시 적어야 함
- 출력은 `Case4 : Hello Lambda`, `Case4 : Hello Lambda2`

### Case5 : Predicate와 Comparison

```csharp
Predicate<string> predicate = (str) => str.Length > 5;
bool result = predicate("Hello Lambda");   // 길이 12 > 5 → True
```

- `Predicate<T>`는 `T`를 받아 `bool`을 반환하는 델리게이트. `Func<T, bool>`과 같은 형태이며, `List<T>.Find`, `FindAll`, `Exists`, `RemoveAll` 등에 쓰임.
- 출력은 `Case5 : True`

```csharp
Comparison<int> comparison = (x, y) => x.CompareTo(y);
```

- `Comparison<T>`는 두 값을 받아 `int`를 반환하는 델리게이트로, 정렬에 쓰임
- 반환값은 `x < y`이면 음수, 같으면 0, `x > y`이면 양수. 주석의 -1/0/1은 `int`에서는 대개 맞지만, 규칙상 "음수/0/양수"로 이해하는 것이 정확함.
- 여기서는 선언만 하고 사용하지 않았음.

### Case6 : List와 람다

#### (1) 데이터 생성

```csharp
Random random = new Random(1000);
for (int i = 0; i < 100; i++)
    numbers.Add(random.Next(1, 100));
```

- `Random(1000)`처럼 시드를 지정하면 실행할 때마다 같은 난수열이 나옴. 결과를 재현하며 테스트하기 좋음.
- `Next(1, 100)`은 1 이상 100 미만이므로 1~99

#### (2) 10개씩 줄바꿈 출력

```csharp
foreach (int number in numbers)
{
    Console.Write($"{number:00}\t");
    count++;
    if (count >= 10) { count = 0; Console.WriteLine(); }
}
```

- `{number:00}`은 두 자리 0 채움 형식입니다(7 → 07). `\t`는 탭
- `count`로 10개마다 줄을 바꿈

```csharp
numbers.ForEach((number) => { ... count++; ... });
```

- 이 람다는 바깥의 `count`를 직접 증가시키므로 클로저. 람다가 변수 자체를 공유하기 때문에 안에서 바꾼 값이 바깥에도 반영됨.
- 100개는 10의 배수라 `count`는 매번 0으로 끝나고, 아래 출력들도 줄이 깔끔하게 맞음.

#### (3) 검색

```csharp
int found = numbers.Find((x) => x > 50);
List<int> founds = numbers.FindAll((x) => x < 10);
```

- `Find`는 조건을 만족하는 첫 번째 요소를 반환. 하나도 없으면 `default(int)`인 0을 반환해서 "0이 실제 값인지, 못 찾은 것인지" 구분 X. 구분이 필요하면 `FindIndex`를 쓰는 방법이 있음.
- `FindAll`은 조건에 맞는 모든 요소를 새 리스트로 반환.

#### (4) 중복 제거

```csharp
founds.Distinct().ToList().ForEach((x) => Console.Write($"{x:00} "));
```

- `Distinct()`는 LINQ 메서드(`System.Linq`)로 중복을 제거한 `IEnumerable<int>`를 반환. 처음 나온 순서는 유지됨.
- `IEnumerable`에는 `ForEach`가 없으므로 `ToList()`로 `List`로 바꾼 뒤 `ForEach`를 호출

#### (5) 정렬

```csharp
osc.AddRange(numbers);
osc.Sort();                              // 오름차순 (기본 비교)

desc.AddRange(numbers);
desc.Sort((x, y) => y.CompareTo(x));     // 내림차순
```

- `AddRange`로 복사본을 만들어 정렬하므로 원본 `numbers`는 그대로
- `Sort()`는 기본 비교로 오름차순 정렬
- `Sort(Comparison<T>)`에 `y.CompareTo(x)`를 넘기면 x와 y의 위치를 바꿔 비교하는 것이라 내림차순이 됨. `x.CompareTo(y)`이면 오름차순
- `List.Sort`는 불안정 정렬이라 같은 값끼리의 원래 순서는 보장되지 않음. 정수에서는 상관없지만 객체를 정렬할 때는 알아두면 좋음.

### Case7 : 구조체 정렬

```csharp
Monster[] monsters = new Monster[5];
...
List<Monster> monsterList = monsters.ToList();
monsterList.Sort((x, y) => x.Name.CompareTo(y.Name));
```

- `ToList()`로 배열을 복사한 리스트를 만듦. 리스트를 정렬해도 원본 `monsters` 배열은 그대로이고, 두 번째 정렬 때 `monsters.ToList()`로 다시 원래 순서에서 시작.
- 이름순 정렬은 `string.CompareTo`로 문자열을 사전순으로 비교.

```csharp
[이름순 출력]
Monster : 고블린, HP : 90, MP : 20
Monster : 드래곤, HP : 300, MP : 50
Monster : 슬라임, HP : 100, MP : 10
Monster : 오크, HP : 120, MP : 1
Monster : 트롤, HP : 200, MP : 9

[HP 내림차순 Sort((x, y) => y.HP.CompareTo(x.HP)) 출력]
Monster : 드래곤, HP : 300, MP : 50
Monster : 트롤, HP : 200, MP : 9
Monster : 오크, HP : 120, MP : 1
Monster : 슬라임, HP : 100, MP : 10
Monster : 고블린, HP : 90, MP : 20
```

- `Console.WriteLine(monster)`는 `ToString()`을 오버라이드한 덕분에 `Monster : ...` 형태로 출력
- 이 정렬은 `IComparable`을 구현하지 않은 타입도 람다만으로 기준을 바꿔가며 정렬할 수 있음을 보여줌

### 정리

| 타입 | 형태 | 용도 |
| --- | --- | --- |
| `Action<T...>` | 반환 없음 | 실행만 할 때, `ForEach` |
| `Func<T..., TResult>` | 반환 있음 | 값을 계산할 때 |
| `Predicate<T>` | `T → bool` | 조건 검사, `Find`/`FindAll` |
| `Comparison<T>` | `(T, T) → int` | 정렬, `Sort` |

## Main함수

```csharp
class Program
{
    private static void Main(string[] args)
    {
        Lambda lambda = new Lambda();
        lambda.Case1();
        lambda.Case2();
        lambda.Case3();
        lambda.Case4();
        lambda.Case5();
        lambda.Case6();
        lambda.Case7();
    }
}
/*
 void Test3(){}
람다로 변경하면
() => //람다를 시작한다는 기호

Action<int, string> action = (/int/ a, /string/ b)//자료형도 생략가능, 생략한다면 앞의 delegate 자료형으로 매핑해서 인식(delegate 반드시 필요, 람다 독단 사용 불가)
{ Constole.WrtieLine( ); }
action.Invoke; //Invoke도 생략하고 함수 형식으로 호출 가능 '3'

 */
```

- `Lambda` 인스턴스를 하나 만들고 `Case1()`부터 `Case7()`까지 순서대로 호출. 각 Case가 서로 독립적이라 순서를 바꿔도 결과는 같음.
- `Case`들은 `public` 인스턴스 메서드이므로 객체를 만들어야 호출할 수 있음
- Case1~5는 한두 줄씩 출력하고, Case6이 출력량이 가장 많음. 난수 100개를 4번(원본 foreach, ForEach, 오름차순, 내림차순) 10개씩 출력하고, Find/FindAll/Distinct 결과가 이어짐. Case7은 몬스터 정렬 결과를 두 번 출력함.
- 시드가 `1000`으로 고정되어 있어서 Case6의 난수는 매번 같음

### 람다 문법

**① 일반 함수 → 람다 변환**

```csharp
void Test3(int a, string b) { Console.WriteLine(...); }
```

```csharp
Action<int, string> action = (a, b) => { Console.WriteLine(...); };
```

- 함수 이름과 반환 타입을 떼고, 매개변수 목록 뒤에 `=>`를 붙이면 람다가 됨. 주석의 "람다를 시작한다는 기호"가 `=>`

**② 매개변수 타입 생략**

- `(int a, string b)` 대신 `(a, b)`로 쓸 수 있고, 타입은 대입되는 델리게이트(`Action<int, string>`)에서 추론됨.
- 주석의 "delegate 반드시 필요, 람다 독단 사용 불가"는 대체로 맞음. 람다는 대입 대상이 되는 델리게이트 타입(또는 `Action`/`Func`)이 있어야 형태가 정해짐. 단, C# 10부터는 `var f = (int a, string b) => ...;`처럼 타입이 명확하면 `var`로도 선언할 수 있어서, 절대적인 규칙은 아님.

**③ Invoke 생략 호출**

```csharp
action.Invoke(10, "Unity");action(10, "Unity");      // 같은 의미
```

- `Invoke`를 생략하고 함수처럼 호출할 수 있음. 앞서 `Player`에서 `OnItem(number, attack)`으로 쓴 것과 같음
- 메모의 `action.Invoke;`는 괄호와 인자가 빠진 불완전한 표기. 호출하려면 `action.Invoke(...)`로 써야 함.

```csharp
[실행 결과](요약)
Test : 10, Unity
Test2 : 20, C#
Test3 : 30, C++
Test3 : 40, Python
Case2 : Unity
Case2 : 10, Unity
Case3 - Square : 100, Square2 : 100
Case3 - a : 10
Case3 - Square3 : 30
Case4 : Hello Lambda
Case4 : Hello Lambda2
Case5 : True
(Case6: 난수 100개 출력 4회 + Find/FindAll/Distinct)
(Case7: 이름순, HP 내림차순 몬스터 목록)
```