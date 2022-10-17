using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
///敵の場所を指す矢印（矢印オブジェクトに結び付けて使う） 
/// </summary>
public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private Transform playerTrans = null;
    
    [SerializeField,Header("基準となるベクトル")]
    private Vector3 forward = Vector3.forward;//
    
    [SerializeField]
    private Transform targetTrans = null;

    [SerializeField] float y_pos;

    void Start()
    {
        switch (//DontDestroy_Porder.Porder_handover
                1)
        {
            case 1: playerTrans=GameObject.Find("Player1(Clone)").transform; break;
            case 2: playerTrans = GameObject.Find("Player2(Clone)").transform; break;
            case 3: playerTrans = GameObject.Find("Player3(Clone)").transform; break;
            case 4: playerTrans = GameObject.Find("Player4(Clone)").transform; break;
        }
    }

    void LateUpdate()
    {

        // プレイヤーからターゲットまでのベクトル
        var direction = (playerTrans.transform.position-targetTrans.position).normalized;
        transform.position = new Vector3(playerTrans.position.x,playerTrans.position.y+y_pos,playerTrans.position.z);
        // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
        //Debug.Log(direction);

        // ターゲット方向への回転(オブジェクトの前方方向を軸に回転)
        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        // 回転補正(z軸が想定しない方向だった場合必要)
        //矢印のz方向を意図した方向に向かせる
        var offRotation = Quaternion.FromToRotation(forward, Vector3.forward);
        // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
        //Debug.Log(offRotation);
        
        // 向きを計算
        var vec = (lookRotation * offRotation).eulerAngles;

        // 向きを反映
        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(0, vec.y, 0),3f*Time.deltaTime);
    }
}



