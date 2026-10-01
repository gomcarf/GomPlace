using System;

class Player
{
    private int hp;
    private int attack;

    public override string ToString()
    {
        return $"Player HP: {hp}, Attack: {attack}";
    }

    public delegate void AttackDelegate(int number, int damage);
    
    public AttackDelegate OnAttack;
    public AttackDelegate OnSkill;
    public Action<int, int> OnItem;

    public Player(int hp, int attack)
    {
        this.hp = hp;
        this.attack = attack;
    }

    public void Attack(int number)
    {
        if(OnAttack != null)
            OnAttack.Invoke(number, attack);
    }

    public void Skill(int number)
    {
        //if (OnSkill != null)
            OnSkill?.Invoke(number, attack);
    }

    public void Item(int number)
    {
        if (OnItem != null)
            OnItem(number, attack);
    }
}