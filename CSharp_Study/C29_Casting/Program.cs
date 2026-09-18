namespace C29_Casting
{ 
    class Program
    {
        private static void Main(string[] args)
        {
            Player player = new Player("Player", 100, 20);
            Character character = (Character)player; //업캐스팅
            Player player2 = (Player)character;//다운캐스팅

            //Monster monster = (Monster)player2;
            //Monster monster = (Monster)character; //System.InvalidCastException: Unable to cast object of type 'Player' to type 'Monster'.

            //////////////////////////////////////////////////////////

            Console.WriteLine($"player->Character : {player is Character}"); //is : player를 character로 변환할 수 있으면 true.
            Console.WriteLine($"Character->Player: {character is Player}");

            Monster monster = new Monster("Monster",100, 10);
            Console.WriteLine($"Monster->Character : {monster is Character}");
            Console.WriteLine($"Character->Monster: {character is Monster}");
        }//Main
    }
}