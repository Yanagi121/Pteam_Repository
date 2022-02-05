using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Mobing_ : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed;

    
    private Rigidbody rg;
    float X, Z;
    bool moveZ, moveX;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    void Update()
    {
       
        X = Input.GetAxis("Horizontal");
        
        Z = Input.GetAxis("Vertical");


        if (Z != 0)
        {
            moveZ = true;
        }
        if (X != 0)
        {
            moveX = true;
        }
    }

    void FixedUpdate()
    {
        if (moveZ || moveX)
        {
            moveZ = false;
            moveX = false;
            rg.velocity = transform.rotation * new Vector3(X * moveSpeed, 0, Z * moveSpeed) * Time.deltaTime * 100;
        }
        else
        {
            rg.velocity = Vector3.zero;
        }
    }
}

