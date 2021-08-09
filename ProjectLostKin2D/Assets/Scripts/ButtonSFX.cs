using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    public void HoverSound()
    {
        FindObjectOfType<AudioManager>().PlayOnce("ButtonHover");
    }

    public void OnClickSound()
    {
        FindObjectOfType<AudioManager>().PlayOnce("ButtonClick");
    }
}
