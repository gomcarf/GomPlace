namespace C12_Loop
{
    class Program
    {
        private static void Main(string[] args)
        {
            int monsterHp = 100;

            int weakAttack = 5;
            int baseAttack = 10;
            int strongAttack = 25;

            while (true)
            {
                Console.Write("공격 방법(종료 - 99) : ");
                int select = int.Parse(Console.ReadLine()!);

                if (select == 99)
                    break;

                switch(select)
                {
                    case 1:
                    {
                        monsterHp -= weakAttack; //monsterHp = monsterHp - weakAttack
                        Console.WriteLine($"약 공격 - 공격력 {weakAttack}으로 공격! - 몬스터 HP : {monsterHp}");
                    }
                    break;

                    case 2:
                    {
                        monsterHp -= baseAttack;
                        Console.WriteLine($"기본 공격 - 공격력 {baseAttack}으로 공격! - 몬스터 HP : {monsterHp}");
                    }
                    break;

                    case 3:
                    {
                        monsterHp -= strongAttack;
                        Console.WriteLine($"강 공격 - 공격력 {strongAttack}으로 공격! - 몬스터 HP : {monsterHp}");
                    }
                    break;

                    default:
                    {
                        Console.WriteLine($"잘못된 입력, 다시 입력하세요.");
                        break;

                    }
                }//switch

                if(monsterHp <= 0)
                {
                    Console.WriteLine("몬스터 사망!!!!!");
                    break;
                }
            }//while

            Console.WriteLine("게임 종료");
        }//Main
    }
}