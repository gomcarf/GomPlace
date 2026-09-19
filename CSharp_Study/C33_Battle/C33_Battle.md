# C33_Battle

## Main

```csharp
private static void Main(string[] args)
{
    Random random = new Random(); //seed를 가지고 클라이언트와 서버간 랜덤 싱크를 맞춤
    Console.WriteLine(random.Next()); //0~int.MaxValue-1 난수 발생
    Console.WriteLine(random.Next(10, 100)); //min, max-1사이의 난수 발생
    Console.WriteLine(random.NextSingle()); //0.0f~1.0f사이의 난수 발생

    string name;
    int hp;
    int power;
    int up;

    Console.WriteLine("이름, 체력, 공격력, 강화력을 입력하세요");
    string str = Console.ReadLine()!;

    str = str.Replace(" ",""); //공백을 없애는 함수
    //Console.WriteLine(str);

    string[] arr = str.Split(","); //문자열을 파라미터 기준값으로 잘라서 배열로 반환
    //foreach (string temp in arr)
    //    Console.WriteLine(temp);

    name = arr[0];
    int.TryParse(arr[1], out hp);
    int.TryParse(arr[2], out power);
    int.TryParse(arr[3], out up);

    Player player = new Player(name, hp, power, up);

    List<Monster> monsterList = new List<Monster>();

    str = "가나다라마바사아자차카타파하";

    for(int i = 0; i < random.Next(5, 10 + 1); i++) //최소 5마리부터 최대 10마리
    {
        int[] nameNumbers = new int[3];
        nameNumbers[0] = random.Next(0, 14); //0 ~ 13
        nameNumbers[1] = random.Next(0, 14);
        nameNumbers[2] = random.Next(0, 14);

        string monsterName = "";
        monsterName += str[nameNumbers[0]]; //몬스터 이름 랜덤 생성
        monsterName += str[nameNumbers[1]];
        monsterName += str[nameNumbers[2]];

        hp = random.Next(10,50 + 1); //몬스터 hp 랜덤 생성
        power = random.Next(10, 50 + 1); //몬스터 공격력 랜덤 생성

        monsterList.Add(new Monster(monsterName, hp, power)); //몬스터 리스트에 랜덤 생성한 몬스터 추가
    }

    Console.WriteLine();

    for (int i = 0; i < monsterList.Count; i++)
    {
        Monster m = monsterList[i];
        Console.WriteLine($"{i}번째 이름 : {m.Name}, 체력 : {m.Hp}, 공격력 : {m.Power}");
    }

    Console.WriteLine();

    while (true)
    {
        Console.Write("공격할 몬스터 번호 : ");
        string input = Console.ReadLine()!;

        int monsterNumber;
        int.TryParse(input, out monsterNumber);

        if (monsterNumber < 0 || monsterNumber >= monsterList.Count)
        {
            Console.WriteLine("몬스터 번호를 잘못 입력했습니다.");

            continue;
        }

        player.Attack(monsterList[monsterNumber]);

        monsterNumber = random.Next(0, 10 + monsterList.Count + 1);
        if (monsterNumber >= monsterList.Count)
            continue;

        monsterList[monsterNumber].Attack(player);

        if (player.Hp < 0)
        {
            Console.WriteLine("플레이어 사망!!!");
            Console.WriteLine("Game Over!");

            break;
        }
    }
}//Main
```

#### 1. 난수 생성기 (`Random` 클래스) 활용

- `random.Next()`: 0 이상 `int.MaxValue - 1` 미만의 난수 반환
- `random.Next(min, max)`: `min` 이상 `max - 1` 미만의 난수 반환 (예 : `random.Next(10, 100)`은 10~99)
- `random.NextSingle()`: 0.0f 이상 1.0f 미만의 `float` 난수 반환
- 주석 내용 팁 : 클라이언트와 서버가 동일한 Seed(씨앗값)를 사용해 `Random` 객체를 생성하면 똑같은 난수 수열이 발생하므로 멀티플레이 게임에서 무작위 상태 동기화에 활용됨.

#### 2. `List<T>`를 이용한 동적 몬스터 목록 관리 및 한글 조합

```csharp
List<Monster> monsterList = new List<Monster>();
```

- 배열(`Monster[]`) 대신 가변 길이 리스트(`List<Monster>`)를 사용하여, 5~10마리의 몬스터를 자유롭게 `.Add()`로 추가 가능.
- `"가나다라마바사아자차카타파하"` 문자열 인덱스를 무작위(0~13)로 3번 추출해 `"가자파"`, `"사카타"` 같은 한글 몬스터 이름을 조합.

### 3. 사용자 입력 가공

```csharp
string str = Console.ReadLine()!; //문자열 입력 받기

str = str.Replace(" ","");
string[] arr = str.Split(","); //문자열을 파라미터 기준값으로 잘라서 배열로 반환
```

- `str.Replace(" ","");` : 파라미터의 첫번째 항목을 두번째 항목으로 치환. 여기에서는 공백을 삭제
- `string[] arr = str.Split(",");` : 문자열을 ‘`,`’로 구분해서 자른 다음 `arr` 배열에 저장

#### 4. 플레이어 vs 몬스터 턴제 전투 로직

