# [C13_Array](../CsharpStudy_List.md)

```csharp
using System;

namespace C13_Array
{
    class Program
    {
        private static void Main(string[] args)
        {
            int[] arr = new int[5]; //배열 선언 방법

            arr[0] = 11;
            arr[1] = 50;
            arr[2] = 20;
            arr[3] = 15;
            arr[4] = 5;

            for(int i =0; i < 5; i++)
                Console.WriteLine($"arr[{i}] = {arr[i]}");

            for (int i = 0; i < arr.Length ; i++)
                Console.WriteLine($"arr[{i}] = {arr[i]}");

            Random random = new Random();

            for(int i = 0; i < 10; i++)
            {
                int rand = random.Next(1, 10);

                Console.WriteLine($"{i}번째 난수 : {rand}");
            }

            byte[] rands = new byte[10];
            random.NextBytes(rands);

            for (int i = 0; i < rands.Length; i++)
            {
                Console.WriteLine($"배열 {i}번째 난수 : {rands[i]}");
            }

            int[] arr2 = new int[] { 20, 5, 10, 30, 20 };
            for (int i = 0; i < arr2.Length; i++)
                Console.WriteLine($"arr2[{i}] = {arr2[i]}");
        }//Main
    }
}
```

- 배열(array): 연속된 메모리 공간에 동일한 타입의 데이터들을 순차적으로 나열한 선형 자료구조

```csharp
int[] arr = new int[5]; //선언
arr[0] = 11;
arr[1] = 50;
arr[2] = 20;
arr[3] = 15;
arr[4] = 5; //초기화

int[] arr2 = new int[] { 20, 5, 10, 30, 20 }; 
//선언과 동시에 대입:초기화, 크기를 적지 않아도
//초기화 값으로 크기 맞춰짐
```

- int형으로 크기가 5인 배열 arr 선언 후 초기화
- arr.Length : 배열의 크기 반환

### Random Class

- `Random random = new Random();` : 랜덤 타입의 random이라는 객체 생성
- `random.Next(1, 10);` : 1~10 사이의 임의의 정수를 반환하는 메서드(멤버 함수)
- `random.NextBytes(rands);` : byte 타입의 배열인 rands에 임의의 값을 채워넣는 메서드