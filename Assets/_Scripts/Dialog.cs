using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    #region SINGLETON
    private static Dialog instance;
    public static Dialog Instance { get { return instance; } }
    #endregion

    [SerializeField] private TextMeshProUGUI UI_dialogDisplay;
    [SerializeField] private GameObject UI_btnContinue;
    [SerializeField] private float typingDelay;
    [SerializeField] private AudioClip typingSound;
    [TextArea] [HideInInspector]
    public string[] sentences;

    private AudioSource audioSource;
    private int index = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //yield return new WaitForSecondsRealtime(1f);
        /*if(UI_dialogDisplay.gameObject.activeInHierarchy)
            StartCoroutine(Type());
        */
        UI_dialogDisplay.transform.parent.gameObject.SetActive(false);
        UI_btnContinue.SetActive(false);
    }

    public void StartTyping()
    {
        index = 0;
        GameManager.Instance.PlayerInteracting = true;
        UI_dialogDisplay.transform.parent.gameObject.SetActive(true);
        StartCoroutine(Type());
    }

    private IEnumerator Type()
    {
        UI_btnContinue.SetActive(false);
        foreach (char letter in sentences[index].ToCharArray())
        {
            UI_dialogDisplay.text += letter;
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(typingSound, ConfigSounds.Instance.volume);
            }
            
            yield return new WaitForSecondsRealtime(typingDelay);
        }
        UI_btnContinue.SetActive(true);
    }

    public void NextSentence()
    {
        if (UI_dialogDisplay.text != sentences[index])
            return;

        UI_dialogDisplay.text = string.Empty;

        if (index < sentences.Length - 1)
        {
            index++;
            StartCoroutine(Type());
        }
        else if(index == sentences.Length - 1)
        {
            GameManager.Instance.PlayerInteracting = false;
            UI_dialogDisplay.transform.parent.gameObject.SetActive(false);
        }

    }


}
