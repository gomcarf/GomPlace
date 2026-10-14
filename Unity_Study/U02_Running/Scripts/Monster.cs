using UnityEngine;

public class Monster : MonoBehaviour
{
    private Game game;
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private BoxCollider2D boxCollider2D;

    private float blockBound; //이동 범위
    private float direction; //이동 방향

    private void Start()
    {
        if (game.RigidSpeed)
            return;

        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;//translate에 의해 움직일 때는 얘를 켜줌

        SpriteRenderer parent = transform.parent.GetComponent<SpriteRenderer>();
        blockBound = (parent.size.x * 0.5f) - game.MonsterMoveMargin;

        direction = Random.Range(0.0f, 1.0f) >= 0.5f ? 1.0f : -1.0f;
    }

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        GameObject obj = GameObject.Find("Game");
        game = obj.GetComponent<Game>();

        //if (game.RigidSpeed)
        //{
        //    rigidbody2D.linearVelocityX = -game.MonsterSpeed;
            
        //    return;
        //}
    }

    private void Update()
    {
        if(game.GameStart == false)
            return;

        if (game.IsGameOver)
            return;

        if (game.RigidSpeed)
        { 
            rigidbody2D.linearVelocityX = -game.MonsterSpeed;

            return;
        }

        Vector2 position = transform.localPosition;

        if(position.x >= blockBound)
        {
            direction = -1.0f;
            position.x = blockBound;
            //transform.localPosition = position;
        }
        else if(position.x <= -blockBound)
        {
            direction = 1.0f;
            position.x = -blockBound;
            //transform.localPosition = position;
        }

        transform.Translate(direction * game.MonsterSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);

        if (collision.gameObject.name.Contains("Block"))
        {
            if (Mathf.Abs(contact.normal.x) >= 0.9f)
            {
                boxCollider2D.enabled = false;
                Destroy(gameObject);

                return;
            }
        }

        if (collision.gameObject.name == "Player")
        {
            if (Mathf.Abs(contact.normal.x) >= 0.9f)
                game.GameOver();

            if (contact.normal.y <= -0.9f)
            {
                boxCollider2D.enabled = false;

                animator.SetTrigger("Death");
                Invoke("End_Death", 0.5f);
            }
        }
            
    }

    private void End_Death()
    {        
        Destroy(gameObject);
    }
}
