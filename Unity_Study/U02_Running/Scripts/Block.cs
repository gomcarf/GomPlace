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

        transform.Translate(-game.BlockSpeed * Time.deltaTime, 0.0f, 0.0f);
    }
}
