# [C07_Logical](../CsharpStudy_List.md)

```csharp
using System;

namespace C07_Logical //논리연산자
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("정수 입력 : ");
            int a = int.Parse(Console.ReadLine()!);

            if( a > 5 && a < 10)
            {
                Console.WriteLine($"{a}는(은) 5보다 크고 10보다 작음");
            }

            Console.WriteLine("프로그램 종료");
        }//Main
    }
}
```

- 조건부 논리 연산자
    - 앞의 조건만으로 전체 결과가 확정되면 뒤의 조건은 평가하지 않아 성능을 최적화하고 에러를 방지
    - &&(조건부 AND) : 앞, 뒤 조건문이 모두 참이어야 참
    - ||(조건부 OR) : 앞, 뒤 조건문 중 하나라도 참이면 참
- 일반 논리 연산자(비트 연산자 겸용)
    - 항상 양쪽 조건을 모두 평가
    - BOOL 타입에 사용하면 논리연산자, 정수타입에 사용하면 비트연산자
    - &(논리 AND) : 양쪽이 모두 참일때 참 반환
    - |(논리 OR) : 하나라도 참이면 참
    - ^(논리 XOR, 배타적 논리합) : 양쪽 조건이 서로 다를 때만 참
- 단한 논리 연산자
    - !(논리 부정 NOT) : 조건의 결과를 반대로 뒤집기.
- &, | 는 정수 데이터의 비트 연산에 사용. XOR는 암호화 알고리즘이나 상태 반전 등의 특정 알고리즘에서 유용하게 쓰임