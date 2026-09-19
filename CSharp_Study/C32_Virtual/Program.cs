namespace C32_Virtual
{    
    class Program
    {
        private static void Main(string[] args)
        {
            Character[] characters = new Character[5];
            characters[0] = new Player("Player1", 100); //플레이어의 어택 함수 호출됨
            characters[1] = new Monster("Oak", 50); //캐릭터의 어택 함수 호출됨
            characters[2] = new Player("Player2", 150);
            characters[3] = new Monster("Dwarf", 80);
            characters[4] = new Player("Player3", 120);

            for(int i = 0; i < characters.Length; i++)
                characters[i].Attack();
            
        }//Main
    }
}