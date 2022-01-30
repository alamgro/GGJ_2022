using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SINGLETON
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    #endregion

    public GameObject currentDeadRoom;
    public GameObject currentAliveRoom;
    public bool IsPlayerStateAlive { get; set; }

    [HideInInspector]
    public Player player;

    void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag(K.Tag.player).GetComponent<Player>();
        IsPlayerStateAlive = true;
    }

    void Update()
    {
        
    }

    
}
