using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string tagName;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] stuff = GameObject.FindGameObjectsWithTag(tagName);
        foreach (GameObject go in stuff) 
        { 
           Destroy(go); 
        }
        
    }
}
