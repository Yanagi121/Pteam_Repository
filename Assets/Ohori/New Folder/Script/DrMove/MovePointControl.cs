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
        //Dr.Invisibleの移動範囲の初期化
        setMovingRange();

        //PlayerがMovwPointを移動させるかを判断する範囲に入ったかの変数の初期化
        initializePlayerIn();
    }

    // Update is called once per frame
    void Update()
    {
        //変数がtrueであれば正面に進む
        moveDr();

        //範囲外に出ないようにする
        movingRange();

        //移動する向きを求める
        directionToMove();
    }

    //PlayerがMovwPointを移動させるかを判断する範囲に入ったかの変数の初期化するメソッド
    public void initializePlayerIn()
    {
        Player1In = false;
        Player2In = false;
        Player3In = false;
        Player4In = false;
    }

    // 正面に進む.
    public void GoToTheFront()
    {
        pos += transform.forward * speed * Time.deltaTime;
        pos.y = 10.0f;
        transform.position = pos;
    }

    //変数がtrueであれば正面に進むメソッド
    public void moveDr()
    {
        if (Player1In == true) { GoToTheFront(); }
        if (Player2In == true) { GoToTheFront(); }
        if (Player3In == true) { GoToTheFront(); }
        if (Player4In == true) { GoToTheFront(); }
    }

    //Dr.Invisibleの移動範囲の初期化するメソッド
    public void setMovingRange()
    {
        Max_x = 470;
        Min_x = 90;
        Max_z = 420;
        Min_z = 130;
    }

    //範囲外に出ないようにする
    public void movingRange()
    {
        if (pos.x >= Max_x) { pos.x = Max_x; }
        if (pos.x <= Min_x) { pos.x = Min_x; }
        if (pos.z >= Max_z) { pos.z = Max_z; }
        if (pos.z <= Min_z) { pos.z = Min_z; }
    }

    //移動する向きを求めるメソッド
    public void directionToMove()
    {
        Vector3 move_vec = Dr_InvisibleControl.toPlayer1Distance + Dr_InvisibleControl.toPlayer2Distance + Dr_InvisibleControl.toPlayer3Distance + Dr_InvisibleControl.toPlayer4Distance;
        Quaternion q = Quaternion.LookRotation(-move_vec, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, q, 3.0f * Time.deltaTime);
    }
}
