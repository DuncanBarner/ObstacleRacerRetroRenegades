using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Saves the values of all the sound sliders and then resets entering and exiting playmode
/// </summary>
[CreateAssetMenu(fileName = "MenuSettings", menuName = "SO/Data/Menu/Sound", order = 1)]
public class SoundMenu : ScriptableObject
{
    public float masterVolume;
    public float sFXVolume;
    public float musicVolume;
    private void OnDisable()
    {
        masterVolume = 1f; sFXVolume= 1f; musicVolume = 1f;
    }
}
