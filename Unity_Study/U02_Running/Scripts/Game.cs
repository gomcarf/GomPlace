using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField, Range(5, 30), Header("Block")]
    private float blockSpeed = 15.0f;
    public float BlockSpeed => blockSpeed;

    [SerializeField, Range(1, 10)]
    private float raiseTime = 5.0f; //다음 단계로 넘어가는 제한 시간

    [SerializeField, Range(0.1f, 1.0f)]
    private float raiseRatio = 0.2f; //속도가 얼마나 증가하는지 비율

    private float raiseTimer;//UI Image의 시간을 넣을 변수
    private Image uiImage_Timer;


    [SerializeField, Header("Monster")]
    private bool bSpawnMonsters = true;
    public bool SpawnMonsters => bSpawnMonsters;

    [SerializeField, Range(0, 5)]
    private float monsterSpeed = 0.5f;
    public float MonsterSpeed
    {
        get
        {
            if (bRigidSpeed)
                return monsterSpeed + blockSpeed;
            else
                return monsterSpeed;
        }
    }

    [SerializeField]
    private float monsterMoveMargin = 0.5f;//몬스터가 블록 위에서 움직일때 블록 끝에 딱 맞는 여백 크기
    public float MonsterMoveMargin => monsterMoveMargin;

    [SerializeField]//켜면 traslate에 의한 이동, 끄면 rigidbody에 의한 이동
    private bool bRigidSpeed = true;
    public bool RigidSpeed => bRigidSpeed;

    private bool bGameStart;
    public bool GameStart => bGameStart;

    private bool bGameOver;
    public bool IsGameOver => bGameOver;

    private GameObject panel_GameOver;


    private void Awake()
    {
        //비활성 객체는 찾을 수 없음
        //panel_GameOver = GameObject.Find("Panel_GameOver");

        GameObject canvas = GameObject.Find("Canvas");
        Transform t = canvas.transform.Find("Panel_GameOver");
        panel_GameOver = t.gameObject;
        panel_GameOver.SetActive(false);

        GameObject obj = GameObject.Find("Image_Timer");
        uiImage_Timer = obj.GetComponent<Image>();
        
    }

    private void Start()
    {
        uiImage_Timer.fillAmount = 0.0f;
    }

    private void Update()
    {
        if (bGameStart == false)
            return;
        if (bGameOver)
            return;

        raiseTimer += Time.deltaTime;
        if(raiseTimer >= raiseTime)
        {
            raiseTimer = 0.0f;
            blockSpeed += blockSpeed * raiseRatio;
        }
        uiImage_Timer.fillAmount = raiseTimer / raiseTime;
    }

    public void StartGame()
    {
        bGameStart = true;
    }

    public void GameOver()
    {
        bGameOver = true;

        
        GameObject player = GameObject.Find("Player");
        Rigidbody2D rigid = player.GetComponent<Rigidbody2D>();
        //rigid.AddForce(Vector2.up * 20.0f, ForceMode2D.Impulse);

        rigid.linearVelocityY = 15.0f;

        
        BoxCollider2D collider = player.GetComponent<BoxCollider2D>();
        collider.enabled = false;

        
        Animator animator = player.GetComponent<Animator>();
        animator.SetTrigger("Death");

        Destroy(player, 1.0f);

        
        panel_GameOver.SetActive(true);
    }

    public void RestartGame()
    {
        string name = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(name);
    }
}
