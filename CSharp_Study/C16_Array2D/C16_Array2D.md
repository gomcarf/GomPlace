# [C16_Array2D](../CsharpStudy_List.md)

```csharp
using System;

namespace C16_Array2D
{
    class Program
    {
        private static void Main(string[] args)
        {
            int[,] a = new int[2, 3]
            {
                {1, 2, 3 },
                {4, 5, 6 },
            };

            for(int row = 0; row < a.GetLength(0); row++) //GetLength(0) 행 갯수
            {
                for (int col = 0; col < a.GetLength(1); col++) //GetLength(1) 열 갯수
                    Console.Write($"a[{row},{col}]={a[row, col]}  ");
                Console.WriteLine();
            }
            Console.WriteLine();

            int[][] arr = new int[3][];
            arr[0] = new int[2] { 1, 2 };
            arr[1] = new int[4] { 3, 4, 5, 6 };
            arr[2] = new int[3] { 7, 8, 9 };

            for(int row = 0; row< arr.Length; row++)
            {
                for(int col = 0; col < arr[row].Length ; col++)
                {
                    Console.Write($"arr[{row}][{col}] = {arr[row][col]}  ");
                }

                Console.WriteLine();
            }

        }//Main
    }
}
```

### 2D Array(2차원 배열)

- 1차원 배열을 모아둔거
    - 2차원 배열 모아두면 3차원 배열
    - 3차원 배열을 잘 쓰지는 않지만 있다고 알아두자.
- 행 - row 세로개수
렬 - col 가로개수
- 중첩 for문으로 이중 배열 접근 가능

```csharp
for (int i=0 ; i<5; i++)
	for(int j=0 ; j<5 ; j++)
		arr[i][j] = i*j;
```

1. 고정형 2차원 배열 선언

```csharp
int[,] a = new int[2,3]
{
    {1, 2, 3},
    {4, 5, 6},
};
```

- 행마다 열의 크기가 반드시 같아야 함.
- 2x3 사이즈의 2차원 배열을 초기화
- `GetLength()` : 다차원 배열(Multi-dimensional Array)에서 특정 차원(방향)의 길이(요소 개수)를 가져오는 메서드
    - `a.GetLength(0)`: 배열의 첫 번째 차원(행, Row)의 개수 ⇒ 2 반환
    - `a.GetLength(1)`: 배열의 두 번째 차원(열, Column)의 개수 ⇒ 3반환

1. 가변형 2차원 배열 선언

```csharp
int[][] arr = new int[3][];
            arr[0] = new int[2] { 1, 2 };
            arr[1] = new int[4] { 3, 4, 5, 6 };
            arr[2] = new int[3] { 7, 8, 9 };
```

- 행은 3행이지만 열은 고정되어 있지 않고 자유롭게 이용 가능
- 반복문 돌릴 때 조건문에는 arr[row].Length를 사용해서 값이 들어있는 만큼 알아서 크기 반환