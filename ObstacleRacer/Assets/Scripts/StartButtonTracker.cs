using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class StartButtonTracker : MonoBehaviour
{
    public GameObject startButton;
    public GameObject tuturialButton;
    public GameObject text;
    public SceneReference scene;
    private bool startClicked;
    [SerializeField] private ButtonClickedTracker tracker;

   public void Start()
    {
        text.SetActive(false);
    }
    public void Update()
    {
        if(startClicked && tracker.isClicked)
        {
            startButton.SetActive(false);
        }
    }
    public void tutClicked()
    {
        tracker.isClicked=true;
    }

    public void stopStart()
    {
        if(!tracker.isClicked)
        {
            startButton.SetActive(false);
            text.SetActive(true);
        }
        else
        {
            startButton.SetActive(true);
            SceneManager.LoadScene(scene);
            
        }
    }

}
