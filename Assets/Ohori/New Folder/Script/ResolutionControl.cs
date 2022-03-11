using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionControl : MonoBehaviour
{
    //çÇ
    public void On1920()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    //íÜ
    public void On1440()
    {
        Screen.SetResolution(1440, 810, true);
    }

    //í·
    public void On1280()
    {
        Screen.SetResolution(1280, 720, true);
    }
}
