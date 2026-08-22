using UnityEngine;

public class Game : MonoBehaviour
{
    private bool bGameStart;
    public bool GameStart => bGameStart;

    public void StartGame()
    {
        bGameStart = true;
    }
}
