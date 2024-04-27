using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SwitchScene : MonoBehaviour
{
    public SceneReference scene ;

  public void switchScene()
    {
        SceneManager.LoadScene(scene);
       
    }
}
