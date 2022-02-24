using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyButton : MonoBehaviourPunCallbacks
{
    GameObject Cam1;
    public void OnClick()
    {
        if (GameObject.Find("Camera1"))//DontDestroy‚ÌƒJƒƒ‰‚ğíœ
        {
            Cam1 = GameObject.Find("Camera1");
            Destroy(Cam1);
        }
        
    }
}
