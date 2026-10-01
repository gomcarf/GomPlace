class Program
{
    class Character { }
    class Player : Character { }
    class Monster : Character {}


    private static void Main(string[] args)
    {
        //reference 타입 - Nullable

        //value type - Nullable(x)
        //int a = 0;
        //if(a != null)
        //{

        //}

        int? a = null; //Nullable Value type(Null 값이 들어갈 수 있음)
        if (a.HasValue)//a가 값을 가지고 있는지 판단해서 반환하는 프로퍼티
            Console.WriteLine("a값 있음");
        else
            Console.WriteLine($"a값 없음 : {a}");

        int? b = 10;
        if (b.HasValue)
            Console.WriteLine($"b값 있음 : {b}");
        else
            Console.WriteLine($"b값 없음 : {b}");

        int? c = 20;
        int d = c.Value; //c에 값이 있기 때문에 문제 없이 대입됨. 하지만 null일 경우를 대비하여 널 병합 연산자 사용 필수**꼭 기억해**
        Console.WriteLine($"d값 : {d}");

        int? e = null;
        int f = e ?? -1;//null이 아니면 그냥 값이 나오고, null이면 뒤의 숫자가 출력됨
        Console.WriteLine($"f값 : {f}");


        //reference type - string(//널 포용 연산자)        
        string? str = null; //Nullable reference type
        
        if(str != null)//is not null
            Console.WriteLine($"str값 있음 : {str}");
        else
            Console.WriteLine($"str값 없음 : {str}");

        //Console.Write("문자열 입력 : ");
        //string str3 = Console.ReadLine()!;//null 허용 연산자: null이어도 받아줘라
        //Console.WriteLine($"str3 : {str3}");

        int? g = null; //ref 타입
        int h = 10; //Value 타입
        g = h; //Value -> Reference : Boxing**(여러 처리를 하고 메모리 공간을 마련해줘야 하기 때문에 느린 연산)
        int i = g.Value; //Reference -> Value : Unboxing**(삭제하고 되돌리기만 하면 되지만 일반적인 대입 치고는 느린 연산)
        int j = (int)g; //Unboxing
        //일상 최적화 1: 박싱/언박싱을 최소화해야함(Nullable도 최소화로 사용하는 게 좋음)***

        int? k = null;
        //int l = (int)k++; //값이 할당되었을 때만 가능한 연산


        //is 연산자: 해당 자료형으로 변환이 가능하느냐(ref 타입)
        int? m = 0;
        Console.WriteLine($"m : {m is int}"); //결과: True
        Console.WriteLine($"m : {m is int?}"); //결과: True

        Player player = new Player();
        Console.WriteLine($"player : {player is Character}"); //결과: True

        Monster monster = new Monster();
        Console.WriteLine($"monster : {monster is Character}");//결과: True

        Character character = (Character)player;
        Console.WriteLine($"character -> Player : {character is Player}");//결과: True
        Console.WriteLine($"character -> Monster : {character is Monster}");//결과: False

        int? n = 10;
        int? o = null;
        Console.WriteLine($"n >= null : {n >= null}"); //false, 비교불가
        Console.WriteLine($"n == null : {n == null}"); //false
        Console.WriteLine($"n != null : {n != null}"); //true

        Console.WriteLine($"o >= null : {o >= null}"); //false, 비교불가
        Console.WriteLine($"o == null : {o == null}"); //True

        int? p = 10;
        Console.WriteLine(p is int); //True p는 int?이지만 값이 할당되어 있으므로 int로 변환 가능
        Console.WriteLine(p is int?); //true p는 int?이므로 int?로 변환 가능

        int? q = null;
        Console.WriteLine(q is int); //False q은 int?이지만 값이 할당되어 있지 않으므로 int로 변환 불가능
        Console.WriteLine(q is int?); //false q는 null이므로 int?로 변환 불가(null은 어떤 값 타입의 인스턴스도 아니기 때문)
    }
}