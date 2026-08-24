using UnityEngine;

public class Game : MonoBehaviour
{
    private bool bGameStart;
    public bool GameStart => bGameStart;

    [SerializeField, Range(5,30)]
    private float blockSpeed = 15.0f;
    public float BlockSpeed => blockSpeed;//외부에서 가져다 쓸수있게 프로퍼티 하나 만들어줌

    public void StartGame()
    {
        bGameStart = true;
    }
}
