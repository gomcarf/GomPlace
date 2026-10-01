class Program
{
    private static void PlayerAttack(int number, int damage)
    {
        Console.WriteLine($"Player Attack : {number}, {damage}");
    }

    private static void PlayerAttack2(int number, int damage)
    {
        Console.WriteLine($"Player Attack2 : {number}, {damage}");
    }

    private static void SkillAttack(int number, int damage)
    {
        Console.WriteLine($"Skill Attack : {number}, {damage}");
    }

    private static void ItemAttack(int number, int damage)
    {
        Console.WriteLine($"Item Attack : {number}, {damage}");
    }


    private static void Main(string[] args)
    {
        Player player = new Player(100, 10);
        player.OnAttack += PlayerAttack;
        player.OnAttack += PlayerAttack2;

        player.OnSkill += SkillAttack;

        player.OnItem += ItemAttack;
        player.OnItem += PlayerAttack;

        while (true)
        {
            Console.Write("입력 : ");
            string input = Console.ReadLine()!;

            int command;
            int.TryParse(input, out command);

            if (command == 1)
            {
                player.Attack(1);
            }
            else if (command == 2)
            {
                player.Skill(1);
            }
            else if (command == 3)
            {
                player.Item(1);
            }
            else if(command == 4)
            {
                if(player.OnSkill != null)
                    player.OnSkill -= SkillAttack;
            }
            else
                break;
        }
    }
}