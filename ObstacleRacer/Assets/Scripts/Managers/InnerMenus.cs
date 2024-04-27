using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerMenus : MonoBehaviour
{
    public GameObject thing;

    private void Start(){thing.SetActive(false);}

    public void Activate()  { thing.SetActive(true);}

    public void Deactivate() { thing.SetActive(false);}

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
            Deactivate();
    }
}
