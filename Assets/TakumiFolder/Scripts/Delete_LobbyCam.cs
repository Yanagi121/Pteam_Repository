using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_LobbyCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Camera1")) Destroy(GameObject.Find("Camera1"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
