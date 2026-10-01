class Program
{
    private static void Main(string[] args)
    {
        Lambda lambda = new Lambda();
        lambda.Case1();
        lambda.Case2();
        lambda.Case3();
        lambda.Case4();
        lambda.Case5();
        lambda.Case6();
        lambda.Case7();
    }
}
/*
 void Test3(){}
람다로 변경하면
() => //람다를 시작한다는 기호

Action<int, string> action = (/int/ a, /string/ b)//자료형도 생략가능, 생략한다면 앞의 delegate 자료형으로 매핑해서 인식(delegate 반드시 필요, 람다 독단 사용 불가)
{ Constole.WrtieLine( ); }
action.Invoke; //Invoke도 생략하고 함수 형식으로 호출 가능 '3'

 */