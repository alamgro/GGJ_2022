using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float  moveSpeed;
    public Rigidbody2D rb;
    Vector2 move;
    public GameObject rendGod;
    public GameObject rendBad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement Player
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        if (move.x != 0)
        {
            move.y = 0;
        }
        else if (move.y != 0)
        {
            move.x = 0;
         }

        //Animator

        
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }
}
