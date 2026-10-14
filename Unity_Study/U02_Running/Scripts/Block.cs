using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private GameObject monsterPrefab;

    [SerializeField]
    private int maxMonsterCount = 2;

    private Game game;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        GameObject obj = GameObject.Find("Game");
        game = obj.GetComponent<Game>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (game.SpawnMonsters == false)
            return;

        if (monsterPrefab == null)
            return;

        int count = Random.Range(0, maxMonsterCount + 1);

        for(int i = 0; i < count; i++)
        {
            GameObject monster = Instantiate<GameObject>(monsterPrefab, transform);

            Vector3 position = monster.transform.localPosition;
            position.y = spriteRenderer.size.y;
            
            float x = spriteRenderer.size.x * 0.5f;
            x = Random.Range(-x + 1.0f, x - 1.0f);
            position.x = x;

            monster.transform.localPosition = position;
        }

        //print(spriteRenderer.size);
    }

    private void Update()
    {
        if (game.GameStart == false)
            return;

        if (game.IsGameOver)
            return;

        transform.Translate(-game.BlockSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print(collision.gameObject.name);
        if (collision.gameObject.name != "Player")
            return;        

        ContactPoint2D contact = collision.GetContact(0);
        if(Mathf.Abs(contact.normal.x) >= 0.9f)
        {
            game.GameOver();
        }
    }
}
