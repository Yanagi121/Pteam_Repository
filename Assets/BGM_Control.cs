using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BGM_Control : MonoBehaviour
{
    SoundManager soundManager;
    private bool BGM;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("GameControl").GetComponent<SoundManager>();//GameControl‚ÌSoundManager‚ð’T‚µ‚Ä‚­‚é
        soundManager.PlayBgmByName("Game7");
        BGM = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "TestPlayScene")
        {
            soundManager.StopBgm();
            BGM = false;    
        }
        else
        {
            if (BGM==false)
            {
                soundManager.PlayBgmByName("game_6");
                BGM = true;
            }
        }
    }
}
