using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    //이벤트 - 특정한 상황이 발생하면 유니티가 자동으로 호출해주는 함수
    [SerializeField, Range(1,4)]
    private int maxJumpCount = 2;

    private Animator animator;
    private new Rigidbody2D rigidbody2D;
    //부모클래스에 rigidbody2D가 이미 있어서 숨김처리됨. new키워드를 사용해서 부모 클래스의 변수명은 무시하고 그냥 이걸로 쓸거라고 선언.

    private Game game;

    private bool bLanded; //땅에 닿았는지 체크해줄 변수
    private int jumpCount; //점프를 몇번했는지 카운트 변수

    private void Awake()//앱이 시작할 때 호출
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        GameObject obj = GameObject.Find("Game");
        game = obj.GetComponent<Game>();
    }

    private void Start() //게임이 시작할 때 호출 (프로그램이 먼저 실행 > 게임 실행)
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == false)
            return;

        //if (bLanded == false)
        //    return;
        ////여기까지 return이 안되면 스페이스바도 눌리고 땅에도 닿아있는 상태
        //bLanded = false; //점프하니까 false로 바꿔주고
        
        //animator.SetBool("Jump", true);//동작도 점프 동작으로 바꿔줌

        //rigidbody2D.linearVelocityY = 10.0f; //Jump

        if (bLanded || jumpCount < maxJumpCount)//땅을 밟고 있거나 점프를 2번 미만으로 뛴 경우에는 점프 가능
        {
            bLanded = false; //점프하니까 false로 바꿔주고
            jumpCount++;//횟수 증가
            animator.SetBool("Jump", true);//동작도 점프 동작으로 바꿔줌

            rigidbody2D.linearVelocityY = 10.0f; //Jump
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)//플레이어가 땅에 닿는 순간 호출(충돌)
    {//함수호출 : 플레이어 | 파라미터 : 블록
        //print(gameObject.name);//Player
        //print(collision.gameObject.name);//Block

        if(game.GameStart == false)//게임 시작 상태가 아닐때만 게임을 시작하고 점프 동작을 달리는 동작으로 바꿔줌
        {
            game.StartGame();

            animator.SetTrigger("Run");
        }

        bLanded = true;
        jumpCount = 0;//땅에 닿는 순간은 무조건 카운트가 0이됨
        animator.SetBool("Jump", false);//땅에 닿아있는 상태니까 애니메이터의 jump는 false

        
    }

    private void OnTriggerEnter2D(Collider2D collision)//관통
    {

    }
}
