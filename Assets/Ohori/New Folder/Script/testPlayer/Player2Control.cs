using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Control : MonoBehaviour
{
    public Vector3 pos;
    public float speed = 8;
    [SerializeField]
    public GameObject Dr_Invisible;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move_vec = Dr_Invisible.transform.position-transform.position;
        move_vec.y = 0.0f;
        Quaternion q = Quaternion.LookRotation(move_vec, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, q, 3.0f * Time.deltaTime);
        pos += transform.forward * speed * Time.deltaTime;
        //pos.y = 3.0f;
        transform.position = pos;
    }
}
