using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointControl : MonoBehaviour
{
    [SerializeField]
    public Dr_InvisibleControl Dr_InvisibleControl;
    [SerializeField]
    public MovePointControl movePointControl;

    //Dr.Invisible��錾
    [SerializeField]
    public GameObject Dr_Invisible;

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

    void Start()
    {
        //Player��MovwPoint���ړ������邩�𔻒f����͈͂ɓ��������̕ϐ��̏�����
        Player1In = false;
        Player2In = false;
        Player3In = false;
        Player4In = false;
    }

    // Update is called once per frame
    void Update()
    {
        //�ϐ���true�ł���ΐ��ʂɐi��
        if (Player1In == true) { GoToTheFront(); }
        if (Player2In == true) { GoToTheFront(); }
        if (Player3In == true) { GoToTheFront(); }
        if (Player4In == true) { GoToTheFront(); }

        //�͈͊O�ɏo�Ȃ��悤�ɂ���
        if (pos.x >= 46) { pos.x = 46; }
        if (pos.x <= -46) { pos.x = -46; }
        if (pos.z >= 46) { pos.z = 46; }
        if (pos.z <= -46) { pos.z = -46; }

        //�ړ�������������߂�
        Vector3 move_vec = Dr_InvisibleControl.toPlayer1Distance + Dr_InvisibleControl.toPlayer2Distance + Dr_InvisibleControl.toPlayer3Distance + Dr_InvisibleControl.toPlayer4Distance;
        Quaternion q = Quaternion.LookRotation(-move_vec, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, q, 3.0f * Time.deltaTime);
    }

    // ���ʂɐi��.
    public void GoToTheFront()
    {
        pos += transform.forward * speed * Time.deltaTime;
        pos.y = 3.0f;
        transform.position = pos;
    }
}
