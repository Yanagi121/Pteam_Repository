using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointControl : MonoBehaviour
{
    [SerializeField]
    public Dr_InvisibleControl Dr_InvisibleControl;

    //MovePointの位置を入れる変数
    [SerializeField]
    public Vector3 pos;

    //MovePointの移動速度
    [SerializeField]
    public float speed = 8.0f;

    //PlayerがMovwPointを移動させるかを判断する範囲に入ったかの変数
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
        //PlayerがMovwPointを移動させるかを判断する範囲に入ったかの変数の初期化
        Player1In = false;
        Player2In = false;
        Player3In = false;
        Player4In = false;
    }

    // Update is called once per frame
    void Update()
    {
        //変数がtrueであれば正面に進む
        if (Player1In == true) { GoToTheFront(); }
        if (Player2In == true) { GoToTheFront(); }
        if (Player3In == true) { GoToTheFront(); }
        if (Player4In == true) { GoToTheFront(); }

        //範囲外に出ないようにする
        if (pos.x >= 470) { pos.x = 470; }
        if (pos.x <= 90) { pos.x = 90; }
        if (pos.z >= 420) { pos.z = 420; }
        if (pos.z <= 130) { pos.z = 130; }

        //移動する向きを求める
        Vector3 move_vec = Dr_InvisibleControl.toPlayer1Distance + Dr_InvisibleControl.toPlayer2Distance + Dr_InvisibleControl.toPlayer3Distance + Dr_InvisibleControl.toPlayer4Distance;
        Quaternion q = Quaternion.LookRotation(-move_vec, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, q, 3.0f * Time.deltaTime);
    }

    // 正面に進む.
    public void GoToTheFront()
    {
        pos += transform.forward * speed * Time.deltaTime;
        pos.y = 10.0f;
        transform.position = pos;
    }
}
