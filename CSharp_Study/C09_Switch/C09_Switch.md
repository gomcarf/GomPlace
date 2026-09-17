# [C09_Switch](../CsharpStudy_List.md)

```csharp
using System;

namespace C09_Switch
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("비교할 정수 : ");
            int a = int.Parse(Console.ReadLine()!);

            Console.Write("첫번째 정수 : ");
            int b = int.Parse(Console.ReadLine()!);

            Console.Write("두번째 정수 : ");
            int c = int.Parse(Console.ReadLine()!);

            int d = (a > 5) ? b : c; //삼항연산자
            Console.WriteLine($"d = {d}");

            if (a == 5)
                Console.WriteLine("a == 5");
            else if (a == 6)
                Console.WriteLine("a == 6");
            else if (a == 7)
                Console.WriteLine("a == 7");
            else if (a == 8)
                Console.WriteLine("a == 8");
            else
                Console.WriteLine("맞는 조건 없음");

            switch(a)
            {
                case 5: Console.WriteLine("a == 5"); break;
                case 6: Console.WriteLine("a == 6"); break;
                case 7: Console.WriteLine("a == 7"); break;
                case 8: Console.WriteLine("a == 8"); break;
                default: Console.WriteLine("맞는 조건 없음"); break;
            }
        }//Main
    }
}
```

- 삼항연산자
    - 조건문이 참일 때 a, 거짓일 때 b

```csharp
(조건문) ? a : b
```

- switch : 조건이 단순 값이 같은지 비교하는 상황일 때 유용하게 사용 가능
    - 각 case 뒤에 break; 써야 오류가 나지 않음
    - default : 조건에 맞는 case가 없을 경우 기본으로 실행되는 부분