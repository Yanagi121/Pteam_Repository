using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch_Doctor : MonoBehaviour
{
    public float SlowTime=1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Dr") && Input.GetMouseButtonDown(0))
        {
            TimeOver.gameover = true;
        }
    }
   
}
