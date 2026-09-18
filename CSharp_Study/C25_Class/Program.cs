namespace C25_Class
{
    class Program
    {            
        private static void Main(string[] args)
        {
            Character player = new Character();//생성자 : 클래스 이름과 같은 함수 \ 일반생성자가 선언되었기 때문에 기본 생성자 오류표시
            player.Name = "Player";
            player.Hp = 100;
            //player.Attack = 30;

            //player.Name = "Player2";
            //player.Hp = 80;

            Character monster = new Character(80); //초기 값을 설정해줄 때 생성자를 많이 이용함
            monster.Name = "Monster";
            monster.Hp = 50;

            Console.WriteLine($"Player Name: {player.Name}, Hp : {player.Hp}, Attack : {player.Attack}");

            string print = $"Player Name: {monster.Name}, Hp : {monster.Hp}, Attack : {monster.Attack}";
            Console.WriteLine(print);
            
            string print2 = monster.Print();
            Console.WriteLine(print2);

            string print3 = player.Print();
            Console.WriteLine(print3);

            Character Oak = new Character("Oak", 50, 10);
            Console.WriteLine(Oak.Print());
        }//Main
    }
}
/*
 디버깅
F9로 중단점 설정
F5로 실행해서 조사식에 확인 필요한 변수 입력 후 F5 누르면서 한단계씩 추척하기
 */

//클래스가 나오면 생성자가 반드시 나옴