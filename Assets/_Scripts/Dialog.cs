using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UI_dialogDisplay;
    [SerializeField] private float typingDelay;
    [SerializeField] private AudioClip typingSound;
    [TextArea]
    [SerializeField] private string[] sentences;

    private AudioSource audioSource;
    private int index = 0;

    private IEnumerator Start()
    {
        audioSource = GetComponent<AudioSource>();
        yield return new WaitForSecondsRealtime(1f);
        if(UI_dialogDisplay)
            StartCoroutine(Type());
    }

    private IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            UI_dialogDisplay.text += letter;
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(typingSound);
            }
            yield return new WaitForSecondsRealtime(typingDelay);
        }
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
        
    }


}
