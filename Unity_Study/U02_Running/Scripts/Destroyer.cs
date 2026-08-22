using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Destroy(collision); //collision은 충돌체이기 때문에 이대로 하면 box collider만 사라짐
        Destroy(collision.gameObject);//이 collision을 가진 게임 오브젝트를 삭제
    }
}
