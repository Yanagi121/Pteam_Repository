using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Cam2Destroy : MonoBehaviour
{
    void Start()
    {
        if (GameObject.Find("Cam2"))
        {
            Destroy(GameObject.Find("Cam2"));
        }
    }
}
