using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundControl : MonoBehaviour
{
    SoundManager soundManager;//�T�E���h�}�l�[�W���[

    private void Awake()
    {
        soundManager = GameObject.Find("GameControl").GetComponent<SoundManager>();//GameControl�Ȃ���SoundManager�������Ă���
        soundManager.speakerAudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        soundManager.PlaySpeakerByName("game_2");//BGM�𗬂�
    }

    // Update is called once per frame
    void Update()
    {
    }
}
