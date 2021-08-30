using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class VideoOptionsManager : MonoBehaviour
{

    Resolution[] resolutions;

    //public Dropdown resolutionDropdown;
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    //Resolution PlayerPrefs
    private static readonly string resNamePref = "resOption";
    private static readonly string resOptionPref = "Resolution";
    private static readonly string fullscreenPref = "FullscreenToggle";
    private int toggleFullscreenState;
    private bool isFullscreen = false;


    private void Awake()
    {
        toggleFullscreenState = PlayerPrefs.GetInt(fullscreenPref);

        if(toggleFullscreenState == 1)
        {
            isFullscreen = true;
            fullscreenToggle.isOn = true;
            Debug.Log("is fullscreen");
        } else
        {
            fullscreenToggle.isOn = false;
            Debug.Log("isn't fullscreen");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for(int i = 0; i< resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);


            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        if(isFullscreen == false)
        {
            PlayerPrefs.SetInt(fullscreenPref, 0);
        } else
        {
            isFullscreen = true;
            PlayerPrefs.SetInt(fullscreenPref, 1);
        }
    }

    
}
