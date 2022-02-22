using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObjectDestroy : MonoBehaviour
{
    GameObject Cam1;
    GameObject[] players;
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
        for(int i = 0; i < 4; i++)
        {
            if (GameObject.Find("Player" +(i+1)))
            {
                Destroy(players[i+1]);
            }
        }
        
    }
}
