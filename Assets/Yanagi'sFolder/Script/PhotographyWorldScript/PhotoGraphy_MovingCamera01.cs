using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PhotoGraphy_MovingCamera01 : MonoBehaviour
{
    float  ElapsedTime;
    [SerializeField] float CountTime,SettingTime=5f;
    [SerializeField] GameObject Chair;
    int SaveCountTime=0;
    bool isOne=true;
    Vector3 CameraPos,CameraRot,CameraSpeed,LocalCameraSpeed;
    float[,,] ArrayCameraTransform;
    float[] a =new float[] { 1,1,1};
    // Start is called before the first frame update
    public enum ActionPatterns//��Ԃ��Ǘ�
    {
        FirstElapsed,
        SecondElapsed,
        ThirdElapsed,
        FourthElapsed,
        FifthElapsed,

    }
    private ActionPatterns Pattern;
    void Start()
    {
        ArrayCameraTransform = new float[,,] { 
            {{-111.62f , 141.1f , 183.3f }, {20.62f, 90f , 0f }, {0.1f , 0 , 0 } ,{0,0,0 } },
            {{178.5f, 26.13f,372.41f },{-24.6f,0f,0f },{0.1f,0,0 },{0,0,0 } } ,
            {{279.78f,26.66f,119.56f },{-7.3f,201.5f,0f },{0,0,0 },{0.025f,0,0} },
            {{263.05f,29.35f,113.49f},{-0.981f,370.446f,-1.41f},{0,0,0},{0,0,0 } },
            {{191.2f,27f,223.7f},{-22.29f,464.3f,-1.405f },{0,0,0 },{0,0,0 } }
        };/*���Ɂi�|�W�V����X���W�AY���W�AZ���W�@�A
        �@�@�@�@�@���[�e�[�V����X���W�AY���W�AZ���W�@�A
            �@�@�@�J�����̈ړ����xX���W�AY���W�AZ���W�@�A
           �@�@�@ �J�����̃��[�J�������ɑ΂��Ă̈ړ����xX���W�AY���W�AZ���W�j*/
    }

    // Update is called once per frame
    void Update()
    {
        TimeMeasurenment();
        MovingCamera();
        Debug.Log(" Pattern:"+Pattern+" Count:"+ SaveCountTime+"  time:"+ ElapsedTime);
    }

    void TimeMeasurenment()//���Ԃ̌o�ߋy�ьo�߂ɂ��ActionPatterns����
    {
        
        ElapsedTime = (int)Time.time;//�m�F�p
        CountTime += Time.deltaTime;//���p
        if (CountTime >= SettingTime)//SettingTime(�����l�͂T�b)�o�߂�Pattern�����֐i�ށASettingTime(�����l�͂T�b)�𒴂�����Count�͂O�ɂȂ�
        {
            if(SaveCountTime< Enum.GetNames(typeof(ActionPatterns)).Length-1)//ActionPatterns�̗v�f����CountTime���ǂ��t������J�E���g�̑��������s���Ȃ�
                SaveCountTime++;//Pattern�̃J�E���g�𑝉�
            Pattern = (ActionPatterns)Enum.ToObject(typeof(ActionPatterns), SaveCountTime);//��������K�p
            CountTime = 0;//�J�E���g��0��
            isOne = true; //MovingCamera�̃J�����ʒu�����Z�b�g����ۂɎg�p
        }
    }
    void MovingCamera()//�J�����̈ړ�����
    {   
        if (isOne)//�J�����̈ʒu�����Z�b�g
        {
            SetCameraTransform((int)Pattern);//�J�����̏����ʒu�A�p�x�A�ړ����x��ݒ�
            this.transform.position = CameraPos;//�|�W�V�������Z�b�g
            this.transform.eulerAngles = CameraRot;//���[�e�[�V�������Z�b�g
            SetActiveObject();//�I�u�W�F�N�g�̕\����\���i�֎q�̔w�ʂ������ɂȂ��Ă��邽�ߌ����ڏ�K�v�ȏ����j
            isOne = false;
        }
        this.transform.position += CameraSpeed;//�J�����ړ�
        this.gameObject.transform.Translate(LocalCameraSpeed);//���[�J�����W�̃J�����ړ�

    }
    void SetCameraTransform(int PatterNnum)//�J�����̈ړ������A�ʒu�Ȃǂ��L��
    {
        CameraPos = new Vector3(ArrayCameraTransform[PatterNnum,0, 0], ArrayCameraTransform[PatterNnum,0, 1], ArrayCameraTransform[PatterNnum,0, 2]);
        CameraRot = new Vector3(ArrayCameraTransform[PatterNnum,1, 0], ArrayCameraTransform[PatterNnum,1, 1], ArrayCameraTransform[PatterNnum,1, 2]);
        CameraSpeed = new Vector3(ArrayCameraTransform[PatterNnum,2, 0], ArrayCameraTransform[PatterNnum,2, 1], ArrayCameraTransform[PatterNnum,2, 2]);
        LocalCameraSpeed = new Vector3(ArrayCameraTransform[PatterNnum,3, 0], ArrayCameraTransform[PatterNnum,3, 1],ArrayCameraTransform[PatterNnum,3, 2]);
    }
    void SetActiveObject()//�I�u�W�F�N�g�̎��Ԃɂ��\������
    {
        switch ((int)Pattern)
        {
            case (int)ActionPatterns.FourthElapsed:
                Chair.SetActive(true);
                break;
            default:
                Chair.SetActive(false);
                break;
        }
    }
}
