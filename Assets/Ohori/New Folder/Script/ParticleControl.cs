using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    [SerializeField]
    GameObject Dr; //�h�N�^�[�̃I�u�W�F�N�g

    public GameObject WaterEffct;//�����Ԃ���Effect
    public bool inRiver;//��ɓ��������̔���
    private float Time;//Effect���o�����߂̊Ԋu���v�鎞��
    public float IntervalTime;//Effect���o���Ԋu
    SoundManager soundManager;//�T�E���h���Ǘ�����script


    float speed;//���x
    Vector3 prepos;//�ЂƂO�Ƀh�N�^�[�̂����|�W�V����

    public void Start()
    {  
        soundManager = GameObject.Find("GameControl").GetComponent<SoundManager>();//GameControl��SoundManager��T���Ă���
        inRiver = false;//��ɓ��������̔���̏�����
        IntervalTime = 0.4f;//Effect���o���Ԋu�̏�����
    }

    public void Update()
    {
        speed = ((Dr.transform.position - prepos) / UnityEngine.Time.deltaTime).magnitude;
        Time += UnityEngine.Time.deltaTime;

        Invoke(nameof(PrePos_call), 0.1f);

        if (speed > 1)//�ړ����Ă��邩�̔���
        {
            if (Time >= IntervalTime)//Effect���o�����Ԃ̔���
            {
                if (inRiver)
                {
                    Instantiate(WaterEffct, this.transform.position, Quaternion.Euler(90.0f, 0f, 0f));
                    soundManager.PlaySeByName("hito_ge_aru_mizu02short");
                }//�p�[�e�B�N���p�Q�[���I�u�W�F�N�g����
                 //soundManager.StopSe();
                Time = 0.0f;
            }
        }
    }

    //�ЂƂO�Ƀh�N�^�[�̂����|�W�V�������߂郁�\�b�h
    public void PrePos_call()
    {
        prepos = Dr.transform.position;
    }

    //���̃I�u�W�F�N�g�ɏՓ˂������𒲂ׂ郁�\�b�h
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "River"){inRiver = true; }//River�^�O�̕t�����Q�[���I�u�W�F�N�g�ɓ�����������
    }

    //���̃I�u�W�F�N�g���o�������𒲂ׂ郁�\�b�h
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "River") { inRiver = false; }//River�^�O�̕t�����Q�[���I�u�W�F�N�g���o��������
    }
}