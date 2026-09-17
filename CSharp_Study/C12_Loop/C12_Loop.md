# [C12_Loop](../CsharpStudy_List.md)

```csharp
using System;

namespace C12_Loop
{
    class Program //파스칼표기법
    {
        private static void Main(string[] args)
        {
            int monsterHp = 100; //카멜표기법

            int weakAttack = 5;
            int baseAttack = 10;
            int strongAttack = 25;

            while (true) //게임 Loop
            {
                Console.Write("공격 방법(종료 - 99) : ");
                int select = int.Parse(Console.ReadLine()!);

                if (select == 99)
                    break;

                switch (select)
                {
                    case 1:
                    {
                        monsterHp -= weakAttack;
                        Console.WriteLine($"약 공격 - 공격력 {weakAttack}으로 공격! - 몬스터 HP : {monsterHp}");
                    }
                    break;

                    case 2:
                    {
                        monsterHp -= baseAttack;
                        Console.WriteLine($"기본 공격 - 공격력 {baseAttack}으로 공격! - 몬스터 HP : {monsterHp}");
                    }
                    break;

                    case 3:
                    {
                        monsterHp -= strongAttack;
                        Console.WriteLine($"강한 공격 - 공격력 {strongAttack}으로 공격! - 몬스터 HP : {monsterHp}");
                    }
                    break;

                    default:
                    {
                        Console.WriteLine("잘못된 입력, 다시 입력하세요.");
                        break;
                    }

                }//switch

                if(monsterHp <= 0)
                {
                    Console.WriteLine("몬스터 사망!!!!!!");
                    break;
                }
            }//while

            Console.WriteLine("게임 종료");
        }//Main
    }
}
```

- 표기법
    - 카멜 표기법(camelCase)
        - 첫 글자를 소문자로 시작, 두번째 단어부터 각 단어의 첫글자를 대문자로 작성
        - `camelCase`, `userAge`, `monsterAttack`
        - C# 사용처:
            - 지역 변수(Local variables)
            - 메서드 매개변수(Parameters)
    - 파스칼 표기법(Pascal Case)
        - 첫 글자를 대문자로, 단어가 연결될 때마다 각 단어의 첫 글자도 대문자
        - `Program`, `Main`, `PascalCase`, `UserAge`
        - **C# 사용처:** C#의 공식 권장 스타일로 가장 널리 쓰입니다.
            - 클래스(Class) 및 구조체(Struct)
            - 메서드(Method) 및 프로퍼티(Property)
            - 네임스페이스(Namespace) 및 인터페이스(Interface) (인터페이스는 대문자 `I`를 접두사로 붙여 `IUserRepository`처럼 표기)
    - 스네이크 표기법(snake_case) : 모든 글자를 소문자로 쓰고, 단어 사이를 언더바로 연결(예: `user_age`, `monster_attack`)
    - 헝가리안 표기법(Hungarian Notation) : 변수명 앞에 변수의 데이터 타입을 뜻하는 약자를 접두어로 붙임(예: `strName`, `iCount`, `bIsValid`)