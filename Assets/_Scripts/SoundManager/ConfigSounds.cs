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

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void gameSound()
    {
        volume = sliderVolume.value;
        PlayerPrefs.SetFloat(K.Prefs.volume, volume);
    }
}
