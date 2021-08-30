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

<<<<<<< HEAD
<<<<<<< HEAD
    public Slider bgmSlider, sfxSlider;
    private float bgmFloat, sfxFloat;

    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string bgmPref = "Music";
    private static readonly string sfxPref = "SFX";

=======
>>>>>>> parent of 4b264f0 (Revert "Merge branch 'master' into cl3362")
=======
>>>>>>> parent of 240d573 (Revert "Merge branch 'master' into nca35")
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
        Play("MainMenu");
        LoadValues();
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

    public void UpdateMixerVolume()
    {
        musicMixerGroup.audioMixer.SetFloat("Music Volume", Mathf.Log10(AudioOptionsManager.musicVolume) * 20);
        musicMixerGroup.audioMixer.SetFloat("SFX Volume", Mathf.Log10(AudioOptionsManager.sfxVolume) * 20);
<<<<<<< HEAD
<<<<<<< HEAD
        Debug.Log(AudioOptionsManager.musicVolume);
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
=======
>>>>>>> parent of 4b264f0 (Revert "Merge branch 'master' into cl3362")
=======
>>>>>>> parent of 240d573 (Revert "Merge branch 'master' into nca35")
    }
}
