using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOver : MonoBehaviour
{
    // Start is called before the first frame update
    //カウントダウン
    public float countdown = 300.0f;
    public static bool gameover;
    [SerializeField] bool game;

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
            countdown -= Time.deltaTime;
        else
        {
            countdown = 0;
            gameover = true;
            
        }
    }
}
