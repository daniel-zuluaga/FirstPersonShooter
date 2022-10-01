using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenOption : MonoBehaviour
{
    public Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateFullScreen(bool FullScreen)
    {
        Screen.fullScreen = FullScreen;
    }
}
