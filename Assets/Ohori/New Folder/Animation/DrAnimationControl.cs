using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class DrAnimationControl : MonoBehaviour
{
    Animator animator;
    NavMeshAgent m_navMeshAgent; // NavMeshAgent

    [SerializeField]
    public bool runControl;//���邩�ǂ��������߂�ϐ�


    void Start()
    {
        // NavMeshAgent�R���|�[�l���g���擾
        m_navMeshAgent = GetComponent<NavMeshAgent>();

        // Animator�R���|�[�l���g���擾
        animator = GetComponent<Animator>();

        //runControl�̏�����
        runControl = false;
    }

    void Update()
    {
        //DrAnimationControl�Ȃ���runControl��true��false���̔���
        MoveJudgment();

        //Animator�Ȃ���runControl��true/false�̔���
        animator.SetBool("runControl", runControl);
    }

    //DrAnimationControl�Ȃ���runControl��true��false���̔��肷�郁�\�b�h
    public void MoveJudgment()
    {
        // NavMesh�������ł��Ă���Ȃ�
        if (m_navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid) { runControl = true; }
        else { runControl = false; }
    }
}
