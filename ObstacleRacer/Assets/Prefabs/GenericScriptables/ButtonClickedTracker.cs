using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Trackers", menuName = "UI/Buttons")]

public class ButtonClickedTracker : ScriptableObject
{
    public bool isClicked;

    public void OnEnable()
    {
        isClicked = false;
    }
}
