namespace C30_Overloading
{
    class Program
    {
        private static void Main(string[] args)
        {
            Player player = new Player(100);
            player.Print();
            player.Print(50);
            player.Print(Player.EAttackType.Range);
            player.Print(30, 5);
        }//Main
    }
}