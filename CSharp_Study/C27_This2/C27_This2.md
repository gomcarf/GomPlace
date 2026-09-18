# [C27_This2](../CsharpStudy_List.md)

## Main함수

- 개별 객체 생성, 객체 배열 활용, 반복문을 통한 일괄 처리를 보여주는 실행 코드

```csharp
namespace C27_This2
{
    class Program
    {
        private static void Main(string[] args)
        {
            Character player = new Character("Player", 100, 20);
            Character oak = new Character("Oak", 60, 10);
            Character dwarf = new Character("Dwarf", 50, 30);
            Character poring = new Character("Poring", 10, 10);

            player.PrintString();
            oak.PrintString();
            dwarf.PrintString();
            poring.PrintString();

            Character[] arr = new Character[3];
            arr[0] = new Character("Elf", 30, 40);
            arr[1] = new Character("Slime", 10, 5);
            arr[2] = new Character("Goblin", 12, 12);

            for(int i = 0; i < 3; i++)
                arr[i].PrintString();
            
            foreach(Character character in arr)
                character.PrintString();

        }//Main
    }
}
```

### 1. 개별 객체 생성 및 출력

```csharp
Character player = new Character("Player", 100, 20);
Character oak = new Character("Oak", 60, 10);
Character dwarf = new Character("Dwarf", 50, 30);
Character poring = new Character("Poring", 10, 10);

player.PrintString();
oak.PrintString();
dwarf.PrintString();
poring.PrintString();
```

- 4개의 독립된 `Character` 인스턴스(player, oak, dwarf, poring)를 생성
- 각 인스턴스는 생성자 내부에서 자기 자신(`this`)을 캡슐화된 `Print` 객체로 전달하여 들고 있음
- `.PrintString()`을 호출하면 각 객체가 보유한 내부 `Print` 객체를 통해 자신만의 정보(이름, HP, 공격력)를 출력

### 2. 객체 배열(Array) 생성 및 초기화

```csharp
Character[] arr = new Character[3];
arr[0] = new Character("Elf", 30, 40);
arr[1] = new Character("Slime", 10, 5);
arr[2] = new Character("Goblin", 12, 12);
```

- Character 객체 3개를 담을 수 있는 참조형 배열 arr을 메모리에 할당
- 배열의 각 인덱스에 new Character(…)를 사용해 서로 다른 캐릭터 객체를 새로 생성하여 대입

### 3. 반복문을 활용한 배열 순회

- 배열에 담긴 객체들에 순차적으로 접근하여 정보를 출력

#### 1. `for` 문 사용

```csharp
for(int i = 0; i < 3; i++)
    arr[i].PrintString();
```

- 인덱스 변수 `i`를 0부터 2까지 증가시키며 `arr[i]` 요소의 `PrintString()`을 호출
- 인덱스 번호가 직접 필요하거나 특정 인덱스만 제어해야할 때 유용

#### 2. `foreach` 문 사용

```csharp
foreach(Character character in arr)
		character.PrintString();
```

- `arr` 배열 내부의 `Character` 객체를 처음부터 끝까지 하나씩 꺼내 `character` 변수에 할당하며 순회
- 인덱스 번호를 직접 다룰 필요 없이 깔끔하고 가독성이 뛰어남. 컬렉션/배열의 모든 요소를 단순 순회할 때 가장 권장되는 방식

## Character 클래스

- 데이터 저장, 생성자를 통한 초기화, 외부 클래스(Print)로 자기 자신(this)을 전달하여 출력 로직을 위임하는 구조로 설계

```csharp
using System.Threading;

class Character
{
    private string name = "";
    public string Name
    {
        get { return name; } 
        set { name = value; }
    }

    private float hp;
    public float Hp
    {
        get => hp;                                                                              set { hp = value; }
    }

    private float attack = 20;
    public float Attack
    {
        get { return attack; }
        set { attack = value; }
    }

    private Print print; //바로 new를 쓰지 않고 생성자에서 new로 초기화
    //선언부에는 일반적으로 new를 사용하진 않음
    public Character(string name, float hp, float attack)
    {
        this.name = name;
        this.hp = hp;
        this.attack = attack;
        //Console.WriteLine("생성자2");

        print = new Print(this); //캐릭터 객체 전체를 전달
    }

    public void PrintString()
    {
        string str = print.Execute();
        Console.WriteLine(str);
    }
}
```

