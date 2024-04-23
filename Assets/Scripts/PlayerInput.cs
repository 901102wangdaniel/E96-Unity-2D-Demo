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
    private float dashingTime = 0.075f;    

    
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
}
