# [C02_DataType](../CsharpStudy_List.md)

```csharp
using System;

namespace C02_DataType
{
    class Program
    {
        private static void Main(string[] args)
        {
            byte a = 10; //1byte=8bit 0~255까지 표현, 음수x, 256이면 overflow 일어나서 0으로 출력 -1이면 underflow 일어나서 255출력
                        Console.WriteLine("a = " + a); // "~~"<-문자열

            unchecked //overflow, underflow 허용
            {
                byte b = (byte)257; //overflow
                Console.WriteLine("b = " + b);

                byte c = (byte)-3; //underflow
                Console.WriteLine("c = " + c);
            }//unchecked

            sbyte d = -10; //sbyte(signed byte)  -128~127까지 표현
            Console.WriteLine("d = " + d);

            unchecked
            {
                sbyte e = (sbyte)129; //overflow
                Console.WriteLine("e = " + e);

                sbyte f = (sbyte)-129; //underflow
                Console.WriteLine("f = " + f);
            }//unchecked
        }//Main
    }
}
```

- Byte : 1바이트 정수형(8 bit), 0~255(2^8-1)까지 표현, 음수 없음
- Sbyte: 1바이트 정수형, -128~127 표현, 음수 있음
- Int : 4바이트 정수형(32 bit), 음수 있음, -2,147,483,648(-2^32) ~ 2,147,483,647 표현 가능
- float(scalar, single) : 4바이트 실수형, 음수 있음
    - 접미사 f는 반드시 붙여야 함
    - float이 가질 수 있는 소숫점 자리 8개가 일반적
- double : 8바이트 실수형, 배정도 실수
    - 접미사 안붙임. 붙인다면 L
- unchecked : overflow, underflow 허용