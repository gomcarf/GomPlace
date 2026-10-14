using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField]
    private GameObject blockPrefab;

    [SerializeField]
    private Vector2 distance = new Vector2(4, 8);

    [SerializeField]
    private Vector2 size = new Vector2(10, 16);

    [SerializeField]
    private Vector2 height = new Vector2(1, 3);

    private GameObject blocks;
    private int blockCount = 0;

    private void Awake()
    {
        blocks = GameObject.Find("Blocks");
    }

#if UNITY_EDITOR
    private void Reset() //리셋할때 불려오는 함수. 리소스 등 초기값을 설정할 수 없는 값들을 리셋할때 불러놓으라는 식으로 처리 가능
    {
        //print("Reset");

        blockPrefab = Resources.Load<GameObject>("Prefabs/Block");
    }
#endif


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print($"Trigger Enter : {collision.gameObject.name}");

        if (collision.gameObject.name.Contains("Block") == false)
            return;


        GameObject obj = Instantiate<GameObject>(blockPrefab, blocks.transform);
        obj.name = $"Block_{++blockCount}";

        float x = transform.position.x; //Creator의 x좌표 //9.1

        //x += 5.0f;//블록간 x간격 
        x += Random.Range(distance.x, distance.y); 

        //x += 6.0f * 0.5f; //블록의 x크기
        float scaleX = Random.Range(size.x, size.y);
        x += scaleX * 0.5f;


        if (collision.gameObject.name != "Block_Start")
        {
            //x += collision.transform.localScale.x; //이전에 충돌한 블록의 x크기
            x += collision.GetComponent<SpriteRenderer>().size.x;
        }
            

        Vector2 position = obj.transform.localPosition; //0
        position.x = x; //14.1
        obj.transform.localPosition = position;

        //Vector2 scale = Vector2.one; //(1, 1)
        ////scale.x = 6.0f;
        //scale.x = scaleX;
        //obj.transform.localScale = scale;


        //int scaleY = 3;
        int scaleY = Random.Range((int)height.x, (int)height.y + 1);

        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
        spriteRenderer.size = new Vector2(scaleX, scaleY);

        BoxCollider2D boxCollider2D = obj.GetComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(scaleX, scaleY);
        boxCollider2D.offset = new Vector2(0.0f, scaleY * 0.5f);
    }
}
