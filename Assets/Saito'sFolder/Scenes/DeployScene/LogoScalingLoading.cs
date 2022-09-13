using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScalingLoading : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localScale += new Vector3(0.1f,0.1f,0.1f);
    }
}
