# [C05_ReadLine](../CsharpStudy_List.md)

```csharp
using System;

namespace C05_ReadLine
{
    class Program
    {
        private static void Main(string[] args)
        {
            string a = "1234";
            string b = "4321";
            string c = a + b; //문자열의 +는 연결의 의미, 연산의 의미x
            Console.WriteLine($"{a} + {b} = {c}");

            int d = int.Parse(a); //parse => 변환하다 sting을 int형으로 변환
            int e = int.Parse(b);
            int f = d + e;
            Console.WriteLine($"{d} + {e} = {f}");

            string g = "3.14";
            float h = float.Parse(g); //string => float
            Console.WriteLine($"g = {g}");

            Console.Write("정수 입력 : ");
            String? input = Console.ReadLine();
            int val = int.Parse(input);
            Console.WriteLine($"val = {val}");
        }//Main
    }
}
```

- 문자열끼리 + 연산은 연결의 의미
- int.Parse(a) : string을 int 형으로 변환 변환하는 메서드
    - 문자열이던 a의 “1234”, b의 “4321”이 int형으로 변환하여 d = 1234, e=4321 저장됨
- float.Parse(a) : string을 float 형으로 변환 변환하는 메서드
    - 문자열 “3.14”가 float형으로 변환하여 h에 저장됨
- String? input = Console.ReadLine(); → 사용자에게 입력을 받을 수 있음
    - input은 Nullable, Console.ReadLine의 반환타입이 String? 타입