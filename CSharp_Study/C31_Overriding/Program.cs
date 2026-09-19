namespace C31_Overriding
{
    class Character
    {
        public virtual void Attack()
        {
            Console.WriteLine("기본 공격");
        }
    }

    class Monster : Character
    {
        public new void Attack() //부모의 어택을 숨기는 어택
        {
            Console.WriteLine("몬스터 공격");
        }
    }

    class Player : Character
    {
        public override void Attack() //부모의 어택을 재정의하는 어택
        {
            //base.Attack();

            Console.WriteLine("플레이어 공격");
        }
    }

    class Program
    {
        private static void Main(string[] args)
        {
            Character character = new Character();
            character.Attack();

            Monster monster = new Monster();
            monster.Attack();

            Player player = new Player();
            player.Attack();


            Console.WriteLine();
            Console.WriteLine();


            Character p1 = (Character)player; //업캐스팅
            Character m1 = (Character)monster;

            p1.Attack();
            m1.Attack();
        }//Main
    }
}