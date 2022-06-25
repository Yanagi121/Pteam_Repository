using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("GameControl").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            soundManager.PlaySeByName("hito_ge_aru_mizu02");
            soundManager.PlayBgmByName("game_2");
            Debug.Log("çƒê∂");
        }
    }
}
