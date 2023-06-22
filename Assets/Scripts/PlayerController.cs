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
    float MoveSpeed = 4;
    float HorizontalInput;
    float VerticalInput;
    int CurrentLives = 5;
   // int MaxLives = 5;

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
        rb.velocity = new Vector2(HorizontalInput, VerticalInput).normalized * MoveSpeed ;
      /*  if(HorizontalInput != 0 || VerticalInput != 0){
            rb.Velocity = new Vector2(HorizontalInput * MoveSpeed, VerticalInput * MoveSpeed);
        }
        else{
            rb.Velocity = new Vector2(0, 0);
        }*/
    }

    public void TakeDamage(int num = 1)
    {
        CurrentLives -= num;
        if (CurrentLives >= 0)
        {
            Logic.TakeDamage();
            HealthBar.RemoveHeart();
            //TODO
            //GameOver();
        }
    }
}
