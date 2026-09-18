namespace C27_This2
{
    class Program
    {
        private static void Main(string[] args)
        {
            Character player = new Character("Player", 100, 20);
            Character oak = new Character("Oak", 60, 10);
            Character dwarf = new Character("Dwarf", 50, 30);
            Character poring = new Character("Poring", 10, 10);

            player.PrintString();
            oak.PrintString();
            dwarf.PrintString();
            poring.PrintString();


            Character[] arr = new Character[3];
            arr[0] = new Character("Elf", 30, 40);
            arr[1] = new Character("Slime", 10, 5);
            arr[2] = new Character("Goblin", 12, 12);

            for(int i = 0; i < 3; i++)
                arr[i].PrintString();
            
            foreach(Character character in arr)
                character.PrintString();

        }//Main
    }
}