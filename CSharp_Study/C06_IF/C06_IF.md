# [C06_IF](../CsharpStudy_List.md)

```csharp
using System;

namespace C06_IF
{
    class Program
    {
        private static void Main(string[] args)
        {
            //int a = 4;

            Console.Write("정수 입력 : ");
            int a = int.Parse(Console.ReadLine()!);

            bool b = a > 5;

            if (b)
            {
                Console.WriteLine("a는 5보다 큼");
            }
            else if (a > 3)
            {
                Console.WriteLine("a는 3보다 큼");
            }
            else
            {
                Console.WriteLine("a는 3보다 작음");
            }

                Console.WriteLine("프로그램 종료");
        }//Main
    }
}
```

- `int.Parse(Console.ReadLine()!)` 에서의 ! :  Null 서프레션 연산자(Null-suppression operator) 또는 Null 포기 연산자
    - 이 값이 null이 아님을 보장하니, 컴파일러 경고를 무시하라는 의미
    - int.Parse()함수는 null을 입력받으면 안되기 때문에 `int.Parse(Console.ReadLine())` 처럼 코드를 작성하면 컴파일러가 null이 들어갈 수 있어 위험하다는 경고(cs8604)를 띄움
    - !의 역할 : 코드 끝에 !를 붙여 string? 타입을 string 타입으로 강제 변환하여 컴파일러 경고를 제거
    - int.TryParse 활용 권장
    
    ```csharp
    Console.Write("정수 입력 : ");
    if (int.TryParse(Console.ReadLine(), out int a))
    {
        // 정상적으로 정수로 변환된 경우
    }
    ```
    
- 조건문에 따라 명령어 실행 여부가 바뀜
- 조건문을 잘 설정해줘야 함
    - 그렇지 않으면 모든 조건이 만족해서 조건에 따른 명령어를 모두 실행하거나 모두 실행하지 않을 수 있음!
- bool : 논리 자료형. 참, 거짓 중 하나를 저장 가능