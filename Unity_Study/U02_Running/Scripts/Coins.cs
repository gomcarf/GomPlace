using System.Collections;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField]
    private float rotateDelay = 2.0f;

    [SerializeField]
    private float rotateDeviation = 0.5f;

    [SerializeField]
    private Vector2 rowSize = new Vector2(1, 3);

    [SerializeField]
    private Vector2 colSize = new Vector2(5, 10);


    private GameObject coinPrefab;
    private GameObject[,] coins;

    private BoxCollider2D boxCollider;

    private int rows = 3;
    private int cols = 5;

    private Game game;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        game = GameObject.Find("Game") ? .GetComponent<Game>();

        coinPrefab = Resources.Load<GameObject>("Prefabs/Coin");
    }

    private void Start()
    {
        rows = Random.Range((int)rowSize.x, (int)rowSize.y + 1);
        cols = Random.Range((int)colSize.x, (int)colSize.y + 1);

        coins = new GameObject[rows, cols];
        for(int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                GameObject obj = Instantiate(coinPrefab, transform);

                int index = y * cols + x;
                obj.name = $"Coin_{index}";

                Vector2 position;
                position.x = x;
                position.y = y;

                obj.transform.localPosition = position;
                coins[y, x] = obj;
            }
        }


        boxCollider.size = new Vector2(cols, rows);

        Vector2 offset;
        offset.x = (cols - 1) * 0.5f;
        offset.y = (rows - 1) * 0.5f;
        boxCollider.offset = offset;


        StartCoroutine(Co_Rotate(rotateDelay, rotateDeviation));
    }

    private void Update()
    {
        if (game.GameStart == false)//코인스에 게임이 시작되어야만 코인이 복제되기때문에 생략해도 되지만 그래도 적어줌
            return;
        if (game.IsGameOver)
            return;

        transform.Translate(-game.BlockSpeed * Time.deltaTime, 0.0f, 0.0f);

    }

    private IEnumerator Co_Rotate(float delay, float deviation)
    {
        while (true)
        {
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    if (coins[y, x] == null)
                        continue;

                    Coin coin = coins[y, x].GetComponent<Coin>();
                    coin.Rotate();
                }
            }

            yield return new WaitForSeconds(delay + Random.Range(-deviation, +deviation));
        }
    }
}