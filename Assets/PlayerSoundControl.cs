using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundControl : MonoBehaviour
{
    SoundManager soundManager;//�T�E���h�}�l�[�W���[

    void Start()
    {
        soundManager = GameObject.Find("GameControl").GetComponent<SoundManager>();//GameControl�Ȃ���SoundManager�������Ă���
        soundManager.PlayBgmByName("game_2");//BGM�𗬂�
    }

    // Update is called once per frame
    void Update()
    {
    }
}
