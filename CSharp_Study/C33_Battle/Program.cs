using System.Collections.Generic;
using System;
using System.Security.Cryptography.X509Certificates;

namespace C33_Battle
{
    class Program
    {
        private static void Main(string[] args)
        {
            Random random = new Random(); //seed를 가지고 클라이언트와 서버간 랜덤 싱크를 맞춤
            Console.WriteLine(random.Next()); //0~int.MaxValue-1 난수 발생
            Console.WriteLine(random.Next(10, 100)); //min, max-1사이의 난수 발생
            Console.WriteLine(random.NextSingle()); //0.0f~1.0f사이의 난수 발생


            string name;
            int hp;
            int power;
            int up;

            Console.WriteLine("이름, 체력, 공격력, 강화력을 입력하세요");
            string str = Console.ReadLine()!;

            str = str.Replace(" ",""); //공백을 없애는 함수
            //Console.WriteLine(str);

            string[] arr = str.Split(","); //문자열을 파라미터 기준값으로 잘라서 배열로 반환
            //foreach (string temp in arr)
            //    Console.WriteLine(temp);

            name = arr[0];
            int.TryParse(arr[1], out hp); //TryParse: 문자열이 다른 자료형으로 바뀔 수 있는지 보고 변환 후 hp에 저장. 반환했더니 안되네 0으로 초기화해서 hp저장 //hp = int.Parse(arr[1]); //arr[1]이 숫자가 아닌 값이 입력될 경우 예외 발생.             // Parse는 무조건 바뀐다는 전재하에 바꾸기(예외 발생하면 예외 문구 출력)            //out : 값을 넘겨 주지는 않고 값만 return 받을 때 사용            //ㄴhp 초기화 안해도 에러가 나지 않았다. 
            int.TryParse(arr[2], out power);
            int.TryParse(arr[3], out up);

            Player player = new Player(name, hp, power, up);

            List<Monster> monsterList = new List<Monster>();
            //while (true) //for문이면 몬스터 개수가 고정적임. 무한 루프를 통해 크기가 가변적인 List 생성
            //{
            //    Console.WriteLine("몬스터의 이름, 체력, 공격력을 입력하세요.");
            //    str = Console.ReadLine()!;
            //    if (str.Length < 1)
            //        break;

            //    str = str.Replace(" ", "");
            //    arr = str.Split(",");
            //    name = arr[0];
            //    int.TryParse(arr[1], out hp);
            //    int.TryParse(arr[2], out power);

            //    //Monster monster = new Monster(name, hp, power);
            //    monsterList.Add(new Monster(name, hp, power)); //배열은 대입이었지만 List는 몇번째인지 모르니까 추가의 개념으로 Add 사용
            //}

            str = "가나다라마바사아자차카타파하";

            for(int i = 0; i < random.Next(5, 10 + 1); i++) //최소 5마리부터 최대 10마리
            {
                int[] nameNumbers = new int[3];
                nameNumbers[0] = random.Next(0, 14); //0 ~ 13
                nameNumbers[1] = random.Next(0, 14);
                nameNumbers[2] = random.Next(0, 14);

                string monsterName = "";
                monsterName += str[nameNumbers[0]]; //몬스터 이름 랜덤 생성
                monsterName += str[nameNumbers[1]];
                monsterName += str[nameNumbers[2]];

                hp = random.Next(10,50 + 1); //몬스터 hp 랜덤 생성
                power = random.Next(10, 50 + 1); //몬스터 공격력 랜덤 생성

                monsterList.Add(new Monster(monsterName, hp, power)); //몬스터 리스트에 랜덤 생성한 몬스터 추가
            }

            Console.WriteLine();

            for (int i = 0; i < monsterList.Count; i++)
            {
                Monster m = monsterList[i];
                Console.WriteLine($"{i}번째 이름 : {m.Name}, 체력 : {m.Hp}, 공격력 : {m.Power}");
            }

            Console.WriteLine();

            while (true)
            {
                Console.Write("공격할 몬스터 번호 : ");
                string input = Console.ReadLine()!;

                int monsterNumber;
                int.TryParse(input, out monsterNumber);

                if (monsterNumber < 0 || monsterNumber >= monsterList.Count)
                {
                    Console.WriteLine("몬스터 번호를 잘못 입력했습니다.");

                    continue;
                }

                player.Attack(monsterList[monsterNumber]);

                monsterNumber = random.Next(0, 10 + monsterList.Count + 1);
                if (monsterNumber >= monsterList.Count)
                    continue;

                monsterList[monsterNumber].Attack(player);

                if (player.Hp < 0)
                {
                    Console.WriteLine("플레이어 사망!!!");
                    Console.WriteLine("Game Over!");

                    break;
                }

            }
            /*
             * 추상화(abstract)
             * -이름만 명시하고 몸체는 없음
             * 이름은 너희가 이걸로 쓰고 몸체는 알아서 정의해라
             * 대신 무조건 써야대
             */

            /* ref와 out 테스트*/
            {
                //int a = 10, b = 20; //초기화 안하면 에러
                //TestRef(ref a, ref b);
                //Console.WriteLine($"a = {a}, b = {b}");

                //int c = 5, d; //초기화가 되지 않아도 에러x
                //TestOut(out c, out d); //d는 여기서 대입이 일어나기 때문
                //Console.WriteLine($"c = {c}, d = {d}");
            }

        }//Main

        /* ref와 out 테스트*/
        //private static int TestOut() //return이 1개인 경우
        //{
        //    int a = 10;
        //    return a;
        //}
        //private static void TestRef(ref int val1, ref int val2) //return이 2개 이상인 경우 reference 사용
        //{
        //    val1 += 10;
        //    val2 += 20;
        //}

        //private static void TestOut(out int val1, out int val2) //함수에서 처리해서 값만 여러개 돌려줄 때 out 사용
        //{
        //    val1 = 10;
        //    val2 = 20;
        //}
    }
}