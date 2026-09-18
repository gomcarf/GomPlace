using System;
using System.Numerics;

namespace C21_Structure2
{
    class Program
    {
        private struct Character
        {
            public string Name; //멤버변수(구조체 내부에 있는 변수)
            public float Hp; //private : 선언된 내부에서만 사용 가능. 외부에서 사용 불가
            public float Attack;

            public string GetData()
            {
                string temp = $"Name : {Name}, Hp : {Hp}";

                return temp ;
            }

            public void Damage(float InAmount)
            {
                Hp -= InAmount;
                Hp = Math.Clamp(Hp, 0, 100); //값을 제한하는 메소드. 0f와 100f 사이로 hp 제한
            }
        }

        private static void Main(string[] args)
        {
            Character player;
            player.Name = "Player";
            player.Hp = 100;
            player.Attack = 10; 

            Console.WriteLine(player.GetData());

            Character monster;
            monster.Name = "Oak";
            monster.Hp = 30;
            monster.Attack = 5;
            Console.WriteLine(monster.GetData());

            Console.WriteLine();

            string[] names = new string[]
                {
                    "Goblin", "Dwarf", "Poring",
                };
            Character[] monsters = new Character[3];
            for (int i = 0; i < monsters.Length ; i++)
            {
                monsters[i].Name = names[i];
                monsters[i].Hp = (i+1)*10;
                monsters[i].Attack = 3;
            }

            foreach(string name in names) //names에 있는 0번째를 name에 입력 foreach: 배열 반복문 할 때 유용! foreach(배열의타입 별명 in 배열이름)
                Console.WriteLine(name);
            
            Console.WriteLine();

            foreach(Character m in monsters)
                Console.WriteLine(m.GetData());
            
            while(true)
            {
                Console.Write("공격할 몬스터 : ");
                int number = int.Parse(Console.ReadLine()!);

                if (number < monsters.Length) //number가 monsters 배열의 길이(3)보다 작으면 0,1,2 중 하나
                    monsters[number].Damage(player.Attack);
                else if (number == monsters.Length)//number == 3 -> 오크를 공격할 경우
                    monster.Damage(player.Attack);
                else
                    break;

                    foreach (Character m in monsters)
                        Console.WriteLine(m.GetData());

                Console.WriteLine(monster.GetData());
            }//while
                        
        }//Main
    }
}

/*
 * 객체지향의 특징
 * 1. 캡슐화(블랙박스화)
 * 2. 정보은닉성 : 공개할 건 공개, 숨길 건 숨기자(private)
 * 3. 상속성 : 
 * 4. 추상성 :
 * 5. 다형성 :
 * 
 * 
 * 클래스
 */