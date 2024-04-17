using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction = Vector2.zero;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float dashingSpeed = 100f;
    private bool isDashing;
    private float dashingTime = 0.1f;    
    [SerializeField] private float jumpheight = 5f;
    private float jumpTime = 0.1f;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(direction.x, direction.y);
    }

    void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        Debug.Log(direction);
        this.direction = direction;
    }

    private void Move(float x, float y)
    {
        if (isDashing)
        {
            rb.velocity = new Vector2(x * dashingSpeed, y * dashingSpeed);
        }
        else
        {
            rb.velocity = new Vector2(x * speed, y * speed);
        }
    }

    IEnumerator OnDash()
    {
        isDashing = true;
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
    }

    IEnumerator OnJump()
    {
        // Debug.Log("jump");
        // Jump();
        rb.gravityScale = -250;
        yield return new WaitForSeconds(jumpTime);
        rb.gravityScale = 250;
        yield return new WaitForSeconds(jumpTime);
        rb.gravityScale = 0;
    }

    // private IEnumerator Jump()
    // {
        // Debug.Log("jumppppp");
        // float originalY = rb.velocity.y;
        // rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpheight);
        // yield return new WaitForSeconds(jumpTime);
        // rb.velocity = new Vector2(rb.velocity.x, originalY);
        
        // rb.gravityScale = -250;
        // yield return new WaitForSeconds(jumpTime);
        // rb.gravityScale = 250;
        // yield return new WaitForSeconds(jumpTime);
        // rb.gravityScale = 0;
    // }
}
