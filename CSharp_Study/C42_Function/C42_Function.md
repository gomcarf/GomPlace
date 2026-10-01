# [C42_Function](../CsharpStudy_List.md)

- 여러 개의 최소값 검사 조건을 한 번에 넘겨서, 조건에 걸리는 첫 번째 메세지를 출력하는 검증 구조를 만든 예제.

```csharp
class Program
{
    struct MinString
    {
        public float Value;
        public float Compare;
        public string Text;
    }

    private static bool Print(params MinString[] minString)
    {
        for(int i = 0; i < minString.Length; i++)
        {
            MinString item = minString[i];

            if(item.Value < item.Compare)
            {
                Console.WriteLine(item.Text);
                return true;
            }
        }

        return false;
    }

    private static void Main(string[] args)
    {
        MinString minString = new MinString()
        {
            Value = 5.0f,
            Compare = 10.0f,
            Text = "입력한 값은 10 이상이어야 합니다"
        };

        MinString minString2 = new MinString()
        {
            Value = 2.0f,
            Compare = 5.0f,
            Text = "입력한 값은 10 이상이어야 합니다"
        };

        while(true)
        {
            if (Print(minString, minString2) == false)
                break;
        }
        
    }
}
```

### MinString 구조체

```csharp
struct MinString
{
    public float Value;     // 검사할 값
    public float Compare;   // 기준값
    public string Text;     // 조건에 걸렸을 때 출력할 메시지
}
```

- `struct`는 값 타입이라 복사해서 전달됨
- 클래스 안에 선언된 중첩 구조체라 접근 제한자를 안 붙이면 `private`. `Print`도 `private`이라 매개변수로 써도 문제 X

### Print 메서드

```csharp
private static bool Print(params MinString[] minString)
{
    for (int i = 0; i < minString.Length; i++)
    {
        MinString item = minString[i];
        if (item.Value < item.Compare)
        {
            Console.WriteLine(item.Text);
            return true;
        }
    }
    return false;
}
```

- `params`는 인자를 개수 제한 없이 쉼표로 나열하면 컴파일러가 배열로 묶어주는 키워드. `Print(a, b)`처럼 호출할 수 있고, 배열을 직접 넘겨도 됨.
- 앞에서부터 차례로 `Value < Compare`인지 검사.
    - 조건에 걸리면 그 항목의 메시지를 출력하고 즉시 `true` 반환. 뒤의 항목은 검사 X
    - 끝까지 하나도 안 걸리면 `false`를 반환.
- 즉 반환값의 의미는 문제가 발견되어 메시지를 출력했는가? 임

### Main

```csharp
MinString minString = new MinString()
{
    Value = 5.0f, Compare = 10.0f, Text = "입력한 값은 10 이상이어야 합니다"
};
```

- 객체 초기화 구문으로 필드를 채움. `5.0f`는 `f`의 float 리터럴이라는 뜻

|  | Value | Compare | `Value < Compare` |
| --- | --- | --- | --- |
| minString | 5 | 10 | **true** |
| minString2 | 2 | 5 | **true** |

```csharp
while (true)
{
    if (Print(minString, minString2) == false)
        break;
}
```

### 정리

- `params`로 여러 검사 조건을 한 번에 넘기고, 처음 위반한 조건의 메시지만 출력하는 구조
- 반환값 `true`는 위반 있음, `false`는 모두 통과
- 현재 Main은 값이 고정되어 있어 무한 루프이므로, 루프 안에서 값을 갱신해야 함