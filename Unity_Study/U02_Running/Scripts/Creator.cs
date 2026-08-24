using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField]//private 변수를 에디터에 노출 시켜줌
    private GameObject blockPrefab;//파일에서 불러온 원본 프리팹

    [SerializeField]
    private Vector2 distance = new Vector2(4, 8);//x, y좌표를 가진 자료형인데 최소, 최대값으로도 많이 씀
    //3~8사이에 랜덤한 값으로 간격을 줄거임

    [SerializeField]
    private Vector2 size = new Vector2(10, 16);

    private GameObject blocks;

    private int blockCount = 0;

    private void Awake()
    {
        blocks = GameObject.Find("Blocks");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print($"Trigger Enter : {collision.gameObject.name}");

        GameObject obj = Instantiate<GameObject>(blockPrefab, blocks.transform);
        obj.name = $"Block_{++blockCount}"; //childCount : blocks의 자식의 개수 근데 이렇게 하면 나중에 똑같은 이름으로 된 애들이 계속 나옴

        float x = transform.position.x; //transform 컴포넌트만 미리 선언을 안해도 내부적으로 getComponent된 변수가 있음 //creator 위치 //9.1
        
        //x += 5.0f;
        x += Random.Range(distance.x, distance.y);//블록 간 간격(c#에선느 랜덤 객체를 생성해서 난수를 발생했지만 유니티는 스태틱 함수로 부여 가능)//3~8

        //x += 6.0f(블록크기) * 0.5f;//블록 x 크기의 반만큼 위치를 조정 (블록의 간격을 보장하기 위함)
        float scaleX = Random.Range(size.x, size.y);
        x += scaleX * 0.5f;

        if(collision.gameObject.name != "Block_Start")//최초 블록이 아니라면
            x += collision.transform.localScale.x; //이전에 충돌한 블록의 크기만큼 x 크기에 더함
        //최초블록은 너무 커서 반만큼 더해주면 엄청 멀리서 나타남

        Vector2 position = obj.transform.localPosition;//0
        position.x = x;//14.1
        obj.transform.localPosition = position;

        Vector2 scale = Vector2.one;//(1,1)
        scale.x = scaleX;
        obj.transform.localScale = scale;
    }
}
