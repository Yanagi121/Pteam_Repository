using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlingTheCorners : MonoBehaviour
{
    [SerializeField]
    public MovePointControl movePointControl;

    //角に行った時の処理
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dr") { movePointControl.pos = new Vector3(Random.Range(90.0f, 470.0f), 10.0f, Random.Range(130.0f, 420.0f)); }
    }
}
