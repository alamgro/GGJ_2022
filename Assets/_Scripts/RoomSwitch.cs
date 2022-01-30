using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitch : Interactuable
{
    [Header("Switch Room attributes")]
    [SerializeField] private GameObject targetAliveRoom;
    [SerializeField] private GameObject targetDeadRoom;
    [SerializeField] private GameObject currentRoom; //The room where this door/stairs is located
    [SerializeField] private Transform playerInitPositionInRoom;
    [SerializeField] private AudioClip switchSound;

    void Start()
    {
       
    }

    protected override void Update()
    {
        base.Update();
    }

    public void SwitchRoom()
    {
        GameManager.Instance.currentAliveRoom = targetAliveRoom;
        GameManager.Instance.currentDeadRoom = targetDeadRoom;
        if (GameManager.Instance.IsPlayerStateAlive)
        {
            targetAliveRoom.SetActive(true);
        }
        else
        {
            targetDeadRoom.SetActive(true);
            AudioSource.PlayClipAtPoint(switchSound, Vector2.zero);
        }
        GameManager.Instance.player.transform.position = playerInitPositionInRoom.position;
        //print(GameManager.Instance.IsPlayerStateAlive);
        currentRoom.SetActive(false);
    }

    public override void Interact()
    {
        base.Interact();
        //Logic to interact and perform required actions
        if (!interactionEnabled || !readyToInteract)
            return;

        SwitchRoom();
    }

    

}
