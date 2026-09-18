# [C22_Reference](../CsharpStudy_List.md)

## 객체지향

### 특징

1. 캡슐화 - 함수
2. 정보은닉성 - 기본적으로 private
3. 상속성
4. 추상성
5. 다형성

### 값형식

- 구조체 : 간단 데이터 저장 . 클래스와 반대 , 구조체는 값형식(배열은 빼고)(구조체는 간단한 데이터를 대상으로 권장)

```csharp
struct A{ public string Name; }
A a;//값 형식
a.Name = "a";
int a = 10;
a[10]//(100번지)
```

```csharp
int a = 10;
int b = 20;
int c = a+b;
```

ssd에 있는 .exe파일 실행 → 프로세스 생성

프로세스가 RAM에 올라와 구역 생성(CODE 구역, DATA구역, 힙, 스택)

***지역변수는 스택에 저장됨(꼭 기억해) → 값 형식으로 저장***

스택에 저장되는 지역변수는 값 형식

RAM에 생성된 구역은 프로세스 종료 시 모두 소멸(값 형식 변수 모두 소멸)

### 참조형식

- 클래스: 데이터와 행동을 묶는 개념은 구조체와 유사. 하지만 클래스는 참조 형식

```csharp
int r /*지역변수*/ = new int();
r = 10;
```

```csharp
class A{ private string Name; }
A a = new A(); //참조형식
a.Name = "a";
int a = new int();
a= 10;
a 100번지(주소)  ---> 100번지 10   //c의 포인터 개념
```

- 클래스 : 복잡한 데이터와 기능 저장 필요 -> `private`를 `default`로 외부의 접근을 일단 막고 공개할 것만 `public` 처리하여 부분적으로 공개
- `new` : 뒤에 붙는 자료형의 크기 만큼 heap에 할당하고 주소(16진수, 0X를  붙임)를 r에 저장
- 주소를 참조해서 사용→참조형식
- 자기 구역 종료시 지역 변수 `int r`은 소멸, HEAP에 할당된 영역은 해제되지 않음(c의 경우는 직접 해제해줘야함) c#은 garbage collector 가 돌면서 사용되지 않은 공간은 모두 삭제
- !!배열은 무조건 참조형식!!

```jsx
int [] arr = new int[5];
```

- `ref` 키워드를 사용해 값 형식을 참조로 전달하는 방식

```csharp
namespace C22_Reference
{
        class Program
    {
        private static void Multiply(int[] values)
        {
            for (int i = values.Length - 1; i >= 0; i--)
            {
                values[i] = values[i] * 10;
            }
        }

        private static void Test(ref int a)
        {
            a *= 10;
        }
        private static void Main(string[] args)
        {
            //값형식 : 정적할당
            //참조형식 : 동적할당(new)

            //int[] arr = new int[] { 1, 2, 3, 4, 5 };
            int[] arr = { 1, 2, 3, 4, 5 };
            Multiply(arr);

            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"arr[{i}] = {arr[i]}");
            }

            int r = new int(); //참조형식 x
            r = 1;
            Test(ref r);
            Console.WriteLine($"r = {r}");
        }//Main
    }
}
```

1. 참조 형식(Reference Type)과 배열 : Multiply 메서드

```csharp
private static void Multiply(int[] values)
{
    for (int i = values.Length - 1; i >= 0; i--)
    {
        values[i] = values[i] * 10;
    }
}
```

- 동작 원리 : arr 배열을 Multiply 메서드로 전달할 떄, 배열의 실제 값이 복사되는 것이 아니라 배열이 위치한 메모리 주소(참조)가 전달됨
- 결과 : Multiply 함수 내부에서 values[i]의 값을 변경하면, Main 메서드의 원본 arr 배열의 값도 함께 10, 20, 30, 40, 50으로 변경됨
- 역순 반복문 : i = values.Length-1 부터 i≥0까지 감소하며 배열의 마지막 인덱스부터 역순으로 탐색하지만, 모든 요소에 10을 곱하는 결과는 동일
1. 값 형식(Value Type)과 ref 키워드 : Test 메서드

```csharp
int r = new int(); // int의 기본값인 0으로 초기화됨
r = 1;
Test(ref r);
Console.WriteLine($"r = {r}");
```

- new int() 의 의미 : 주석에 적혀 있듯 new 키워드를 썼더라도 int는 참조 형식이 아닌 값 형식. new int()는 단지 0으로 기본 초기화하는 역할
- ref 키워드 : 값 형식인 int 변수는 원래 메서드로 전달될 때 값이 ‘복사’되어 원본이 변하지 않음. 하지만 ref 키워드를 붙이면 원본 변수의 메모리 주소를 직접 전달
- 결과 : Test(ref r)을 호출하면 r 변수 자체가 참조로 넘어가므로, 메서드 안에서 a *= 10을 수행했을 때 원본 r의 값이 10으로 직접 변경됨
1. 실행 결과

```csharp
arr[0] = 10
arr[1] = 20
arr[2] = 30
arr[3] = 40
arr[4] = 50
r = 10
```