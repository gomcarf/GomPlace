using System.Numerics;

namespace C20_Structure
{
    class Program
    {
        private struct Character
        {
            public string Name;
            public float Hp;
            public float Attack;

            public void Print()
            {
                Console.WriteLine($"이름 : {Name}");
                Console.WriteLine($"체력 : {Hp}");
                Console.WriteLine($"공격력 : {Attack}");
            }
        }

        private static void Main(string[] args)
        {
            Character player;
            player.Name = "Novis";
            player.Hp = 100;
            player.Attack = 10;
            player.Print();

            //Console.WriteLine($"이름 : {player.Name}");
            //Console.WriteLine($"체력 : {player.Hp}");
            //Console.WriteLine($"공격력 : {player.Attack}");


            Character monster;
            monster.Name = "Oak";
            monster.Hp = 30;
            monster.Attack = 5;
            monster.Print();

            //Console.WriteLine($"이름 : {monster.Name}");
            //Console.WriteLine($"체력 : {monster.Hp}");
            //Console.WriteLine($"공격력 : {monster.Attack}");
        }//Main
    }
}