using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionJudgement : MonoBehaviour
{
    [SerializeField]
    public MovePointControl movePointControl;

    //MovwPoint���ړ������邩�𔻒f����͈͂ɓ��������̔���
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1") { movePointControl.Player1In = true; }
        if (other.gameObject.tag == "Player2") { movePointControl.Player2In = true; }
        if (other.gameObject.tag == "Player3") { movePointControl.Player3In = true; }
        if (other.gameObject.tag == "Player4") { movePointControl.Player4In = true; }
    }

    //MovwPoint���ړ������邩�𔻒f����͈͂ɓ��������̔���
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player1") { movePointControl.Player1In = false; }
        if (other.gameObject.tag == "Player2") { movePointControl.Player2In = false; }
        if (other.gameObject.tag == "Player3") { movePointControl.Player3In = false; }
        if (other.gameObject.tag == "Player4") { movePointControl.Player4In = false; }
    }
}
