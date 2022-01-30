using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Move
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 playerInput;
    Vector2 playerMove;
    //GestionWorlds
    public GestionObjects gestionObjects;

    [SerializeField] private RuntimeAnimatorController aliveAnimController;
    [SerializeField] private RuntimeAnimatorController deadAnimController;
    
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
        anim.runtimeAnimatorController = aliveAnimController;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.PlayerInteracting)
            return;
        //Movement Player
        playerInput.x = Input.GetAxisRaw("Horizontal");
        playerInput.y = Input.GetAxisRaw("Vertical");
        

        if (playerInput.x > 0f ) //Move right = D
        {
            //playerMove = new Vector2(1f, -1f).normalized;
            playerMove = new Vector2(0.9f, -0.5f);
            anim.SetBool(K.Animation.backWalk, false);
            anim.SetBool(K.Animation.frontWalk, true);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (playerInput.x < 0f) //Move left = A
        {
            //playerMove = new Vector2(-1f, 1f).normalized;
            playerMove = new Vector2(-0.9f, 0.5f);
            anim.SetBool(K.Animation.frontWalk, false);
            anim.SetBool(K.Animation.backWalk, true);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (playerInput.y > 0f) // Move Up = W
        {
            //playerMove = new Vector2(1f, 1f).normalized;
            playerMove = new Vector2(0.9f, 0.5f);
            anim.SetBool(K.Animation.backWalk, true);
            anim.SetBool(K.Animation.frontWalk, false);
            transform.localScale = Vector3.one;
        }
        else if (playerInput.y < 0f) //Move Down = S
        {
            //playerMove = new Vector2(-1f, -1f).normalized;
            playerMove = new Vector2(-0.9f, -0.5f);
            anim.SetBool(K.Animation.backWalk, false);
            anim.SetBool(K.Animation.frontWalk, true);
            transform.localScale = Vector3.one;
        }
        else
        {
            playerMove = Vector2.zero;
            transform.localScale = Vector3.one;
            anim.SetBool(K.Animation.backWalk, false);
            anim.SetBool(K.Animation.frontWalk, false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gestionObjects.DesActivateObjects();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameManager.Instance.SwitchDimension();
            anim.runtimeAnimatorController = GameManager.Instance.IsPlayerStateAlive ? aliveAnimController : deadAnimController;
        }

        //Animator

    }
    void FixedUpdate()
    {
        if (GameManager.Instance.PlayerInteracting)
            return;
        rb.velocity = playerMove * moveSpeed * Time.fixedDeltaTime;
    }
    
}
    