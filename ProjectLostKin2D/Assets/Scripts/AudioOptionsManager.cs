using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOptionsManager : MonoBehaviour
{
<<<<<<< HEAD
    public static float musicVolume { get; set; }
    public static float sfxVolume { get; set; }
=======
    public static float musicVolume { get; private set; }
    public static float sfxVolume { get; private set; }
>>>>>>> parent of 4b264f0 (Revert "Merge branch 'master' into cl3362")

    [SerializeField] private Text musicText;
    [SerializeField] private Text sfxText;

    public void musicChangeValue(float value)
    {
        musicVolume = value;
        musicText.text = ((int)(value * 100)).ToString();
        AudioManager.instance.UpdateMixerVolume();
<<<<<<< HEAD

=======
>>>>>>> parent of 4b264f0 (Revert "Merge branch 'master' into cl3362")
    }

    public void sfxChangeValue(float value)
    {
        sfxVolume = value;
        sfxText.text = ((int)(value * 100)).ToString();
        AudioManager.instance.UpdateMixerVolume();
<<<<<<< HEAD
        
=======
>>>>>>> parent of 4b264f0 (Revert "Merge branch 'master' into cl3362")
    }
}
