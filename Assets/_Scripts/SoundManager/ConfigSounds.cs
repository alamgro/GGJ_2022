using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigSounds : MonoBehaviour
{
    #region SINGLETON
    private static ConfigSounds instance;
    public static ConfigSounds Instance { get { return instance; } }
    #endregion

    public float volume;
    public Slider sliderVolume;

    [SerializeField] Vector2 rangeReproduceSound;
    [SerializeField] AudioClip[] audioClips;

    private float reproduceSoundInTime = 0f;
    private float timer = 0f;

    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (sliderVolume)
        {
            volume = sliderVolume.value;
        }
        volume = PlayerPrefs.GetFloat(K.Prefs.volume, volume);

        reproduceSoundInTime = Random.Range(rangeReproduceSound.x, rangeReproduceSound.y);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= reproduceSoundInTime)
        {
            timer = 0f;
            int randClip = Random.Range(0, audioClips.Length);
            AudioSource.PlayClipAtPoint(audioClips[randClip], Vector2.zero, volume);
            reproduceSoundInTime = Random.Range(rangeReproduceSound.x, rangeReproduceSound.y);
        }
    }
    public void gameSound()
    {
        volume = sliderVolume.value;
        PlayerPrefs.SetFloat(K.Prefs.volume, volume);
    }
}
