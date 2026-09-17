# [C04_String](../CsharpStudy_List.md)

```csharp
using System;

namespace C04_String
{
    class Program
    {
        private static void Main(string[] args)
        {
            char a = 'A'; //문자형
            Console.WriteLine($"a = {a}");

            char b = '가';
            Console.WriteLine($"b = {b}");

            int c = (int)a; //문자형 -> 정수형으로 변환
            Console.WriteLine($"c = {c}");

            int d = (int)b;
            Console.WriteLine($"d = {d}");

            Console.Write("문자열 입력 : ");
            String? e = Console.ReadLine();
            Console.WriteLine($"입력한 문자열 : {e}");
        }//Main
    }
}

/*
 * 'a' - 문자
 * "abc" - 문자열
 */
```

- ‘a’ → 문자(character)
“abc” → 문자열(String)
- char : 2byte 문자형
- 알파벳 - ASCII CODE
한글 - Unicode

```csharp
Console.Write("문자열 입력 : ");
String? e = Console.ReadLine();
Console.WriteLine($"입력한 문자열 : {e}");
```

- String? ← ? : 변수 e가 null값을 가질 수 있음(Nullable)을 명시적으로 나타내는 기호
    - 왜 필요한가? : c#에서는 프로그램이 실행되는 도중 아무것도 참조되지 않는 상태인 null을 참조하려고 하면 NullReferenceException 이라는 런타임 에러가 발생하여 프로그램이 튕기곤 함. 이를 방지하기 위해 엄격하게 구분하는 것.
    - string e : null을 넣으면 안되는 문자열(널 비허용)
    - string? e : null이 들어올 수도 있는 문자열(널 허용)
    - 게다가 Console.ReadLine()의 반환 타입이 String? 으로 정의되어 있음!