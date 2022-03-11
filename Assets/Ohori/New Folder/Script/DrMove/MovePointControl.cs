using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointControl : MonoBehaviour
{
    [SerializeField]
    public Dr_InvisibleControl Dr_InvisibleControl;

    //MovePoint�̈ʒu������ϐ�
    [SerializeField]
    public Vector3 pos;

    //MovePoint�̈ړ����x
    [SerializeField]
    public float speed = 8.0f;

    //Player��MovwPoint���ړ������邩�𔻒f����͈͂ɓ��������̕ϐ�
    [SerializeField]
    public bool Player1In;
    [SerializeField]
    public bool Player2In;
    [SerializeField]
    public bool Player3In;
    [SerializeField]
    public bool Player4In;

    [SerializeField]
    public float Max_x;
    [SerializeField]
    public float Min_x;
    [SerializeField]
    public float Max_z;
    [SerializeField]
    public float Min_z;

    void Start()
    {
        //Dr.Invisible�̈ړ��͈͂̏�����
        setMovingRange();

        //Player��MovwPoint���ړ������邩�𔻒f����͈͂ɓ��������̕ϐ��̏�����
        initializePlayerIn();
    }

    // Update is called once per frame
    void Update()
    {
        //�ϐ���true�ł���ΐ��ʂɐi��
        moveDr();

        //�͈͊O�ɏo�Ȃ��悤�ɂ���
        movingRange();

        //�ړ�������������߂�
        directionToMove();
    }

    //Player��MovwPoint���ړ������邩�𔻒f����͈͂ɓ��������̕ϐ��̏��������郁�\�b�h
    public void initializePlayerIn()
    {
        Player1In = false;
        Player2In = false;
        Player3In = false;
        Player4In = false;
    }

    // ���ʂɐi��.
    public void GoToTheFront()
    {
        pos += transform.forward * speed * Time.deltaTime;
        pos.y = 10.0f;
        transform.position = pos;
    }

    //�ϐ���true�ł���ΐ��ʂɐi�ރ��\�b�h
    public void moveDr()
    {
        if (Player1In == true) { GoToTheFront(); }
        if (Player2In == true) { GoToTheFront(); }
        if (Player3In == true) { GoToTheFront(); }
        if (Player4In == true) { GoToTheFront(); }
    }

    //Dr.Invisible�̈ړ��͈͂̏��������郁�\�b�h
    public void setMovingRange()
    {
        Max_x = 470;
        Min_x = 90;
        Max_z = 420;
        Min_z = 130;
    }

    //�͈͊O�ɏo�Ȃ��悤�ɂ���
    public void movingRange()
    {
        if (pos.x >= Max_x) { pos.x = Max_x; }
        if (pos.x <= Min_x) { pos.x = Min_x; }
        if (pos.z >= Max_z) { pos.z = Max_z; }
        if (pos.z <= Min_z) { pos.z = Min_z; }
    }

    //�ړ�������������߂郁�\�b�h
    public void directionToMove()
    {
        Vector3 move_vec = Dr_InvisibleControl.toPlayer1Distance + Dr_InvisibleControl.toPlayer2Distance + Dr_InvisibleControl.toPlayer3Distance + Dr_InvisibleControl.toPlayer4Distance;
        Quaternion q = Quaternion.LookRotation(-move_vec, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, q, 3.0f * Time.deltaTime);
    }
}
