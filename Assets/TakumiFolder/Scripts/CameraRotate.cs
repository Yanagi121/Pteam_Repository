using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    float R;
    // Start is called before the first frame update
    void Start()
    {
        R = 0;
    }

    // Update is called once per frame
    void Update()
    {
        R++;
        transform.localRotation = Quaternion.Euler(-40f, R*0.05f,0);
    }
}