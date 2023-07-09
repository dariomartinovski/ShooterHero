using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    Rigidbody2D rb;
    public LogicScript Logic;
    public HealthBarController HealthBar;
    public GameObject RiflePivot;
    public GameObject Rifle;
    private bool GameActive = true;

    //Player
    private float MoveSpeed = 4;
    private float HorizontalInput;
    private float VerticalInput;
    private int CurrentLives = 5;

    //Animations
    private Animator animator;
    private string CurrentAnimState;
    private const string HERO_IDLE = "Hero_Idle";
    private const string HERO_WALK_LEFT = "Hero_Walk_Left";
    private const string HERO_WALK_RIGHT = "Hero_Walk_Right";
    // last direction, 1 is right, -1 is left
    private int LastDirection = 1;

    // Shooting
    private Vector2 mousePos;
    public GameObject BulletPrefab;
    public Transform FiringPoint;
    private float FireRate = 0.1f;
    private float FireTimer;

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
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.position.y,
            mousePos.x - transform.position.x) * Mathf.Rad2Deg - 180f;


        if (GameActive && !Logic.PausedGame())
        {
            RiflePivot.transform.rotation = Quaternion.Euler(0, 0, angle);

            // flip the gun when it goes to the right side
            if (mousePos.x > transform.position.x)
            {
                Rifle.GetComponent<SpriteRenderer>().flipY = true; // Flip gun vertically
            }
            else
            {
                Rifle.GetComponent<SpriteRenderer>().flipY = false; // Reset gun's flip
            }

            if (Input.GetMouseButton(0) && FireTimer <= 0f)
            {
                Shoot();
                FireTimer = FireRate;
            }
            else
            {
                FireTimer -= Time.deltaTime;
            }


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
        if (GameActive && !Logic.PausedGame())
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

    private void Shoot() {
        Instantiate(BulletPrefab, FiringPoint.position, FiringPoint.rotation);
    }
}
