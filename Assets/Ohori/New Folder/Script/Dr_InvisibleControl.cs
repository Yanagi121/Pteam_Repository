using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dr_InvisibleControl : MonoBehaviour
{
    [SerializeField]
    public MovePointControl movePointControl;

    [SerializeField]
    private GameObject TargetObject; /// �ڕW�ʒu
    [SerializeField]
    private float EscapeSpeed = 8.0f;//�����鑬��

    //Player��錾
    [SerializeField]
    public GameObject Player1;
    [SerializeField]
    public GameObject Player2;
    [SerializeField]
    public GameObject Player3;
    [SerializeField]
    public GameObject Player4;

    //Player�̈ʒu������ϐ�
    [SerializeField]
    public Vector3 Player1Pos;
    [SerializeField]
    public Vector3 Player2Pos;
    [SerializeField]
    public Vector3 Player3Pos;
    [SerializeField]
    public Vector3 Player4Pos;

    //�v���C���[�Ƃ̋���
    [SerializeField]
    public Vector3 toPlayer1Distance;
    [SerializeField]
    public Vector3 toPlayer2Distance;
    [SerializeField]
    public Vector3 toPlayer3Distance;
    [SerializeField]
    public Vector3 toPlayer4Distance;

    NavMeshAgent m_navMeshAgent; /// NavMeshAgent

    void Start()
    {
        //�v���C���[�Ƃ̋�����������
        toPlayer1Distance = new Vector3(0, 0, 0);
        toPlayer2Distance = new Vector3(0, 0, 0);
        toPlayer3Distance = new Vector3(0, 0, 0);
        toPlayer4Distance = new Vector3(0, 0, 0);

        // NavMeshAgent�R���|�[�l���g���擾
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        this.m_navMeshAgent.speed = EscapeSpeed;
    }

    void Update()
    {
        //Player�̈ʒu������
        Player1Pos = Player1.transform.position;
        Player2Pos = Player2.transform.position;
        Player3Pos = Player3.transform.position;
        Player4Pos = Player4.transform.position;

        //�v���C���[�Ƃ̋���������
        if (movePointControl.Player1In == true) { toPlayer1Distance = Player1Pos - transform.position; }
        if (movePointControl.Player2In == true) { toPlayer2Distance = Player2Pos - transform.position; }
        if (movePointControl.Player3In == true) { toPlayer3Distance = Player3Pos - transform.position; }
        if (movePointControl.Player4In == true) { toPlayer4Distance = Player4Pos - transform.position; }

        // NavMesh�������ł��Ă���Ȃ�
        if (m_navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid) { m_navMeshAgent.SetDestination(TargetObject.transform.position); }// NavMeshAgent�ɖړI�n���Z�b�g
    }
}
