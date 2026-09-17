# [C11_While](../CsharpStudy_List.md)

```csharp
using System;

namespace C11_While
{
    class Program
    {
        private static void Main(string[] args)
        {
            int a = 1;

            int b = ++a;
            Console.WriteLine($"a = {a}, b = {b}"); //a를 먼저 증가 시키고 b에 대입

            int c = a++;
            Console.WriteLine($"a = {a}, c = {c}"); //a를 먼저 c에 대입하고 a 증가

            int d = --a; 
            Console.WriteLine($"a = {a}, d = {d}"); //a를 먼저 감소 시키고 d에 대입

            int e = a--; 
            Console.WriteLine($"a = {a}, e = {e}"); //a를 먼저 e에 대입하고 a 감소

            int i = 0;
            while (i < 5)
            {
                Console.WriteLine($"i = {i}");

                i++;
            }

            i = 5;
            while (i < 5)
            {
                i++;
                Console.WriteLine($"while = {i}"); //실행 안됨
            }

            i = 5;
            do
            {
                i++;
                Console.WriteLine($"do-while = {i}"); //한번은 실행됨
            }
            while (i < 5);
        }//Main
    }
}
```

- ++, - - 변수 명 앞, 뒤 위치에 따라 실행 순서 다르니 유의

```csharp
while(조건문)
{
	...
}
```

- 조건문이 참일 동안 계속 반복
- 조건문이 거짓이면 한번도 실행 안됨

```csharp
do
{
	...
}
while(조건문)
```

- 일단 한번 실행 후 조건문이 참이면 반복, 아니면 탈출
- 최소 한번 실행