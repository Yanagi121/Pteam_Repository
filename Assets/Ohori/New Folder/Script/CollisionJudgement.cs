using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionJudgement : MonoBehaviour
{
    [SerializeField]
    public MovePointControl movePointControl;

    //MovwPoint‚ðˆÚ“®‚³‚¹‚é‚©‚ð”»’f‚·‚é”ÍˆÍ‚É“ü‚Á‚½‚©‚Ì”»’è
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1") { movePointControl.Player1In = true; }
        if (other.gameObject.name == "Player2") { movePointControl.Player2In = true; }
        if (other.gameObject.name == "Player3") { movePointControl.Player3In = true; }
        if (other.gameObject.name == "Player4") { movePointControl.Player4In = true; }
    }

    //MovwPoint‚ðˆÚ“®‚³‚¹‚é‚©‚ð”»’f‚·‚é”ÍˆÍ‚É“ü‚Á‚½‚©‚Ì”»’è
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1") { movePointControl.Player1In = false; }
        if (other.gameObject.name == "Player2") { movePointControl.Player2In = false; }
        if (other.gameObject.name == "Player3") { movePointControl.Player3In = false; }
        if (other.gameObject.name == "Player4") { movePointControl.Player4In = false; }
    }
}
