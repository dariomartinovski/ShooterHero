using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Components
    public GameObject Player;
    public LogicScript Logic;
    
    // Enemy attributes
    private Rigidbody2D rb;
    private float MoveSpeed = 3f;

    // Animations
    private Animator animator;
    private string CurrentAnimState;
    private const string ENEMY_MOVE_LEFT = "Enemy_Move_Left";
    private const string ENEMY_MOVE_RIGHT = "Enemy_Move_Right";

    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicScript>();
        Player = GameObject.FindWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Logic.IsGameActive() && !Logic.PausedGame())
        {
            rb.velocity = (Player.transform.position - transform.position).normalized * MoveSpeed;
            // Calculate the direction from the enemy to the hero
            Vector2 direction = Player.transform.position - transform.position;

            // Normalize the direction vector to get a unit vector
            direction = direction.normalized;

            // Determine the animation state based on the direction
            if (direction.x < 0)
            {
                ChangeAnimationState(ENEMY_MOVE_LEFT);
            }
            else// if (direction.x < 0)
            {
                ChangeAnimationState(ENEMY_MOVE_RIGHT);
            }
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

    public void ChangeAnimationState(string newState)
    {
        // stop animation from repeating itself
        if (CurrentAnimState == newState) return;

        // play new animation
        animator.Play(newState);

        // update current animation
        CurrentAnimState = newState;
     }
}
