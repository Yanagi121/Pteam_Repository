using UnityEngine;
using System.Collections;


public class ParipiAnimationControl : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    public bool runControl;//���邩�ǂ��������߂�ϐ�


    void Start()
    {
        // Animator�R���|�[�l���g���擾
        animator = GetComponent<Animator>();

        //runControl�̏�����
        runControl = false;
    }

    void Update()
    {
        //ParipiAnimationControl�Ȃ���runControl��true��false���̔���
        MoveJudgment();

        //Animator�Ȃ���runControl��true/false�̔���
        animator.SetBool("runControl", runControl);
    }

    //ParipiAnimationControl�Ȃ���runControl��true��false���̔��肷�郁�\�b�h
    public void MoveJudgment()
    {
        if(UnityEngine.Input.GetAxis("Horizontal")!=0) { runControl = true; }
        else { runControl = false; };
        if (UnityEngine.Input.GetAxis("Vertical") != 0) { runControl = true; }
        else { runControl = false; };
        /*
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")){ runControl = true;}
        else{runControl = false; }
        if (Input.GetKey("up") || Input.GetKey("left") || Input.GetKey("down") || Input.GetKey("right")) { runControl = true; }
        else { runControl = false; }
        */
    }
}
