using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.Events;

public class VideoOptionsManager : MonoBehaviour
{

    //public Dropdown resolutionDropdown;
    public TMP_Dropdown resolutionDropdown;
    Resolution selectedResolution;
    Resolution[] resolutions;
    public Toggle fullscreenToggle;

    //Resolution PlayerPrefs
    private const string resWidthPref = "ResolutionWidth";
    private const string resHeightPref = "ResolutionHeight";
    private const string resIndexPref = "ResolutionIndex";

    private int resWidth;
    private int resHeight;
    private int resIndex;

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
        } else
        {
            fullscreenToggle.isOn = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        LoadSettings();
        CreateResolutionDropdown();

        fullscreenToggle.onValueChanged.AddListener(SetFullScreen);
        resolutionDropdown.onValueChanged.AddListener(SetResolution);

        SetResolution(resolutionDropdown.value);

        Debug.Log(Screen.currentResolution.width + " x " + Screen.currentResolution.height);
    }

    public void CreateResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
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
        selectedResolution = resolutions[resolutionIndex];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);

        PlayerPrefs.SetInt(resWidthPref, selectedResolution.width);
        PlayerPrefs.SetInt(resHeightPref, selectedResolution.height);
        //PlayerPrefs.SetString(resNamePref, selectedResolution.name);
    }

    public void SaveResolution()
    {
        resIndex = PlayerPrefs.GetInt(resIndexPref, resolutionDropdown.value);
        Debug.Log("Width: " + resWidth + " and Height: " + resHeight);
        Debug.Log(resolutionDropdown.value);
        Debug.Log(resIndex);
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

    public void LoadSettings()
    {
        resIndex = PlayerPrefs.GetInt(resIndexPref);
        
        selectedResolution = new Resolution();
        selectedResolution.width = PlayerPrefs.GetInt(resWidthPref, Screen.currentResolution.width);
        selectedResolution.height = PlayerPrefs.GetInt(resHeightPref, Screen.currentResolution.height);

        fullscreenToggle.isOn = PlayerPrefs.GetInt(fullscreenPref, Screen.fullScreen ? 1 : 0) > 0;
        
        Screen.SetResolution(
            selectedResolution.width,
            selectedResolution.height,
            fullscreenToggle.isOn
        );

        SetResolution(resolutionDropdown.value);
        Debug.Log("LOADSETTINGS(): Width: " + selectedResolution.width + " and Height: " + selectedResolution.height);
        Debug.Log("LOADSETTINGS2{}: " + selectedResolution);
    }

    
}
