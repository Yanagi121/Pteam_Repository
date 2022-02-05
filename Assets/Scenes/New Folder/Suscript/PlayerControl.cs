using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 rot = transform.eulerAngles;
        // à⁄ìÆÇ∆ëÄçÏ.
        pos += transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * 8.0f;
        rot.y += Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        transform.position = pos;
        transform.eulerAngles = rot;
    }
}
