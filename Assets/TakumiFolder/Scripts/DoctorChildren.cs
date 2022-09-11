using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorChildren : MonoBehaviour
{
    [SerializeField] GameObject DoctorParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position=DoctorParent.transform.position;
    }
}