### 1. 캡슐화와 프로퍼티

`name`, `hp`, `attack` 필드를 `private`로 지정해 외부의 직접적인 접근을 막고, `public` 프로퍼티를 통해 안전하게 데이터에 접근하거나 수정할 수 있게 만듦.

- `Name` / `Attack` : 표준적인 `get; set;` 형태
- `Hp` : `get ⇒ hp;` 형태의 람다식을 사용하여 간결하게 작성
- 초기값 설정 : `private string name = “”;` 와 `private float attack = 20;`처럼 필드 선언시 기본 값을 지정

### 2. 생성자와 `this` 키워드

```csharp
public Character(string name, float hp, float attack)
{
    this.name = name;
    this.hp = hp;
    this.attack = attack;

    print = new Print(this); 
}
```

- 매개변수와 필드 구분 : [`this.name](http://this.name) = name;` 처럼 `this`를 붙여 클래스의 멤버 변수(필드)와 생성자로 전달받은 매개변수의 이름이 같을 때 발생할 수 있는 혼동을 해결
- 지연 초기화 : `print` 객체를 필드 선언부에 바로 `new`로 생성하지 않고 생성자 내부에서 생성

//바로 new를 쓰지 않고 생성자에서 new로 초기화
//선언부에는 일반적으로 new를 사용하진 않음
`Character`의 데이터(`name`, `hp` 등)가 생성자 매개변수를 통해 완전히 채워진 직후에 `Print` 객체를 생성하는 것이 안전

- 자기 참조 전달(`this`) : `new Print(this)` 를 호출하여 현재 만들어지고 있는 `Character` 객체 인스턴스 그 자체를 `Print` 클래스로 넘겨줌.

### 3. 기능 위임(Delegation)

```csharp
public void PrintString()
{
    string str = print.Execute();
    Console.WriteLine(str);
}
```

- `Character` 클래스가 스스로 문자열 포맷팅 로직을 모두 처리하지 않고, 출력 문자열 생성을 `print` 객체의 `Execute()` 메서드에 위임.
- `PrintString()`을 호출하면 `Print` 객체가 조립해 준 문자열(str)을 받아와 콘솔에 출력만 담당

## Print 클래스

- 객체의 데이터를 전달받아 보기 좋은 문자열 형태로 포맷팅해 주는 역할

```csharp
class Print
{
    private Character character;

    public Print(Character character)
    {
        this.character = character;
    }

    public string Execute()
    {
        return
        $@"
            name : {character.Name},
            hp : {character.Hp},
            attack : {character.Attack}
        ";//@는 여러줄을 한줄로 묶어줌
    }
}
```

### 1. 단일 책임 원칙

- 데이터를 어떻게 출력용 문자열로 가공할지만 담당.
- 나중에 출력 양식을 바꿀 때 `Print` 클래스 내부만 수정하면 되므로 관리가 편리해짐

### 2. 생성자를 통한 객체 참조 저장

```csharp
private Character character;

public Print(Character character)
{
    this.character = character;
}
```

- 의존성 전달 : 생성자 매개변수로 `Character` 객체를 내부 `private` 필드인 `this.character`에 저장
- 데이터 접근 : 외부에서 직접 Character 정보를 바꾸지 못하도록 필드를 `private`로 캡슐화해 두고, `Execute()` 메서드 내에서만 안전하게 사용

### 3. 문자열 보간과 Verbatim 문자열($@””)

```csharp
public string Execute()
{
    return
    $@"
        name : {character.Name},
        hp : {character.Hp},
        attack : {character.Attack}
    ";//@는 여러줄을 한줄로 묶어줌
}
```

- `$` (문자열 보간, String Interpolation) : `{character.Name}`처럼 `{}` 안에 변수나 프로퍼티를 직접 넣어서 값을 출력 문자열에 동적으로 삽입
- `@` (Verbatim 문자열 리터럴) : 따옴표 안에서 줄바꿈(엔터)이나 공백, 탭 문자를 작성한 그대로 인식하도록 해줌
- `$@””` : 여러 줄로 구성된 템플릿 문자열 안에 객체의 프로퍼티 값을 깔끔하게 채워 넣어 반환

@ 키워드는 코드상의 공백과 탭도 그대로 출력 결과에 포함