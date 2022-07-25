using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverObject : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        if (TimeOver.gameover == true)
        {
            gameObject.transform.position = new Vector3(20,0,0);
            //gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        TimeOver.gameover = true;
    }
}
