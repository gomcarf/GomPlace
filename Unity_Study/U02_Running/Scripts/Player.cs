using UnityEngine;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Player : MonoBehaviour
{
    [SerializeField, Range(1, 20)]
    private float jumpPower = 10.0f; //점프 속도

    [SerializeField, Range(1, 4)]
    private int maxJumpCount = 2;

    [SerializeField, Range(0.1f, 2.0f)]
    private float maxBufferTime = 0.2f;
    private float bufferTimer;

    [SerializeField, Range(0.1f, 2.0f)]
    private float maxCoyoteTime = 0.1f;
    private float coyoteTimer;

    private Animator animator;
    private new Rigidbody2D rigidbody2D;

    private TextMeshProUGUI tmp;

    private Game game;

    private bool bLanded;
    private int jumpCount;

    private float startX;

    private void Awake() //앱이 시작할 때
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        GameObject obj = GameObject.Find("Game");
        game = obj.GetComponent<Game>();

        tmp = GetComponentInChildren<TextMeshProUGUI>(true);
    }

    private void Start() //게임이 시작할 때
    {
        startX = transform.position.x;
    }

    private void Update()
    {
        string text = "";
        text += $"Buffer : " + bufferTimer.ToString("F2") + "\n";
        text += $"Coyote : " + coyoteTimer.ToString("F2");
        tmp.text = text;

        Update_JumpStart();

        if (transform.position.y < -Camera.main.orthographicSize)
        { 
            game.GameOver();

            return;
        }

        Vector2 position = transform.position;
        position.x = startX;
        transform.position = position;//플레이어가 뒤로 밀리지 않게 고정
    }

    private void Update_JumpStart()
    {
        if (game.IsGameOver)
            return;

        if (game.GameStart == false)
            return;

        if (bLanded == false) //땅이 아니라면 = 공중 || 그냥 가다가 땅에서 떨어질 때
        {
            if (coyoteTimer <=0 && jumpCount == 0)
                jumpCount = maxJumpCount;

            coyoteTimer -= Time.deltaTime;
        }
        else
            coyoteTimer = maxCoyoteTime;


        //점프 버퍼링: 버퍼 타임 내에 미리 눌러놓으면 기억해뒀다 조건을 만족하면 점프하는 거. 버퍼 시간이 소진되기 전에 점프 조건이 되면 점프
        //스페이스를 누르면 버퍼타임 설정. 누르지 않으면 버퍼타임이 계속 소진됨. 그안에 점프 가능한 상황이면 점프, 다 소진되면 무시
        if (Input.GetKeyDown(KeyCode.Space))
            bufferTimer = maxBufferTime;
        else
        {
            bufferTimer -= Time.deltaTime;

            if (bufferTimer < 0)
                bufferTimer = 0;
        }
            

        if (jumpCount < maxJumpCount && (bufferTimer > 0))
        {
            if(coyoteTimer > 0.0f || jumpCount > 0)
                StartJump();
        }
    }

    private void StartJump()
    {
        bufferTimer = 0;
        coyoteTimer = 0;

        bLanded = false;
        jumpCount++;

        animator.SetBool("Jump", true);
        rigidbody2D.linearVelocityY = jumpPower; //Jump
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print(gameObject.name); //Player
        //print(collision.gameObject.name); //Block

        if(game.GameStart == false)
        {
            game.StartGame();

            animator.SetTrigger("Run");
        }

        bLanded = true;
        jumpCount = 0;

        animator.SetBool("Jump", false);
    }

    private void OnCollisionExit2D(Collision2D collision) //땅에서 떨어지는 순간 = 충돌체가 exit하는 순간
    {
        bLanded = false;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Vector2 position = transform.position;
        position.y += 1.6f;//플레이어 머리 위에 올려 주려고 y축 조정
        position.x -= 0.5f;

        GUIStyle style = GUIStyle.none;
        style.normal.textColor = Color.black;
        style.fontSize = 10;
        style.fontStyle = FontStyle.Bold;
        style.alignment = TextAnchor.MiddleCenter;

        //Handles.Label(position, $"Buffer : {bufferTimer.ToString("F2")}", style);
    }
#endif
}
