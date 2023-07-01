using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    Rigidbody2D rb;
    public LogicScript Logic;
    public HealthBarController HealthBar;

    //Player
    private float MoveSpeed = 4;
    private float HorizontalInput;
    private float VerticalInput;
    private int CurrentLives = 5;
    private bool GameActive = true;

    //Animations
    private Animator animator;
    private string CurrentAnimState;
    private const string HERO_IDLE = "Hero_Idle";
    private const string HERO_WALK_LEFT = "Hero_Walk_Left";
    private const string HERO_WALK_RIGHT = "Hero_Walk_Right";
    // last direction, 1 is right, -1 is left
    private int LastDirection = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Logic = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicScript>();
        HealthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBarController>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");

        if (GameActive)
        {
            // Change move animations
            if (HorizontalInput > 0)
            {
                ChangeAnimationState(HERO_WALK_RIGHT);
                LastDirection = 1;
            }
            else if (HorizontalInput < 0)
            {
                ChangeAnimationState(HERO_WALK_LEFT);
                LastDirection = -1;
            }
            else if (VerticalInput > 0)
            {
                if (LastDirection < 0)
                    ChangeAnimationState(HERO_WALK_LEFT);
                else
                    ChangeAnimationState(HERO_WALK_RIGHT);
            }
            else if (VerticalInput < 0)
            {
                if (LastDirection < 0)
                    ChangeAnimationState(HERO_WALK_LEFT);
                else
                    ChangeAnimationState(HERO_WALK_RIGHT);
            }
            else
            {
                ChangeAnimationState(HERO_IDLE);
            }
        }
    }

    void FixedUpdate(){
        if (GameActive)
        {
            rb.velocity = new Vector2(HorizontalInput, VerticalInput).normalized * MoveSpeed ;
        }
        else
        {
            rb.velocity = Vector2.zero;
            ChangeAnimationState(HERO_IDLE);
        }
    }

    public void TakeDamage(int num = 1)
    {
        CurrentLives -= num;
        Logic.TakeDamage();
        HealthBar.RemoveHeart();
    }

    public void StopMovement() {
        GameActive = false;
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
