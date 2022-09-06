using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundControl : MonoBehaviour
{
    SoundManager soundManager;//サウンドマネージャー

    private void Awake()
    {
        soundManager = GameObject.Find("GameControl").GetComponent<SoundManager>();//GameControlないのSoundManagerを見つけてくる
        soundManager.speakerAudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        soundManager.PlaySpeakerByName("game_6");//BGMを流す
        Debug.Log("play_oto");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
