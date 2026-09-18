# [C29_Casting](../CsharpStudy_List.md)

```csharp
void Test()
{
		int a = 10; //컴파일 시 메모리내 구역이 정해짐, 자동할당
		Player p; //자동 할당
		p = new Player(); //프로그램 실행 중에 구역이 할당됨. 동적할당
		Player p = new Player();
		p.b = 20;
		Character c = (Character)p; //자식 자료형에서 부모 자료형으로 형변환 -> 업캐스팅
		c.a=110;
		c.b=20; //불가능
		Player p2 = (Player)c;//다운 캐스팅(부모자료형으로 올라갔을때만 원래 자료형으로 내려오기 가능)
		p2.b=50;
		Monster m = (Monster)p; //불가능(부모만 같지 다른 자료형)
		Monster m2 = (Monster)c; //불가능
}
```

### 1. 메모리 할당(스택 vs 힙)

```csharp
int a = 10; //값 타입(스택 영역에 자동 할당)
Player p; //참조 변수(스택 영역에 참조 주소용 공간 할당)
p = new Player(); //참조 타입 객체(힙 영역에 동적 할당, 스택의 p가 주소를 가리킴)
```

- 값 타입(int 등) : 컴파일 시 크기가 정해지며, 스택(Stack) 메모리에 값이 직접 저장되고 함수가 끝나면 자동으로 해제됨
- 참조 타입(Player 객체) : new 키워드를 사용하는 순간 프로그램 실행 중(런타임)에 힙 메모리에 동적으로 공간이 할당되며 변수 p는 힙 메모리의 주소값을 가지고 있음

### 2. 업캐스팅(Upcasting) : 자식 → 부모

```csharp
Player p = new Player();
p.b = 20;
Character c = (Character)p; //자식(Player) -> 부모(Character) 형변환 (업캐스팅)
c.a=110;//가능(Character에 존재하는 멤버)
c.b=20; //불가능(Character 타입 시야에는 b가 보이지 않음)
```

- 항상 안전함 : 자식은 부모의 모든 특성을 포함하므로 암시적 변환이 가능. `(Character)` 를 생략해도 됨.
- 접근 제한 : 힙 메모리 상에는 여전히 `Player` 전체 객체가 존재하지만, 변수 `c`의 타입이 `Character`이므로 부모 클래스에 정의된 멤버(`a`)만 접근 가능

### 3. 다운캐스팅(Downcasting) : 부모 → 자식

```csharp
Player p2 = (Player)c;//부모(Character) -> 원래 자식(Player) 형변환(다운캐스팅)
p2.b=50;//가능(Player 타입으로 복원되어 b가 다시 보임)
```

- 조건부 가능 : 주석에 적어주신 대로 실제 힙 메모리의 알맹이가 원래 `Player` 객체였을 때만 원상복구 가능
- 다운캐스팅을 거치면 원래 자식 클래스에 있던 고유 멤버(`b`)에 다시 접근 가능

### 4. 형제 클래스 간 형변환 불가

```csharp
Monster m = (Monster)p; //컴파일 에러 또는 런타임 에러 (Player -> Monster 불가)
Monster m2 = (Monster)c; //런타임 에러 (c의 실제 알맹이는 Player이므로 Monster 변환 불가)
```

- 상속 관계 불일치 : `Player`와 `Monster`는 같은 `Character`를 부모로 둔 형제 관계일 뿐, 서로 간에는 아무런 상속/포함 관계가 없음
- `c` 변수 타입이 `Character`일지라도, 실제 힙에 생성된 객체는 `Player`이므로 `Monster`로 다운캐스팅을 시도하면 `InvalidCastException` 예외가 발생