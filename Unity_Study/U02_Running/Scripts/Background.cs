using UnityEngine;

public class Background : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float spriteSize;

    private Vector3 start;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteSize = spriteRenderer.localBounds.size.x;
        start = transform.position;
    }

    private void Update()
    {
        float x = Mathf.Repeat(Time.time * 3.0f, spriteSize);
        transform.position = start + Vector3.left * x;
    }
}
