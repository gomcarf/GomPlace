using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField]//private 변수를 에디터에 노출 시켜줌
    private GameObject blockPrefab;//파일에서 불러온 원본 프리팹
    
    private GameObject blocks;

    private void Awake()
    {
        blocks = GameObject.Find("Blocks");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print($"Trigger Enter : {collision.gameObject.name}");

        GameObject obj = Instantiate<GameObject>(blockPrefab, blocks.transform);
        obj.name = $"Block_{blocks.transform.childCount}"; //childCount : blocks의 자식의 개수 근데 이렇게 하면 나중에 똑같은 이름으로 된 애들이 계속 나옴

        float x = transform.position.x; //transform 컴포넌트만 미리 선언을 안해도 내부적으로 getComponent된 변수가 있음 //creator 위치

        x += 5.0f;//블록 간 간격

        if(collision.gameObject.name != "Block_Start")
            x += collision.transform.localScale.x; //이전에 충돌한 블록의 x 크기

        Vector2 position = obj.transform.localPosition;
        position.x = x;
        obj.transform.localPosition = position;
    }
}
