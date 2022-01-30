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

    void Awake()
    {
        instance = this;
        IsPlayerStateAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
