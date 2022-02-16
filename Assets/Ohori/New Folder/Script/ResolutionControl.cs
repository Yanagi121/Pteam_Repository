using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionControl : MonoBehaviour
{
    //��
    public void On1920()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    //��
    public void On1440()
    {
        Screen.SetResolution(1440, 810, true);
    }

    //��
    public void On1280()
    {
        Screen.SetResolution(1280, 720, true);
    }
}
