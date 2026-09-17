# [C08_Casting](../CsharpStudy_List.md)

```csharp
using System;

namespace C08_Casting
{
    class Program
    {
        private static void Main(string[] args)
        {
            uint a = 4294967295; //4바이트 부호가 없는 정수(0 ~ 4,294,967,295)
            int b = (int)a; //4바이트 부호 있는 정수(-2,147,483,648 ~ 2,147,483,647) , 명시적 casting

            byte c = 10; //1바이트 부호 없는 정수 (0~ 255)
            int d = c; //명시하지 않아도 "암시적 형변환" 가능(위험성이 전혀 없음)
            int e = (int)c; //명시적 형변환

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(e);

            float pi = 3.14159268f; // float이 가질 수 있는 소숫점 자리 8개가 일반적, 접미사 f는 반드시 붙여야 함
            Console.WriteLine(pi);

            double f = pi;
            Console.WriteLine(f);

            float g = (float)f; //명시적 형변환
            Console.WriteLine(g);
        }//Main
    }
}
```

- uint : 4바이트 부호가 없는 정수 (0 ~ 4,294,967,295 표현 가능)
- uint > int 로 형변환은 위험성이 있음. int b = (int)a 명시적으로 형 변환을 진행
    - 변환해주면 위험성은 감당하겠다)
- byte > int 형변환은 위험성이 없음. 대입해줘도 암시적으로 형변환이 됨
    - 그래도 명시적으로 형변환 해주는 게 좋다(나중에 헷갈릴 수 있음).