using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the sliders in union with the SoundMenu SO
/// </summary>
// This is just a rough work around, I imagine there are cleaner ways to do this
public class SliderManager : MonoBehaviour
{

    public Slider slider;
    public bool master = false;
    public bool sfx = false;
    public bool music = false;
    public SoundMenu soundMenu;

    private void Start()
    {
        if (master)
            slider.value = soundMenu.masterVolume;
        else if (sfx)
            slider.value = soundMenu.sFXVolume;
        else if(music)
            slider.value = soundMenu.musicVolume;
    }

    private void Update()
    {
        if (master)
            soundMenu.masterVolume = slider.value;
        else if (sfx)
            soundMenu.sFXVolume = slider.value;
        else if (music)
            soundMenu.musicVolume = slider.value;
    }
}
