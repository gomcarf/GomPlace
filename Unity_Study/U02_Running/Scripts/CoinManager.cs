using System.Collections;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    private float createTime = 4.0f;

    [SerializeField]
    private float createDeviation = 1.0f;

    [SerializeField]
    private Vector2 height = new Vector2(1, 3);

    private GameObject coinsPrefab;
    private Game game;

    private Transform creator;

    private void Awake()
    {
        coinsPrefab = Resources.Load<GameObject>("Prefabs/Coins");

        GameObject obj = GameObject.Find("Game");
        game = obj.GetComponent<Game>();

        creator = GameObject.Find("Creator")?.transform;
    }

    private void Start()
    {
        StartCoroutine(Co_CreateCoinBlock());
    }

    private IEnumerator Co_CreateCoinBlock()
    {
        while(true)
        {
            if(game.GameStart == false)
            {
                yield return null;
                continue;
            }

            if (game.IsGameOver)
                break;

            float time = createTime + Random.Range(-createDeviation, createDeviation);
            yield return new WaitForSeconds(time);

            GameObject obj = Instantiate<GameObject>(coinsPrefab, transform);

            Vector2 position = creator.transform.position;
            position.x += obj.transform.localScale.x;
            position.y = Random.Range((int)height.x, (int)height.y+1);
            obj.transform.localPosition = position;

        }
    }
}
