using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlingTheCorners : MonoBehaviour
{
    [SerializeField]
    public MovePointControl movePointControl;

    //Šp‚És‚Á‚½‚Ìˆ—
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dr") { movePointControl.pos = new Vector3(Random.Range(-155.0f, 65.0f), 3.0f, Random.Range(-145.0f, 265.0f)); }
    }
}
