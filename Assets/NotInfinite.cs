using UnityEngine;

public class NotInfinite : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool isGrounded;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }
}
