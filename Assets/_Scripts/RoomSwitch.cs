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

    void Start()
    {
       
    }

    void Update()
    {
        
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

        }
        print(GameManager.Instance.IsPlayerStateAlive);
        currentRoom.SetActive(false);

    }

}
