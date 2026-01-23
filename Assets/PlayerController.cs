using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    float movementX;
    float movementY;
    [SerializeField] float speed = 5.0f;
    Rigidbody2D rb;
    bool isGrounded;
    int score = 0;

    int numJumpsAllowed = 2;

    Animator animator;
    SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
      
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
        if (!Mathf.Approximately(movementX, 0f))
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = movementX < 0;
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        animator.SetBool("isJumping", !isGrounded);
        //This code does the opposite of each other. If isGrounded is false then 
        // isJumping is true and vice versa
        if (numJumpsAllowed > 0 && movementY > 0) 
        {
            Debug.Log(numJumpsAllowed);
            numJumpsAllowed--;
            rb.AddForce(new Vector2 (0,200));
        }
    }

    void OnMove(InputValue value) {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
        Debug.Log("Moving");
    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            numJumpsAllowed = 2;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            score++; 
            collision.gameObject.SetActive(false);
            Debug.Log("Score: " + score);
        }
    }


    void OnDash() 
    {   
        if (movementX > 0) 
        {
            Debug.Log("Dashign Right");
            rb.AddForce(new Vector2(10000,0));
        }
        else if (movementX < 0)
        {
            rb.AddForce(new Vector2(-10000,0));
        }
    }

}
