using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float BulletSpeed = 10f;
    private float LifeTime = 2f;
    
    // Components
    public LogicScript Logic;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, LifeTime);
        Logic = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicScript>();
    }

    private void FixedUpdate() {
        rb.velocity = -transform.right * BulletSpeed;
        //add a trigger later triggerEnter2d
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.CompareTag("Enemy"))
        {
            Destroy(Other.gameObject);
            Destroy(gameObject);
            Logic.Hit();
        }
    }
}
