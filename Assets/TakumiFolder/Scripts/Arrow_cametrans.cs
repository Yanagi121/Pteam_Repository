using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrow_cametrans : MonoBehaviour
{
    //[SerializeField] GameObject Arrow;
    bool onetime;
    void Start()
    {
        onetime = true;
       // Debug.Log("<color=red>" + "start�̓ǂݍ���" + "</color>");
    }

   
    void Update()
    {
        if (onetime == true)
        {
            switch (DontDestroy_Porder.Porder_handover)
            {
                case 1: GameObject.FindGameObjectWithTag("ArrowCam1").SetActive(true); if_Cam(DontDestroy_Porder.Porder_handover); Debug.Log("<color=red>" + DontDestroy_Porder.Porder_handover + "</color>"); break;
                case 2: GameObject.FindGameObjectWithTag("ArrowCam2").SetActive(true); if_Cam(DontDestroy_Porder.Porder_handover); Debug.Log("<color=red>" + DontDestroy_Porder.Porder_handover + "</color>"); break;
                case 3: GameObject.FindGameObjectWithTag("ArrowCam3").SetActive(true); if_Cam(DontDestroy_Porder.Porder_handover); Debug.Log("<color=red>" + DontDestroy_Porder.Porder_handover + "</color>"); break;
                case 4: GameObject.FindGameObjectWithTag("ArrowCam4").SetActive(true); if_Cam(DontDestroy_Porder.Porder_handover); Debug.Log("<color=red>" + DontDestroy_Porder.Porder_handover + "</color>"); break;
                default: Debug.Log("<color=red>" + DontDestroy_Porder.Porder_handover + "</color>"); break;
            }
            //Debug.Log("<color=red>" + "update�̓ǂݍ���" + "</color>");
            onetime = false;
        }
        
    }
    void if_Cam(int playernum)//�J���������邩���ׁA�����������
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
