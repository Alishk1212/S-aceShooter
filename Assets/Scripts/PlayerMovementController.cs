using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float smoothTime; 

    private Rigidbody2D rb;
    private Vector2 targetPosition;
    private Vector2 velocity = Vector2.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = rb.position;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

            targetPosition = new Vector2(mousePosition.x, mousePosition.y);
        }
    }

    private void FixedUpdate()
    {
        //ref velocity means store velocity in each frame
        Vector2 newPosition = Vector2.SmoothDamp(rb.position, targetPosition, ref velocity, smoothTime);
        rb.MovePosition(newPosition);
    }
}
