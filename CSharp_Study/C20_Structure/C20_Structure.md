# [C20_Structure](../CsharpStudy_List.md)

- 절차지향(Procedural) : 함수(procedure) 중심
- 구조지향 : 데이터 중심(database) → 하나 바꾸니까 다 바꿔야 되는 문제 발생 → 와씨 유지보수 비용이 너무 많이 드는데?;;;
- 객체지향 : 함수+데이터 클래스 중심
- 소프트웨어 개발 수명 주기(Software Development Life Cycle)
    - 소요제기
    - 요구분석(기획)
    - 설계(를 잘해야 유지보수가 쉬워짐)
    - 개발
    - 검증(테스팅)
    - 배포(출시)
    - 유지보수(라이브 서비스)
    - 폐기

```csharp
using System;
using System.Numerics;

namespace C20_Structure
{
    class Program
    {
        private struct Character//파란색은 예약어, 변수명으로 사용 불가
        {
            public string Name;
            public float Hp;
            public float Attack;

            public void Print()
            {
                Console.WriteLine($"이름 : {Name}");
                Console.WriteLine($"체력 : {Hp}");
                Console.WriteLine($"공격력 : {Attack}");
            }
        }

        private static void Main(string[] args)
        {
            Character player;
            player.Name = "Novis";
            player.Hp = 100;
            player.Attack = 10;
            player.Print();

            //Console.WriteLine($"이름 : {player.Name}");
            //Console.WriteLine($"체력 : {player.Hp}");
            //Console.WriteLine($"공격력 : {player.Attack}");

            Character monster;
            monster.Name = "Oak";
            monster.Hp = 30;
            monster.Attack = 5;
            monster.Print();

            //Console.WriteLine($"이름 : {monster.Name}");
            //Console.WriteLine($"체력 : {monster.Hp}");
            //Console.WriteLine($"공격력 : {monster.Attack}");
        }//Main
    }
}
```

- 구조체

```csharp
private struct Character//파란색은 예약어, 변수명으로 사용 불가
{
		public string Name;
    public float Hp;
    public float Attack;

    public void Print()
    {
		    Console.WriteLine($"이름 : {Name}");
        Console.WriteLine($"체력 : {Hp}");
        Console.WriteLine($"공격력 : {Attack}");
    }
}
```

- 중복되는 변수나 명령어를 struct에 묶어서 사용
- 구조체 Charcter를 type(자료형)처럼 이용 가능

```csharp
Character player; //Character 타입의 player 변수 선언
```

- “.” 을 이용하면 구조체 내의 변수나 함수에 접근 가능

```csharp
player.Name = "Novis";
player.Hp = 100;
player.Attack = 10;
player.Print();
```