using System.Collections;
using UnityEngine;

#if UNITY_EDITOR
    using UnityEditor;
#endif
//#if #endif : c에 있는 매크로 문법 | 게임 모드 일때는 컴파일 x, 에디터 일때만 컴파일

public class Coin : MonoBehaviour
{
    [SerializeField, Range(1, 10)]
    private float toTrace = 5.0f;

    [SerializeField, Range(0.5f, 3)]
    private float toEat = 1.0f;

    private Animator animator;

    private Transform playerTransform;

    private GameObject particlePrefab;

    private Score score;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        GameObject obj = GameObject.FindWithTag("Player");
        if (obj == null)
            return;
        playerTransform = obj.transform;

        particlePrefab = Resources.Load<GameObject>("Effects/Impact");

        obj = GameObject.Find("Text_Score");
        score = obj.GetComponent<Score>();

    }

    private void Start()
    {
        //InvokeRepeating("Rotate", 0.0f, 2.0f);
    }

    private void Update()
    {
        if (playerTransform == null)
            return;

        float distance = Vector2.Distance(transform.position, playerTransform.position);//플레이어와의 거리 판단은 월드 포지션으로 판단해야함
        if (distance > toTrace)
            return;

        Debug.DrawLine(transform.position, playerTransform.position, Color.red);

        transform.SetParent(null);//플레이어에게 당겨지려면 코인 블록에서 코인으로 독립(월드포지션 유지)
        transform.position = Vector2.Lerp(transform.position, playerTransform.position, Time.deltaTime * 5.0f);

        if (distance > toEat)
            return;

        score.AddScore();
        Instantiate<GameObject>(particlePrefab, playerTransform);//임팩트 효과가 플레이어가 움직이면서 나타나도록 붙여줌

        Destroy(gameObject);
    }

    public void Rotate()
    {
        animator.SetTrigger("Rotate");
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        //print(Selection.activeTransform.name);

        Gizmos.color = Color.green;
        foreach (GameObject obj in Selection.gameObjects)
            Gizmos.DrawWireSphere(obj.transform.position, toTrace);


    }
#endif
}
