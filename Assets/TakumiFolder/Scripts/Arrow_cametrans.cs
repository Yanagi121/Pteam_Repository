using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Arrow_cametrans : MonoBehaviourPunCallbacks
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
        if (photonView.IsMine)
        {
            //if (SceneManager.GetActiveScene().name == "LobbyScene")
            //{
               if (onetime == true)
               {
                if (this.gameObject.name == "Player1") 
                {
                    GameObject.FindGameObjectWithTag("ArrowCam1").SetActive(true);
                    GameObject.FindGameObjectWithTag("ArrowCam2").SetActive(false);
                    GameObject.FindGameObjectWithTag("ArrowCam3").SetActive(false);
                    GameObject.FindGameObjectWithTag("ArrowCam4").SetActive(false);
                };
                if (this.gameObject.name == "Player2")
                {
                    GameObject.FindGameObjectWithTag("ArrowCam1").SetActive(false);
                    GameObject.FindGameObjectWithTag("ArrowCam2").SetActive(true);
                    GameObject.FindGameObjectWithTag("ArrowCam3").SetActive(false);
                    GameObject.FindGameObjectWithTag("ArrowCam4").SetActive(false);
                };
                if (this.gameObject.name == "Player3")
                {
                    GameObject.FindGameObjectWithTag("ArrowCam1").SetActive(false);
                    GameObject.FindGameObjectWithTag("ArrowCam2").SetActive(false);
                    GameObject.FindGameObjectWithTag("ArrowCam3").SetActive(true);
                    GameObject.FindGameObjectWithTag("ArrowCam4").SetActive(false);
                };
                if (this.gameObject.name == "Player4")
                {
                    GameObject.FindGameObjectWithTag("ArrowCam1").SetActive(false);
                    GameObject.FindGameObjectWithTag("ArrowCam2").SetActive(false);
                    GameObject.FindGameObjectWithTag("ArrowCam3").SetActive(false);
                    GameObject.FindGameObjectWithTag("ArrowCam4").SetActive(true);
                };
                
                    //Debug.Log("<color=red>" + "update�̓ǂݍ���" + "</color>");
                    onetime = false;
               }
            //}
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
