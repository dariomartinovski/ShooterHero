using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Components
    public GameObject Player;
    
    // Enemy attributes
    private float MoveSpeed = 3f;
  //  private bool IsHit = false;
    private Rigidbody2D rb;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       // if (!IsHit)
       // {
        rb.velocity = (Player.transform.position - transform.position).normalized * MoveSpeed;
      //  }
     //   else
     //   {
     //       rb.velocity = new Vector2(0, 0);
    //    }
        // Calculate the direction from the enemy to the hero
       /* Vector2 direction = Player.transform.position - transform.position;

        // Normalize the direction vector to get a unit vector
        direction = direction.normalized;

        // Set the velocity based on the direction and move speed
        rb.velocity = direction * MoveSpeed;*/
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //IsHit = true;
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
}
