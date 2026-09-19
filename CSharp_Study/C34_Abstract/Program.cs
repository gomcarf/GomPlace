class Program
{
    private static void Main(string[] args)
    {
        Random random = new Random();
        //알파벳
        //char rand = (char)random.Next(0x41, 0x7A + 1);
        //char rand2 = (char)random.Next(0x41, 0x7A + 1);
        //char rand3 = (char)random.Next(0x41, 0x7A  + 1);

        //string str = $"{rand}{rand2}{rand3}";
        //Console.WriteLine(str);

        //한글
        //char rand = (char)random.Next(0xAC00, 0xD7A3 + 1);
        //char rand2 = (char)random.Next(0xAC00, 0xD7A3 + 1);
        //char rand3 = (char)random.Next(0xAC00, 0xD7A3 + 1);

        //string str = $"{rand}{rand2}{rand3}";
        //Console.WriteLine(str);

        //Player player = new Player("Player", 100, 20, 10);
        //가상은 부모 함수의 몸체 존재, 필요시 재정의
        //추상은 부모 함수의 몸체 없음. 무조건 재정의
        //추상클래스는 추상 메서드의 몸체가 없어 메모리 할당 불가

        //Warrior warrior = new Warrior("Player", 100, 20, 10);
        //Mage mage = new Mage("Player2", 100, 20, 10);

        //Player warrior = new Warrior("Player", 100, 20, 10);
        //Player mage = new Mage("Player2", 100, 20, 10);

        Player player;

        Console.WriteLine("직업 선택(1:전사, 2:마법사) : ");
        string input = Console.ReadLine()!;
        int job;
        int.TryParse(input, out job);

        switch (job)
        {
            case 2: player = new Mage("Player", 100, 20, 10); break;

            case 1: //1번케이스에 break가 없으니 1번 케이스랑 디폴트랑 동일하게 실행됨
            default: player = new Warrior("Player", 100, 20, 10); break;
        }

        
        int count = random.Next(5, 10);

        Monster[] monsters = new Monster[count];
        for(int i = 0; i < monsters.Length; i++)
        {
            char rand = (char)random.Next(0xAC00, 0xD7A3 + 1);
            char rand2 = (char)random.Next(0xAC00, 0xD7A3 + 1);
            char rand3 = (char)random.Next(0xAC00, 0xD7A3 + 1);

            string str = $"{rand}{rand2}{rand3}";

            monsters[i] = new Monster(str, random.Next(30, 60 + 1));

            Console.WriteLine($"{i}번 몬스터, {monsters[i].Name}, HP: {monsters[i].HP}");
        }

        while (true)
        {
            Console.WriteLine("공격할 몬스터 번호 :");
            input = Console.ReadLine()!;

            int monster;
            int.TryParse(input, out monster);

            if (monster < 0 || monster >= monsters.Length)
                continue;

            player.Attack(monsters[monster]);
        }
    }//Main
}