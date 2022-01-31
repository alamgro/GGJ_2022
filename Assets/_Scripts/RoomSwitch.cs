using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitch : Interactuable
{
    [Header("Switch Room attributes")]
    [SerializeField] private GameObject targetAliveRoom;
    [SerializeField] private GameObject targetDeadRoom;
    [SerializeField] private GameObject currentRoom; //The room where this door/stairs is located
    [Header("Player Target position")]
    [SerializeField] private Transform playerInitPositionInRoom;

    void Start()
    {
       
    }

    protected override void Update()
    {
        
        overlapedColliders = Physics2D.OverlapCircleAll(interactionAreaPivot.position, interactionAreaRadio);

        readyToInteract = false;

        if (overlapedColliders.Length > 0)
        {
            foreach (Collider2D objCollider in overlapedColliders)
            {
                if (objCollider.CompareTag(K.Tag.player))
                {
                    readyToInteract = true;
                }
                //print(readyToInteract);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

    }

    public void SwitchRoom()
    {
        GameManager.Instance.currentAliveRoom = targetAliveRoom;
        GameManager.Instance.currentDeadRoom = targetDeadRoom;
        GameManager.Instance.Fade();
        if (GameManager.Instance.IsPlayerStateAlive)
        {
            targetAliveRoom.SetActive(true);
        }
        else
        {
            targetDeadRoom.SetActive(true);
        }
        GameManager.Instance.player.transform.position = playerInitPositionInRoom.position;
        //print(GameManager.Instance.IsPlayerStateAlive);
        currentRoom.SetActive(false);
    }

    public override void Interact()
    {
        //base.Interact();
        //Logic to interact and perform required actions
        if (!interactionEnabled || !readyToInteract)
            return;
        SwitchRoom();
    }


    

}
