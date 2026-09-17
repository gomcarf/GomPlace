# [C10_For](../CsharpStudy_List.md)

```csharp
using System;

namespace C10_For
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("정수 입력 : ");
            int count = int.Parse(Console.ReadLine()!);

            int sum = 0; //지역변수
            for(int i = 1; i <= count; i+=2) //i는 for문 안에서만 사용 가능한 지역변수
            {
                if (i > 10)
                    break; //반복문 탈출

                if (i == 5)
                    continue;  //아래 명령어는 실행하지 않고 바로 반복문  처음으로 이동

                //sum = sum + i;
                sum += i;

                Console.WriteLine(i);
            }
            Console.WriteLine($"합계 : {sum}");

            int k = 0;
            for(; ;)
            {
                k++;

                if (k > 100) break;

                Console.WriteLine($"k = {k}");
                
            }
        }//Main
    }
}
```

- break; : 반복문 탈출
- continue; : 아래 명령어는 실행하지 않고 바로 증감값과 조건문으로 올라감

```csharp
	for( ; ; ) -> 무한 반복
	while(true) 랑 동일
```

# C14~15_For2

```csharp
using System;

namespace C14_For2
{
    class Program
    {
        private static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"i = {i:00}, j = {j}\t"); //:00 자리수 채우기 0으로 채워줌
                }
                Console.WriteLine("");
            }
        }//Main
    }
}
```

- 이중 반복문
    - for문 안에 for문이 중첩해서 들어감.

```csharp
Console.Write($"i = {i:00}"); // 0의 개수만큼 자리수를 0으로 채워줌. 00 01 02 03 ...
```

```csharp
using System;

namespace C15_For3
{
    class Program
    {
        private static void Main(string[] args)
        {
            for (int i = 2; i <= 9; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    int k = i * j;
                    Console.Write($"{i:00} X {j:00} = {k:00}  ");
                }//for(j)

                Console.WriteLine();
            }//for(i)
        }//Main
    }
}
```

- 반복문을 중첩으로 사용하면 구구단도 쉽게 만들수 있다구~?
- i가 밖에 있고 j가 안에 있음. 2x1~2x9, 3x1~3x9, … 순으로 출력됨