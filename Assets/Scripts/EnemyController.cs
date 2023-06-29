using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Components
    public GameObject Player;
    
    // Enemy attributes
    private Rigidbody2D rb;
    private float MoveSpeed = 3f;
    private bool GameActive = true;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameActive)
        {
            rb.velocity = (Player.transform.position - transform.position).normalized * MoveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle collision with the player
            // Reduce hero's health or trigger an attack
            // You can access the hero's script or health component and call appropriate functions
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(1); // Example: Reduce hero's lives by 1
                Destroy(gameObject);
            }
        }
    }


    public void StopMovement() {
        GameActive = false;
    }
}
