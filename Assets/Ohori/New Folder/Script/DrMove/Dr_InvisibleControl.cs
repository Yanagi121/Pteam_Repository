using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class Dr_InvisibleControl : MonoBehaviour
{
    [SerializeField]
    public MovePointControl movePointControl;

    [SerializeField]
    private GameObject TargetObject; /// �ڕW�ʒu
    [SerializeField]
    public static float EscapeSpeed = 8.0f;//�����鑬��

    //Player��錾
    private GameObject Player1;
    private GameObject Player2;
    private GameObject Player3;
    private GameObject Player4;

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
        //�v���C���[��������
        findPlayer();

        //�v���C���[�Ƃ̋�����������
        initializeToPlayerDistance();

        // NavMeshAgent�R���|�[�l���g���擾
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        this.m_navMeshAgent.speed = EscapeSpeed;
        Debug.Log(PhotonNetwork.CountOfPlayersInRooms + 1 + "/" + PhotonNetwork.CountOfPlayers);//���[�����̐l���c�����s���A���if���Ŏ擾����I�u�W�F�N�g�̐������߂�
    }

    void Update()
    {
        //Player�̈ʒu������
        setPlayerPos();

        //�v���C���[�Ƃ̋���������
        setToPlayerDistance();

        // NavMesh�������ł��Ă���Ȃ�
        if (m_navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid) { m_navMeshAgent.SetDestination(TargetObject.transform.position); }// NavMeshAgent�ɖړI�n���Z�b�g

        if (Catch_Doctor.BoolCatch_Doctor == true)
        {
            this.m_navMeshAgent.speed = 0f;
            Debug.Log("���m���܂���:"+EscapeSpeed);
        }
    }

    //�v���C���[�������郁�\�b�h    
    public void findPlayer()
    {
        Player1 = GameObject.Find("Player1(Clone)");
        Player2 = GameObject.Find("Player2(Clone)");
        Player3 = GameObject.Find("Player3(Clone)");
        Player4 = GameObject.Find("Player4(Clone)");
    }

    //�v���C���[�Ƃ̋��������������郁�\�b�h
    public void initializeToPlayerDistance()
    {
        toPlayer1Distance = new Vector3(0, 0, 0);
        toPlayer2Distance = new Vector3(0, 0, 0);
        toPlayer3Distance = new Vector3(0, 0, 0);
        toPlayer4Distance = new Vector3(0, 0, 0);
    }

    //Player�̈ʒu�����郁�\�b�h
    public void setPlayerPos()
    {
        Player1Pos = Player1.transform.position;
        //Debug.Log("player1Pos:" + Player1Pos);
        Player2Pos = Player2.transform.position;
        Player3Pos = Player3.transform.position;
        Player4Pos = Player4.transform.position;
    }

    //�v���C���[�Ƃ̋��������郁�\�b�h
    public void setToPlayerDistance()
    {
        if (movePointControl.Player1In == true) { toPlayer1Distance = Player1Pos - transform.position; }
        if (movePointControl.Player2In == true) { toPlayer2Distance = Player2Pos - transform.position; }
        if (movePointControl.Player3In == true) { toPlayer3Distance = Player3Pos - transform.position; }
        if (movePointControl.Player4In == true) { toPlayer4Distance = Player4Pos - transform.position; }
    }
}
