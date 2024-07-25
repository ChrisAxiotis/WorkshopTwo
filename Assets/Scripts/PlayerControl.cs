using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    public bool isGrounded;

    SpriteRenderer rbSprite;

    public int health = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            health--;
            EventManager.TriggerEvent("onHealthChange", new Dictionary<string, object> { { "amount", health } });
        }

        // Horizontal movement
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput > 0 && rbSprite.flipX)
        {
            rbSprite.flipX = false;
        }

        if (moveInput < 0 && !rbSprite.flipX)
        {
            rbSprite.flipX = true;
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(0f, -0.5f), 0.1f, LayerMask.GetMask("Ground"));

        // Jumping
        if (isGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        float speed = moveInput;

        if (speed == -1)
        {
            speed = 1;
        }
    }

    public void Death()
    {
        //GameManager.instance.EndLevel();
    }


}
