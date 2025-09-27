using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpStrength;
    public float maxHealth;
    public float health;
    public bool grounded;
    public GameObject groundDetector;
    public LayerMask groundLayer;
    public InputAction horizontalInput;
    public InputAction jumpInput;
    Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth; 
        rb = GetComponent<Rigidbody2D>();
        horizontalInput.Enable();
        jumpInput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.CircleCastAll(groundDetector.transform.position, 0.4f, Vector2.right, 0, groundLayer).Length > 0;
        var gravityFactor = rb.linearVelocityY > 0 ? 10 : 40;
        rb.gravityScale = gravityFactor;
        if (grounded && jumpInput.WasPerformedThisFrame())
        {
            rb.AddForce(new Vector2(0, jumpStrength));
        }

        var direction = horizontalInput.ReadValue<float>();
        float airFactor = grounded ? 1 : 0.8f;

        rb.AddForce(new Vector2(direction * Time.deltaTime * speed * airFactor * 1000, 0));

        Debug.Log(rb.totalForce.x + " " + direction);
        
    }

    private void Test(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<float>());
    }
}
