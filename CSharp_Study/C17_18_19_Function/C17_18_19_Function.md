# [C17,18,19_Function](../CsharpStudy_List.md)

```csharp
using System;

namespace C17_Function
{
    class Program
    {
        private static void Print(int a, int b)
        {
            Console.WriteLine($"a = {a}, b = {b}");
        }

        private static void Swap(int x, int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        private static void Main(string[] args)
        {
            Print(10, 20);
            Print(20, 20);
            Print(50, 60);
            Print(100, 1);

            int c = 10, d = 20;
            int temp = c;
            c = d;
            d = temp;

            Console.WriteLine($"c = {c}, d = {d}");

            c = 30; d = 40;
            Console.WriteLine($"c = {c}, d = {d}");
            Swap(c, d); //실제로 값이 바뀌지는 않았다!!
            Console.WriteLine($"c = {c}, d = {d}");

        }//Main
    }
}
```

- 동일한 기능을 한다면 중복해서 사용하지 않고 함수로 선언해서 간단하게 사용 가능
- 메인이 너무 복잡하면 가독성이 떨어짐

```csharp
using System;

namespace C18_Function2
{
    class Program
    {
        private static int Add(int a, int b)
        {
            int c = a + b;
            return c; //return은 한번만 하나의 값만 가능함 여러개 반환 안됨
        }//Add

        private static void Main(string[] args)
        {
            int e = 10, f = 20;
            int g = Add(e, f);
            
            Console.WriteLine($"g = {g}");
        }//Main
    }
}
```

- 함수가 값을 반환해야 한다면 함수 이름 앞에 반환하는 값의  형식을 명시(int)
- 함수가 받아야 하는 매개변수가 있다면 변수의 형식과 함수 내에서 사용할 변수명 명시(int a, int b)
- return은 한 번만 하나의 값만 가능, 여러 값 반환 안됨.

```csharp
using System;

namespace C19_Function3
{
    class Program
    {
        private static void Swap(ref int a, ref int b) //e랑 f 공간에 a, b라고 별명을 붙여줄게~ 같은 주소지 사용할게~
        {
            int temp = a;
            a = b;
            b = temp;
        } //함수 종료 시 RAM에 생성된 변수와 값 모두 사라짐

        private static void Main(string[] args)
        {
            int e = 10, f = 20;
            Console.WriteLine($"e = {e}, f = {f}");
            Swap(ref e, ref f);
            Console.WriteLine($"e = {e}, f = {f}");
        }//Main
    }
}
```

- ref (참조) 예약어를 붙여주면 변수의 이름이 아닌 참조 변수의 주소에 접근
    - 변수의 메모리 주소(참조) 자체를 전달
    - 메서드 내부에서 매개변수의 값을 바꾸면 호출한 곳의 원본 변수 값도 함께 변경
    - 변하지 않던 a, b가 ref로 매개 변수를 지정해주면 값이 변함
- !참고!
    - `ref`: 메서드가 변수를 읽고 쓸 수 있음 (호출 전 초기화 필수)
    - `out`: 메서드가 변수를 반드시 새로 할당/작성해야 함 (호출 전 초기화 안 되어 있어도 됨, 주로 여러 개의 값을 반환할 때 사용)
    - `in`: 메서드가 변수를 읽기 전용으로만 사용 (값 변경 불가, 대용량 구조체 전달 시 성능 최적화용)

[CPU]
     |
[RAM] e[ 10 ]ref a     f[ 10 ]ref b          a[ 10 ]   b [ 20 ]  temp [ 10 ] ← a, b, temp는 Swap 함수 종료시 사라짐
     |
[SSD]

OS : 너는 100번지부터 이용해
RAM에 100~103번지까지 e라는 이름으로 사용하고 10을 저장함
OS : 너는 105번지부터 이용해
RAM에 105~108번지까지 f라는 이름으로 사용하고 20을 저장함
⇒근데 사실 e, f는 우리가 편하자고 c#문법으로 사용한 거지 실제 컴퓨터는 받아들이는 게 다름 
→ 100~103번지에 값이 존재한다, 105~108까지 값이 존재한다로 받아들임 : 변수명이 아닌 변수의 주소로 판단!