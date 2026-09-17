# [C03_Variable](../CsharpStudy_List.md)

```csharp
using System;

namespace C03_Variable
{
    class Program
    {
        private static void Main(string[] args)
        {
            int a = 10; //4byte => 2^32 -> 32bit, 부호 ㅇ(signed)
            int b = 20;
            int c = a + b;

            Console.WriteLine("a = " + a + ", b = " + b + ", c = " + c);
            Console.WriteLine($"a = {a}, b = {b}, c = {c}"); //상위 명령 줄이랑 동일한 출력 => format string(포맷 스트링: 양식 문자열)

            float pi = 3.14f;
            Console.WriteLine("pi = " + pi);

            int f = (int)pi; //(자료형) casting 연산자 자료 형변환=casting.
            Console.WriteLine("f = " + f);
            
            float i = (float)f;
            Console.WriteLine("i = " + i);
        }//Main
    }
}
/*
 * CPU //a+b 해서 c에 전달 GPU
 *  |                       |
 * RAM //a, b, c공간 생성 -VRAM
 *  |
 * SSD //.exe
 */
```

- $ : 문자열 보간(String Interpolation), 문자열 앞에 `$`를 붙이면 문자열 내부에 `{}`(중괄호)를 사용해 C# 변수나 식을 직접 집어넣을 수 있게 해줌.
- @ : 문자열 내의 백슬래시(`\`), 특수 문자나 줄 바꿈을 있는 그대로 표현(Verbatim String)할 때 사용.

```csharp
string folder = "Downloads";
string file = "test.txt";

// \를 \\로 쓰지 않아도 되고, 줄바꿈도 그대로 인식됨 (C# 8.0 이상에서는 $@ 및 $ दोनों 가능)
string path = $@"C:\Users\{folder}\{file}";

string multiLine = $@"안녕하세요,
{name}님!
환영합니다.";
```

- “””(Raw String Literals (원시 문자열 리터럴)) : 따옴표(`"`)나 JSON 구문 같은 특수문자를 따옴표 처리(`\"`) 없이 그대로 쓸 수 있으며, `$`의 개수를 늘려 보간 기호를 커스텀할 수 있음.