1. 플레이어의 공격: 입력받은 몬스터 번호로 `player.Attack(...)`을 호출.
2. 몬스터의 반격 (랜덤 확률) :
    
    ```csharp
    monsterNumber = random.Next(0, 10 + monsterList.Count + 1);
    if (monsterNumber >= monsterList.Count)
        continue;
    monsterList[monsterNumber].Attack(player);
    ```
    
    - 몬스터 공격 대상 번호를 `0`부터 `9 + monsterList.Count` 범위에서 뽑음.
    - 번호가 `monsterList.Count` 이상이면 몬스터가 반격에 실패(공격 건너뜀)하고, 범위 이내일 경우 해당 몬스터가 플레이어를 역공격.
3. 게임 오버 검사 : `player.Hp < 0` 체크를 통해 플레이어가 사망하면 `Game Over!`를 출력하고 `break`로 게임을 종료

## Character, Monster, Player 클래스

```csharp
class Character
{
    public string Name { get; protected set; }

    public int Hp { get; set; }

    public int Power { get; protected set; }
    
    public virtual void Attack(Character character) //이 함수는 가상화(virtual) 됨. 자식 클래스에서 **필요하면**  오버라이딩해서 사용해라
    {
        string str = "";
        str += $"{Name}이 {character.Name}을 공격\n";

        if (character.Hp > 0)
            str += $"{character.Name}의 체력이 {character.Hp}만큼 남음\n";
        else
            str += $"{character.Name} 사망!!";
        Console.WriteLine(str);
    }
}
```

```csharp
class Monster : Character
{
    public Monster(string name, int hp, int power)
    {
        Name = name;
        Hp = hp;
        Power = power;
    }

    //부모의 어택 함수 그냥 사용, 동적할당
    public override void Attack(Character character)
    {
        character.Hp -= Power;
        string str = $"{Name}이 {character.Name}을 {Power} 만큼 공격\n";
        Console.WriteLine(str);
        base.Attack(character);
    }
}
```

```csharp
class Player : Character
{
    public int Up { get; private set; } //자기자신에서만 세팅

    public Player(string name, int hp, int power, int up)
    {
        Name = name;
        Hp = hp;
        Power = power;
        Up = up;
    }

    public override void Attack(Character character)
    {
        character.Hp -= Power + Up;
        string str = $"{Name}이 {character.Name}을 {Power}+{Up}만큼 공격\n";
        Console.WriteLine(str);
        base.Attack(character);
    }
}
```

#### ① `Character` 클래스 (공통 부모 클래스)

- 공통 속성 통합 : `Player`와 `Monster`가 공통으로 가져야 할 `Name`, `Hp`, `Power`를 최상위 부모 클래스에 모아둠.
- 프로퍼티 접근 제한자 (`protected set`) : `Name`과 `Power`는 외부(`Main` 등)에서 함부로 변경할 수 없지만, 자식 클래스(`Player`, `Monster` 생성자)에서는 자유롭게 설정할 수 있도록 `protected set`으로 보호.
- 가상 메서드 (`virtual void Attack`) :
    - `abstract`와 달리 부모 클래스 수준에서 기본 구현(몸통 `{}`)을 제공.
    - 자식 클래스에서는 이 공격 결과를 출력하는 공통 로직을 재사용할 수 있게 됨.

#### ② `base.Attack(character)` 키워드의 활용

`Monster`와 `Player` 클래스의 `Attack` 구현부를 보면 마지막에 `base.Attack(character);`를 호출.

```csharp
public override void Attack(Character character)
{
    character.Hp -= Power; // 1. 자식에서 각자 데미지 계산
    string str = ...;
    Console.WriteLine(str);

    base.Attack(character); // 2. 부모(Character)의 공통 출력 로직 재사용
}
```

- 코드 중복 제거 : 체력이 얼마나 남았는지, 사망했는지 출력하는 로직을 자식 클래스마다 일일이 작성하지 않고 부모 클래스(`Character`)의 `Attack` 기능을 호출하여 재사용.
- 확장성과 유지보수성이 비약적으로 향상.

#### ③ 상호 공격 가능 구조 (`Character character`)

- `Attack` 메서드의 매개변수 타입이 `Monster`나 `Player`가 아닌 `Character`로 지정.
- 덕분에 다형성에 의해 다음과 같은 모든 공격 상황이 메서드 단 하나로 처리됨.
    - `Player` $\rightarrow$ `Monster` 공격
    - `Monster` $\rightarrow$ `Player` 공격
    - `Monster` $\rightarrow$ `Monster` 공격 (필요 시)
    - `Player` $\rightarrow$ `Player` 공격 (PVP 구현 시)

## ref와 out 테스트

```csharp
{
    int a = 10, b = 20; //초기화 안하면 에러
    TestRef(ref a, ref b);
    Console.WriteLine($"a = {a}, b = {b}");

    int c = 5, d; //초기화가 되지 않아도 에러x
    TestOut(out c, out d); //d는 여기서 대입이 일어나기 때문
    Console.WriteLine($"c = {c}, d = {d}");
    
    private static int TestOut() //return이 1개인 경우
		{
			  int a = 10;
			  return a;
		}
		private static void TestRef(ref int val1, ref int val2) //return이 2개 이상인 경우 reference 사용
		{
			  val1 += 10;
			  val2 += 20;
		}
		
		private static void TestOut(out int val1, out int val2) //함수에서 처리해서 값만 여러개 돌려줄 때 out 사용
		{
			  val1 = 10;
			  val2 = 20;
		}
}
```