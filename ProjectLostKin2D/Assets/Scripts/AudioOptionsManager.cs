using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOptionsManager : MonoBehaviour
{
    public static float musicVolume { get; private set; }
    public static float sfxVolume { get; private set; }

    [SerializeField] private Text musicText;
    [SerializeField] private Text sfxText;

    public void musicChangeValue(float value)
    {
        musicVolume = value;
        musicText.text = ((int)(value * 100)).ToString();
        AudioManager.instance.UpdateMixerVolume();
    }

    public void sfxChangeValue(float value)
    {
        sfxVolume = value;
        sfxText.text = ((int)(value * 100)).ToString();
        AudioManager.instance.UpdateMixerVolume();
    }
}
