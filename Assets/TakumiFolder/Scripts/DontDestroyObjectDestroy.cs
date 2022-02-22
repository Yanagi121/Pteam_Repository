using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObjectDestroy : MonoBehaviour
{
    GameObject Cam1;
    void Start()
    {
        
    }

    void Update()
    {
        if (GameObject.Find("Camera1"))
        {
            Cam1 = GameObject.Find("Camera1");
            Destroy(Cam1);
        }
    }
}
