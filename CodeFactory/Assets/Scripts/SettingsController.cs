using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public GameObject GeneralSettings;
    public GameObject General;
    public GameObject Controls;
    public GameObject Audio;

    public void GeneralButton()
    {
        GeneralSettings.SetActive(false);
        General.SetActive(true);
    }

    public void ControlsButton()
    {
        GeneralSettings.SetActive(false);
        Controls.SetActive(true);
    }

    public void AudioButton()
    {
        GeneralSettings.SetActive(false);
        Audio.SetActive(true);
    }

    public void Back()
    {
        General.SetActive(false);
        Controls.SetActive(false);
        Audio.SetActive(false);
        GeneralSettings.SetActive(true);
    }
}
