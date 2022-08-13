using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundControl : MonoBehaviour
{
    SoundManager soundManager;//サウンドマネージャー

    void Start()
    {
        soundManager = GameObject.Find("GameControl").GetComponent<SoundManager>();//GameControlないのSoundManagerを見つけてくる
        soundManager.PlayBgmByName("game_2");//BGMを流す
    }

    // Update is called once per frame
    void Update()
    {
    }
}
