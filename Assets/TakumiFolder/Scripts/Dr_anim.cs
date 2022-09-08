using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dr_anim : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    public bool Dr_runControl;//���邩�ǂ��������߂�ϐ�

    [SerializeField]
    public bool Dr_catchControl;//�߂܂��邩�ǂ��������߂�ϐ�

    [SerializeField]
    public bool Caught_DrControl;//�߂܂��邩�ǂ��������߂�ϐ�

    [SerializeField]
    GameObject Dr;

    float speed;
    Vector3 prepos;
    void Start()
    {
        // Animator�R���|�[�l���g���擾
        animator = GetComponent<Animator>();

        //runControl�̏�����
        Dr_runControl = false;
        //catchControl�̏�����
        Dr_catchControl = false;
        //�߂܂����ۂɌĂ΂��A�j���[�V����������
        Caught_DrControl = false;
    }

    // Update is called once per frame
    void Update()
    {
        speed = ((Dr.transform.position - prepos) / Time.deltaTime).magnitude;
        Invoke(nameof(PrePos_call), 0.1f);
        if (speed > 1) Dr_runControl = true;
        else Dr_runControl = false;
        //Debug.Log(speed);
        //ParipiAnimationControl�Ȃ���runControl��true��false���̔���
        //Animator�Ȃ���runControl��true/false�̔���
        
        if (Catch_Doctor.BoolCatch_Doctor)
        {
            Caught_DrControl = true;
            Debug.Log("�A�j���[�V�����u�߂܂����v");
        }
        animator.SetBool("runControl", Dr_runControl);
        animator.SetBool("caught_Dr", Caught_DrControl);
       
    }
    public void PrePos_call()
    {
        prepos = Dr.transform.position;
    }
}