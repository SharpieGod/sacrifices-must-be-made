using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpStrength = 300f;

    public float maxHealth = 100f;
    public float health;

    public GameObject groundDetector;
    public LayerMask groundLayer;

    public InputAction horizontalInput;
    public InputAction jumpInput;

    Rigidbody2D rb;

    bool grounded;
    float coyoteTime = 0.15f;
    float coyoteTimer = 0f;

    bool jumpAvailable = true;

    void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();

        horizontalInput.Enable();
        jumpInput.Enable();
    }

    void Update()
    {
        grounded = Physics2D.CircleCastAll(
            groundDetector.transform.position,
            0.4f,
            Vector2.down,
            0,
            groundLayer
        ).Length > 0;

        if (grounded)
        {
            coyoteTimer = coyoteTime;
            jumpAvailable = true;
        }
        else
        {
            coyoteTimer -= Time.deltaTime;
        }

        rb.gravityScale = rb.linearVelocity.y > 0 ? 10f : 40f;

        if (jumpInput.WasPerformedThisFrame())
        {
            if (coyoteTimer > 0f && jumpAvailable)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
                rb.AddForce(Vector2.up * jumpStrength);
                jumpAvailable = false;
                coyoteTimer = 0f;
            }
        }

        float direction = horizontalInput.ReadValue<float>();
        float airFactor = grounded ? 1f : 0.8f;

        rb.AddForce(new Vector2(direction * speed * airFactor * Time.deltaTime * 1000f, 0f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Button b = collision.gameObject.GetComponent<Button>();
        if (b) b.TriggerButton();
    }
}
