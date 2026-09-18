namespace C26_This
{
    class Program
    {            
        private static void Main(string[] args)
        {
            Character player = new Character();
            player.Name = "Player";
            player.Hp = 100;
            //player.Attack = 30;

            //player.Name = "Player2";
            //player.Hp = 80;

            Character monster = new Character(80);
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