# [U02_Running](../UnityStudy_List.md)

약간 2D Infinite Running 게임 느낌

### [CONSOLE]

- Collapse : 같은 종류의 메세지는 묶어서 보여줌
- c#꿀팁 : 영역 선택 후 컨트롤+h : 찾아 바꾸기 가능.

### [Sprite Renderer]

- sprite renderer : 게임 오브젝트의 이미지를 나타내는 컴포넌트
    - Sprite를 렌더링하고 스프라이트가 씬에 시각적으로 표시되는 방식을 제어
    - order in layer : 크기가 클수록 앞으로 나옴

### [물리엔진]

- Box2D : 기본 2D 물리 시스템(Rigidbody 2D, BoxCollider2D 등).
- 충돌 감지, 중력, 힘 적용 등 기본적인 2D 상호작용은 모두 이 엔진을 기반으로 작동

### [애니메이터]

<img src="../Images/image3.png" width = 500></img>

- 하늘에서 떨어지고 나서 점프 모션이 끝나면 뛰는게 아니고 땅에 닿자마자 뛰는 거니까 has exit time은 해제
- 전환하는데 지연시간이 있으면 안되니까 transition duration은 0

<img src="../Images/image4.png" width = 500></img>

- 전이 조건 : Run이 호출되면 애니메이션 전환

```csharp
private void OnCollisionEnter2D(Collision2D collision)//플레이어가 땅에 닿는 순간 호출(충돌)
{//함수호출 : 플레이어 | 파라미터 : 블록

//게임 시작 상태가 아닐때만 게임을 시작하고 점프 동작을 달리는 동작으로 바꿔줌
    if(game.GameStart == false)
    {
        game.StartGame();//

        animator.SetTrigger("Run");//애니메이터의 트리거를 Run으로 설정
    }
}//그러면 땅에 닿자 마자 Run 애니메이션으로 달림
```

game.StartGame() 왜하는 건지 질문 그냥 땅에 닿으면 애니메이션만 바꾸면 되는거 아닌가? 왜 스타트게임을 따로 또 하는거지? 애니메이터에 스타트 상태라서 그런건가?

### [점프 기능 추가]

```csharp
[Player]
private new Rigidbody2D rigidbody2D;
//부모클래스에 rigidbody2D가 이미 있어서 숨김처리됨. 
//new키워드를 사용해서 부모 클래스의 변수명은 무시하고 그냥 이걸로 쓸거라고 선언.

private void Awake()//앱이 시작할 때 호출(Start보다 먼저 실행)
{
    rigidbody2D = GetComponent<Rigidbody2D>(); //Player의 Rigidbody2D를 가져옴
}

private void Update()
{
    if (Input.GetKeyDown(KeyCode.Space)) //스페이스바가 입력되면
    {
        rigidbody2D.linearVelocityY = 10.0f; //y축 이동속도 10.0f로 설정
    }
}
```

- 스페이스바를 누르면 Player가 y방향으로 10.0f속도로 위로 올라갔다 내려옴
- Rigidbody2D.linearVelocityY : 2D 강체의 Y축(수직) 이동 속도를 읽거나 설정할 때 사용하는 속성

⇒대신 누를 때마다 계속 쩜푸함… 바닥에 닿았을 때만 점프하도록 수정 필요

- 땅에 닿았을 때를 저장하는 변수 : `private bool bLanded;`

```csharp
private void Update()
{
    if (Input.GetKeyDown(KeyCode.Space) == false)
        return;

    if (bLanded == false)
        return;
    //여기까지 return이 안되면 스페이스바도 눌리고 땅에도 닿아있는 상태
    bLanded = false; //점프하니까 false로 바꿔주고
    
    animator.SetBool("Jump", true);//동작도 점프 동작으로 바꿔줌

    rigidbody2D.linearVelocityY = 10.0f; //Jump
}

private void OnCollisionEnter2D(Collision2D collision)//플레이어가 땅에 닿으면 호출(충돌)
{//함수호출 : 플레이어 | 파라미터 : 블록
    
    if(game.GameStart == false)//게임 시작 상태가 아닐때만 게임을 시작하고 점프 동작을 달리는 동작으로 바꿔줌
    {
        game.StartGame();

        animator.SetTrigger("Run");
    }

    bLanded = true;
    animator.SetBool("Jump", false);//땅에 닿아있는 상태니까 애니메이터의 jump는 false

    
}
```

⇒ 이렇게 되면 플레이어는 무조건 땅에 닿았을 때 한번 점프 가능!

⇒근데 나는 2번 점프 하고 싶어

- 2단점프 기능 jumpCount변수를 생성해서 조건문 걸어줌 : `private int jumpCount;`

```csharp
private void Update()
{
    if (Input.GetKeyDown(KeyCode.Space) == false)
        return;

    if (bLanded || jumpCount < 2)//땅을 밟고 있거나 점프를 2번 미만으로 뛴 경우
    {
        bLanded = false; //점프했으니까 false로 바꿔주고
        jumpCount++;//점프 횟수 증가
        animator.SetBool("Jump", true);//동작도 점프 동작으로 바꿔줌

        rigidbody2D.linearVelocityY = 10.0f; //Jump
    }
}

private void OnCollisionEnter2D(Collision2D collision)
{
		```
    bLanded = true;
    jumpCount = 0;//땅에 닿는 순간은 무조건 카운트가 0이됨
    animator.SetBool("Jump", false);
		```
}
```

⇒ 이렇게 하면 2단 점프 가능!

⇒ 근데 나는 최대 점프 횟수를 에디터에서 좀 조절하고 싶어

