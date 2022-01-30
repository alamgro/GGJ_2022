using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Move
    public float  moveSpeed;
    public Rigidbody2D rb;
    Vector2 playerInput;
    Vector2 playerMove;
    //GestionWorlds
    public GestionObjects gestionObjects;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement Player
        playerInput.x = Input.GetAxisRaw("Horizontal");
        playerInput.y = Input.GetAxisRaw("Vertical");

        playerMove = Vector2.zero;
        if (playerInput.x > 0f ) //Move right = D
        {
            playerMove = new Vector2(1f, -1f).normalized;
        }
        else if (playerInput.x < 0f) //Move left = A
        {
            playerMove = new Vector2(-1f, 1f).normalized;
        }
        else if (playerInput.y > 0f) // Move Up = W
        {
            
            playerMove = new Vector2(1f, 1f).normalized;
        }
        else if (playerInput.y < 0f) //Move Down = S
        {
            playerMove = new Vector2(-1f, -1f).normalized;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gestionObjects.DesActivateObjects();
        }
        
        //Animator

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + playerMove  * moveSpeed * Time.fixedDeltaTime);
    }
    
}
    