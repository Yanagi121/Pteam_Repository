using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch_Doctor : MonoBehaviour
{
    public float SlowTime=1;
    public static bool SetTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SetTime)
            SetSlowTime();
        //Time.timeScale = SlowTime;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Dr") && Input.GetMouseButtonDown(0))
        {
            SetTime = true;
            TimeOver.gameover = true;
        }
    }
    void SetSlowTime()
    {
        if (SlowTime >= 0)
            SlowTime -= 0.05f;
        else
            SlowTime = 0;
    }
}