```csharp
[SerializeField, Range(1,4)]
private int maxJumpCount = 2; //기본값은 2로 설정하고 에디터에서 1~4까지 설정할수 있게 SerializeField로 지정
 
private void Update()
{
    if (Input.GetKeyDown(KeyCode.Space) == false)
        return;

    if (bLanded || jumpCount < maxJumpCount)//땅을 밟거나 점프 횟수가 최대 점프 횟수보다 작을 경우
    {
        bLanded = false; 
        jumpCount++;
        animator.SetBool("Jump", true);

        rigidbody2D.linearVelocityY = 10.0f; //Jump
    }
}
```

⇒이렇게 하면 기본은 2단 점프지만 에디터에서 설정한 대로 1~ 4단점프까지 가능!

### [Collider]

- Collision > 때리면 충돌하는 거
- Collider > 칼로 갈겼을 때 관통되는 거 = Is Trigger 체크
- 충돌이 일어날 때는 부딪히는 둘중 하나는 물리엔진을 가지고 있어야 함 : rigidbody

```csharp
[unit test - Collider / Collision]
using UnityEngine;

public class UnitTest_Collider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)//딱 부딪힌 순간
    {
        print($"Collision Enter : {collision.gameObject.name}");
    }

    private void OnCollisionStay2D(Collision2D collision)//부딪혀서 붙어있을 때
    {
        print($"Collision Stay : {collision.gameObject.name}");
    }
    private void OnCollisionExit2D(Collision2D collision)//떨어졌을 때
    {
        print($"Collision Exit : {collision.gameObject.name}");
    }

    private void OnTriggerEnter2D(Collider2D collision)//딱 부딪힌 순간
    {
        print($"Trigger Enter : {collision.gameObject.name}");
    }

    private void OnTriggerStay2D(Collider2D collision)//부딪혀서 붙어있을 때
    {
        print($"Trigger Stay : {collision.gameObject.name}");
    }
    private void OnTriggerExit2D(Collider2D collision)//떨어졌을 때
    {
        print($"Trigger Exit : {collision.gameObject.name}");
    }
}

```

#### <Destroyer>

- 땅이 화면을 완전히 벗어나서 안보이면(destroyer를 빠져 나가면) 블록 삭제

```csharp
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Destroy(collision); 
        //collision은 충돌체이기 때문에 이대로 하면 box collider 컴포넌트만 사라짐
        Destroy(collision.gameObject);//이 collision을 가진 게임 오브젝트를 삭제
    }
}
```

#### <Creator>

<img src="../Images/image5.png" width = 500></img>

- 오른쪽에 충돌체를 만들어서 블록이 닿으면 복제해서 땅을 생성해줌
    
    <img src="../Images/image6.png" width = 500></img>
    
- 위치 :
    - 화면 가로 크기 :  1920 / pixes per unit 100 = 19.2 / 2이 화면의 반의 끝 = 9.6 - 0.5 = 9.1
        - 100픽셀*100픽셀은 유니티에서의 1*1
    
    <img src="../Images/image7.png" width = 500></img>
    

```csharp
[SerializeField]//private 변수를 에디터에 노출 시켜줌
private GameObject blockPrefab;//파일에서 불러온 원본 프리팹

private GameObject blocks; //복제된 블록들을 담아둘 폴더 같은 거
```

- prefab : 게임 오브젝트를 미리 만들어서 파일로 저장해둔 것

```csharp
private void OnTriggerEnter2D(Collider2D collision)
{
    //print($"Trigger Enter : {collision.gameObject.name}");

    GameObject obj = Instantiate<GameObject>(blockPrefab, blocks.transform);
    obj.name = $"Block_{blocks.transform.childCount}"; //childCount : blocks의 자식의 개수 근데 이렇게 하면 나중에 똑같은 이름으로 된 애들이 계속 나옴

    float x = transform.position.x; //transform 컴포넌트만 미리 선언을 안해도 내부적으로 getComponent된 변수가 있음 //creator 위치

    x += 5.0f;//블록 간 간격

    if(collision.gameObject.name != "Block_Start")//부딪힌 블록이 Block Start가 아닐때만
        x += collision.transform.localScale.x; //이전에 충돌한 블록의 x 크기만큼 x에 더함

		//게임 오브젝트의 로컬 x 좌표값만 변경
    Vector2 position = obj.transform.localPosition; //복제된 블록의 부모 기준 위치를 position에 저장
    position.x = x;//position의 x좌표만 새로 설정한 x값으로 저장
    obj.transform.localPosition = position;//수정된 position값을 복사된 블록의 로컬 위치에 할당하여 실제로 위치 변경
}
```

- 블록이 Creator를 관통해야 하기 때문에 IsTrigger 체크 : OnTriggerEnter2D / Collider2D 사용
- Instantiate<GameObject> : 프리팹이나 게임 오브젝트를 복사해 새로운 오브젝트를 화면에 만드는 기능
- 복사한 블록은 blocks의 child가 될거고 이름은 childCount를 써서 구분해줌
- 복사한 블록이 크리에이터와 맞닿아 있으면 무한 복사가 되기 때문에 간격을 설정함
    - transform 컴포넌트만 getComponent로 가져오지 않아도 내부적으로 getComponent된 변수가 있음 > Creator의 x좌표를 가져와서 x에 저장
    - creator 위치에서 5.0f만큼 간격을 줌

if(collision.gameObject.name != "Block_Start")
        x += collision.transform.localScale.x; //이전에 충돌한 블록의 x 크기
이건 왜하는건지 없어도 똑같은데

- 복사한 블록의 로컬 x 좌표값만 새로 설정한 float x의 x 값으로 변경