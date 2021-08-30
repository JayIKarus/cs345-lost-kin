using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup sfxMixerGroup;

    public Slider bgmSlider, sfxSlider;
    private float bgmFloat, sfxFloat;

    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string bgmPref = "Music";
    private static readonly string sfxPref = "SFX";

    private string MainMenuTrack = "MainMenu";

    private bool isPlayingMainMenuTrack;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            switch (s.audioType)
            {
                case Sound.AudioTypes.SFX:
                    s.source.outputAudioMixerGroup = sfxMixerGroup;
                    break;

                case Sound.AudioTypes.Music:
                    s.source.outputAudioMixerGroup = musicMixerGroup;
                    break;
            }
        }
    }

    public void Start()
    {
        Play(MainMenuTrack);
        isPlayingMainMenuTrack = true;
        LoadValues();
    }

    public void SwapTrack()
    {
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
        s.source.Play();
    }

    public void PlayOnce(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
        s.source.PlayOneShot(s.clip);
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
        s.source.Stop();
    }

    public void getTrack(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
    }

    public void UpdateMixerVolume()
    {
        musicMixerGroup.audioMixer.SetFloat("Music Volume", Mathf.Log10(AudioOptionsManager.musicVolume) * 20);
        musicMixerGroup.audioMixer.SetFloat("SFX Volume", Mathf.Log10(AudioOptionsManager.sfxVolume) * 20);
    }

    public void SaveBGM()
    {
        bgmFloat = bgmSlider.value;
        PlayerPrefs.SetFloat(bgmPref, bgmFloat);
        //Debug.Log(bgmFloat);
    }

    public void SaveSFX()
    {
        sfxFloat = sfxSlider.value;
        PlayerPrefs.SetFloat(sfxPref, sfxFloat);

        //Debug.Log(sfxFloat);
    }

    void LoadValues()
    {
        bgmFloat = PlayerPrefs.GetFloat(bgmPref);
        sfxFloat = PlayerPrefs.GetFloat(sfxPref);
        bgmSlider.value = bgmFloat;
        sfxSlider.value = sfxFloat;
    }



}
