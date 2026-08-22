using UnityEngine;

public class Block : MonoBehaviour
{
    private Game game;

    private void Awake()
    {
        GameObject obj = GameObject.Find("Game");
        game = obj.GetComponent<Game>();
    }

    private void Update()
    {
        if (game.GameStart == false)
            return;

        transform.Translate(-5.0f * Time.deltaTime, 0.0f, 0.0f);
    }
}
