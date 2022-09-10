using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrow_cametrans : MonoBehaviour
{
    //[SerializeField] GameObject Arrow;

    void Start()
    {
        
            switch (DontDestroy_Porder.Porder_handover)
            {
                case 1: GameObject.FindGameObjectWithTag("ArrowCam1").SetActive(true); if_Cam(DontDestroy_Porder.Porder_handover); Debug.Log(DontDestroy_Porder.Porder_handover); break;
                case 2: GameObject.FindGameObjectWithTag("ArrowCam2").SetActive(true); if_Cam(DontDestroy_Porder.Porder_handover); Debug.Log(DontDestroy_Porder.Porder_handover); break;
                case 3: GameObject.FindGameObjectWithTag("ArrowCam3").SetActive(true); if_Cam(DontDestroy_Porder.Porder_handover); Debug.Log(DontDestroy_Porder.Porder_handover); break;
                case 4: GameObject.FindGameObjectWithTag("ArrowCam4").SetActive(true); if_Cam(DontDestroy_Porder.Porder_handover); Debug.Log(DontDestroy_Porder.Porder_handover); break;
                default: Debug.Log(DontDestroy_Porder.Porder_handover); break;
            }
        
    }

   
    void Update()
    {
        
    }
    void if_Cam(int playernum)//ÉJÉÅÉâÇ™Ç†ÇÈÇ©í≤Ç◊ÅAÇ†Ç¡ÇΩÇÁè¡Ç∑
    {
        switch (playernum)
        {
            case 1:
                if (GameObject.FindGameObjectWithTag("ArrowCam2"))
                {
                    GameObject.FindGameObjectWithTag("ArrowCam2").SetActive(false);
                }
                if (GameObject.FindGameObjectWithTag("ArrowCam3"))
                {
                    GameObject.FindGameObjectWithTag("ArrowCam3").SetActive(false);
                }
                if (GameObject.FindGameObjectWithTag("ArrowCam4"))
                {
                    GameObject.FindGameObjectWithTag("ArrowCam4").SetActive(false);
                }
                break;
            case 2:
                if (GameObject.FindGameObjectWithTag("ArrowCam1"))
                {
                    GameObject.FindGameObjectWithTag("ArrowCam1").SetActive(false);
                }
                if (GameObject.FindGameObjectWithTag("ArrowCam3"))
                {
                    GameObject.FindGameObjectWithTag("ArrowCam3").SetActive(false);
                }
                if (GameObject.FindGameObjectWithTag("ArrowCam4"))
                {
                    GameObject.FindGameObjectWithTag("ArrowCam4").SetActive(false);
                }
                break;
            case 3:
                if (GameObject.FindGameObjectWithTag("ArrowCam2"))
                {
                    GameObject.FindGameObjectWithTag("ArrowCam2").SetActive(false);
                }
                if (GameObject.FindGameObjectWithTag("ArrowCam1"))
                {
                    GameObject.FindGameObjectWithTag("ArrowCam1").SetActive(false);
                }
                if (GameObject.FindGameObjectWithTag("ArrowCam4"))
                {
                    GameObject.FindGameObjectWithTag("ArrowCam4").SetActive(false);
                }
                break;
            case 4:
                if (GameObject.FindGameObjectWithTag("ArrowCam2"))
                {
                    GameObject.FindGameObjectWithTag("ArrowCam2").SetActive(false);
                }
                if (GameObject.FindGameObjectWithTag("ArrowCam3"))
                {
                    GameObject.FindGameObjectWithTag("ArrowCam3").SetActive(false);
                }
                if (GameObject.FindGameObjectWithTag("ArrowCam1"))
                {
                    GameObject.FindGameObjectWithTag("ArrowCam1").SetActive(false);
                }
                break;
        }
        
    }
}
