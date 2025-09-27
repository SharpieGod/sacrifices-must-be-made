using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpStrength;
    public float maxHealth;
    public float health;
    Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth; 
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
