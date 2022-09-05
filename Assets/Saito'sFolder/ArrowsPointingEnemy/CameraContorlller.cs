using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーに追従するカメラ
/// </summary>
public class CameraContorlller : MonoBehaviour
{
    [SerializeField] Transform playerTrans;

    [SerializeField] Vector3 cameraVec;
    [SerializeField] Vector3 cameraRot;
    Transform _cameraTrans;
    
    void Start(){
        _cameraTrans = transform;
        _cameraTrans.rotation = Quaternion.Euler(cameraRot);
    }

    void LateUpdate(){
        _cameraTrans.position = Vector3.Slerp(_cameraTrans.position,playerTrans.position + cameraVec,2.0f*Time.deltaTime);
        _cameraTrans.rotation = Quaternion.Slerp(_cameraTrans.rotation,playerTrans.rotation*Quaternion.Euler(cameraRot),2.0f*Time.deltaTime);
    }
}
