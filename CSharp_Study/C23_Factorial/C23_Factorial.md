# [C23_Factorial](../CsharpStudy_List.md)

```csharp
namespace C23_Factorial
{
    class Program
    {       
        private static int Factorial(int x)
        {
            int result = 0;
            Console.WriteLine($"시작 : x = {x}");

            if (x == 1)
                result = 1;
            else
                result = x * Factorial(x - 1);

            Console.WriteLine($"완료 : x = {x}, result = {result}");

                return result;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine($"최종 값 : {Factorial(4)}");
        }//Main
    }
}
/* 재귀 함수 : 본인 함수 내에서 본인 함수를 호출하는 것
 * 스택 : LIFO (Last In First Out)
 * F(2)
 * 2 * F(2-1)
 *     F(1)
 *     return  result = 1;
 */
```

- **재귀 함수(Recursive Function)** : 자기 자신을 다시 호출하여 문제를 해결하는 함수
    - 기저 조건 (Base Case / 종료 조건): 재귀 호출을 멈추고 값을 반환하는 조건입니다. 이 조건이 없으면 함수가 자기 자신을 무한히 호출하여 프로그램이 튕기게 됩니다(`StackOverflowException`).
    - 재귀 단계 (Recursive Step): 자기 자신을 호출하는 부분으로, 호출할 때마다 매개변수가 기저 조건에 가까워지도록 변화해야 합니다.
    - 메모리의 콜 스택(Call Stack) 구조를 활용 : 함수가 호출될 때마다 메모리에 차곡차곡 쌓이고, 종료 조건을 만나면 나중에 쌓인 함수부터 거꾸로 실행을 마침

| **구분** | **내용** |
| --- | --- |
| **장점** | • 코드가 직관적이고 깔끔해집니다.<br>• 트리(Tree), 그래프 탐색, 팩토리얼, 하노이의 탑 등 복잡한 구조를 쉽게 표현할 수 있습니다. |
| **단점** | • 메모리 오버헤드: 함수를 호출할 때마다 스택 메모리를 사용하므로 메모리 소비가 큽니다.<br>• 속도 저하: 반복문(`for`, `while`)보다 함수 호출 과정이 추가되어 실행 속도가 느릴 수 있습니다.<br>• 스택 오버플로우: 재귀 깊이가 너무 깊어지면 메모리가 부족해 프로그램이 강제 종료됩니다. |
- 스택 : LIFO ( Last In First Out)
    - 데이터를 차곡차곡 쌓아 올린 형태의 선형 자료구조
    - 데이터의 입구와 출구가 동일한 한쪽 끝에서만 작업이 이루어집니다.
        - **Push** : 스택의 맨 위에 데이터를 추가합니다.
        - **Pop** : 스택의 맨 위에 있는 데이터를 제거하고 반환합니다.
        - **Peek (Top)** : 맨 위의 데이터를 제거하지 않고 무엇이 있는지 확인만 합니다.
        - **IsEmpty** : 스택이 비어있는지 확인

| **구분** | **내용** |
| --- | --- |
| **장점** | 데이터의 삽입과 삭제가 한쪽 끝에서만 일어나므로 속도가 매우 빠릅니다 ($O(1)$). |
| **주의점** | • 중간에 있는 데이터에 직접 접근할 수 없습니다.<br>• 메모리 크기가 제한된 스택에 데이터를 계속 넣으면 **스택 오버플로우(Stack Overflow)**가 발생합니다. |