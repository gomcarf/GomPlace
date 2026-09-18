# [C21_Structure2](../CsharpStudy_List.md)

```csharp
private struct Character
        {
            public string Name; //멤버변수(구조체 내부에 있는 변수)
            public float Hp; //private : 선언된 내부에서만 사용 가능. 외부에서 사용 불가
            public float Attack;

            public string GetData()
            {
                string temp = $"Name : {Name}, Hp : {Hp}";

                return temp ;
            }

            public void Damage(float InAmount)
            {
                Hp -= InAmount;
                Hp = Math.Clamp(Hp, 0, 100); //값을 제한하는 메소드. 0f와 100f 사이로 hp 제한
            }
        }
```

- 데이터 모델링 : 캐릭터의 이름, 체력, 공격력을 하나로 묶는 값 타입(Value Type) 단위
- `Math.Clamp(hp, 0, 100)` : 변수 hp를 0부터 100까지 제한하는 메소드
- `GetData()` : 캐릭터의 현재 정보(이름, 체력)를 문자열로 반환
- `Damage()` : 데미지를 입었을 때 체력을 깎고, 이전 질문에서 다룬 `Math.Clamp`를 활용해 `Hp`가 0 밑으로 떨어지는 것을 방

```csharp
Character player;
player.Name = "Player";
player.Hp = 100;
player.Attack = 10; 

Console.WriteLine(player.GetData());

Character monster;
monster.Name = "Oak";
monster.Hp = 30;
monster.Attack = 5;
Console.WriteLine(monster.GetData());

Console.WriteLine();

string[] names = new string[]
{
		"Goblin", "Dwarf", "Poring",
};
Character[] monsters = new Character[3];
for (int i = 0; i < monsters.Length ; i++)
{
		monsters[i].Name = names[i];
		monsters[i].Hp = (i+1)*10;
		monsters[i].Attack = 3;
}

foreach(string name in names) //names에 있는 0번째를 name에 입력 foreach: 배열 반복문 할 때 유용!
		Console.WriteLine(name);
```

- 개별 캐릭터 초기화 : `player` (체력 100, 공격력 10) 와 `monster` (오크, 체력 30, 공격력 5)를 개별 생성 후 정보를 출력
- 구조체 배열과 반복문 활용 : `names` 배열의 요소를 고블린, 드워프, 포링으로 초기화한 다음 `names` 배열의 요소를 가져와 `monsters` 배열 내 각 구조체의 이름과 체력(10, 20, 30)을 규칙적으로 설정
- 출력 확인: `foreach`문을 사용해 `names` 배열 요소들과 `monsters` 배열의 각 몬스터 데이터(`GetData()`)를 순회하며 콘솔에 출력함.

```csharp
while(true)
{
		Console.Write("공격할 몬스터 : ");
		int number = int.Parse(Console.ReadLine()!);

		if (number < monsters.Length) //number가 monsters 배열의 길이(3)보다 작으면 0,1,2 중 하나
				monsters[number].Damage(player.Attack);
		else if (number == monsters.Length)//number == 3 -> 오크를 공격할 경우
				monster.Damage(player.Attack);
		else
				break;

		foreach (Character m in monsters)
				Console.WriteLine(m.GetData());

		Console.WriteLine(monster.GetData());
}//while
```

- 사용자의 입력(`0`, `1`, `2`, `3` 등)에 따라 특정 몬스터를 타격하는 로직
    - 0~2 입력 : `monsters[0]`, `monsters[1]`, `monsters[2]` 중 선택된 몬스터의 `Damage()`를 호출하여 `player.Attack`(10)만큼 체력을 감축.
    - 3 입력 : `monsters.Length`가 3이므로 조건식이 성립하여 개별 몬스터인 `monster`(오크)를 공격함.
    - 다른 숫자 입력 : `break`가 실행되며 무한 루프를 탈출하고 프로그램이 종료됨.