using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region SINGLETON
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    #endregion

    public GameObject currentAliveRoom;
    public GameObject currentDeadRoom;
    public bool IsPlayerStateAlive { get; set; }

    [HideInInspector]
    public Player player;

    void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag(K.Tag.player).GetComponent<Player>();
        IsPlayerStateAlive = true;
        print( Quaternion.AngleAxis(-26f, Vector3.forward) * Vector3.right);
    }

    public void SwitchDimension()
    {
        print("Switching dimension...");
        IsPlayerStateAlive = !IsPlayerStateAlive;

        currentAliveRoom.SetActive(IsPlayerStateAlive);
        currentDeadRoom.SetActive(!IsPlayerStateAlive);
    }
    
}
