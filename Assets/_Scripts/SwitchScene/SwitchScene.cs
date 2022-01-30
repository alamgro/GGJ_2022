using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    
    public ArrayList[] ListMusic;
    public AudioSource playMoan;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickSound()
    {
        StartCoroutine(soundPlayMoan());
    }
    IEnumerator soundPlayMoan()
    {
        playMoan.Play();
        yield return new WaitForSeconds(3f);
        Debug.Log("Comenzando Juego");
        SceneManager.LoadScene("SampleScene");
        
        soundPlayMoan();
    }
    
}
