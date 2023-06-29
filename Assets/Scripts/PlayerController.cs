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

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Logic = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicScript>();
        HealthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBarController>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate(){
        if (GameActive)
        {
            rb.velocity = new Vector2(HorizontalInput, VerticalInput).normalized * MoveSpeed ;
        }
        else
        {
            rb.velocity = Vector2.zero;
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
}
