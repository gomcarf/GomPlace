namespace C28_Inheritance
{    
    class Program
    {
        private static void Main(string[] args)
        {
            //Character character = new Character();
            Player player = new Player("P", 100, 20);
            Console.WriteLine(player.Name); //Character
            Console.WriteLine(player.HP); //Character
            Console.WriteLine(player.Attack); //Player

            Console.WriteLine();

            Monster monster = new Monster("M", 100, 10);
            Console.WriteLine(monster.Name); //Character
            Console.WriteLine(monster.HP); //Character
            Console.WriteLine(monster.MP);//monster
        }//Main
    }
}