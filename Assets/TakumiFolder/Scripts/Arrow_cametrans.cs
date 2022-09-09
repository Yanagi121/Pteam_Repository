using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_cametrans : MonoBehaviour
{
    [SerializeField] GameObject Arrow;

    void Start()
    {
        
    }

   
    void Update()
    {
        this.transform.position = Arrow.transform.position+new Vector3(0,15,-10);
    }
}
