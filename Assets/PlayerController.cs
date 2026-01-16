using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    float movementX;
    float movementY;
    [SerializeField] float speed = 5.0f;
    Rigidbody2D rb;
   bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
     //   float XmovementDistance = movementX * speed * Time.fixedDeltaTime;
      //  float YmovementDistance = movementY * speed * Time.fixedDeltaTime;
      //  transform.position = new Vector2(transform.position.x + XmovementDistance, transform.position.y + YmovementDistance);
        rb.linearVelocity = new Vector2(movementX * speed, rb.linearVelocity.y);
        if (isGrounded && movementY > 0) 
        {
            rb.AddForce(new Vector2 (0,100));
        }
    }

    void OnMove(InputValue value) {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
        Debug.Log("X: " + movementX);
        Debug.Log("Y: " + movementY);
    }
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
