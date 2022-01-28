using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionObjects : MonoBehaviour
{
    [SerializeField]
    public GameObject[] objectsToHIDE;

    public static bool isActive = true;
    // Start is called before the first rame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DesActivateObjects()
    {
        if (isActive == true)
        {
            for (int contador = 0; contador < objectsToHIDE.Length; contador++)
            {
                objectsToHIDE[contador].SetActive(false);
            }
            isActive = false;
        }
        else
        {
            for (int contador = 0; contador < objectsToHIDE.Length; contador++)
            {
                objectsToHIDE[contador].SetActive(true);
            }
            isActive = true;
        }
        
    }
   
}
