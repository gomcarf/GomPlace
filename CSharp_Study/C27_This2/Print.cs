class Print
{
    private Character character;

    public Print(Character character)
    {
        this.character = character;
    }

    public string Execute()
    {
        return
        $@"
            name : {character.Name},
            hp : {character.Hp},
            attack : {character.Attack}
        ";//@는 여러줄을 한줄로 묶어줌
    }
}